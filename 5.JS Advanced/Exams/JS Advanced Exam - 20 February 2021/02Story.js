class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`
        }
        if (this._likes.length == 1) {
            let usernameLike = this._likes[this._likes.length - 1];
            return `${usernameLike} likes this story!`
        }

        return `${this._likes[this._likes.length - 1]} and ${this._likes.length - 1} others like this story!"`;
    }

    like(username) {
        let user = this._likes.find(x => x === username);
        if (user) {
            throw new Error("You can't like the same story twice!");
        }
        if (this.creator === username) {
            throw new Error("You can't like your own story!");
        }
        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        let user = this._likes.find(x => x == username);
        if (!user) {
            throw new Error("You can't dislike this story!");
        }

        let index = this._likes.findIndex(x => x == username);
        this._likes.splice(index, 1);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        if (id === undefined || !this._comments.some(c => c.Id === id)) {
            let newComment = {
                Id: this._comments.length + 1,
                Username: username,
                Content: content,
                Replies: []
            };

            this._comments.push(newComment);
            return `${username} commented on ${this.title}`;
        }

        let commentToReplyTo = this._comments.find(c => c.Id === id);
        let replyNextId = commentToReplyTo.Replies.length + 1;
        let replyId = Number(`${commentToReplyTo.Id}.${replyNextId}`);
        let reply = {
            Id: replyId,
            Username: username,
            Content: content,
        }
        commentToReplyTo.Replies.push(reply);
        return `You replied successfully`;
    }
    toString(sortingType) {
        const sortVersion = {
            asc: (a, b) => a.Id - b.Id,
            desc: (a, b) => b.Id - a.Id,
            username: (a, b) => a.Username.localeCompare(b.Username)
        }

        let comments = this._comments.sort(sortVersion[sortingType]);
        comments.forEach(c => c.Replies.sort(sortVersion[sortingType]));

        let commentsStringArr = [];
        for (const comment of comments) {
            let commentString = `-- ${comment.Id}. ${comment.Username}: ${comment.Content}`;
            let repliesString = comment.Replies
                .map(r => `--- ${r.Id}. ${r.Username}: ${r.Content}`)
                .join('\n');
            repliesString = comment.Replies.length > 0
                ? `\n${repliesString}`
                : '';
            let combinedString = `${commentString}${repliesString}`;
            commentsStringArr.push(combinedString);
        }

        let fullCommentsString = this._comments.length > 0
            ? `\n${commentsStringArr.join('\n')}`
            : '';

        return `Title: ${this.title}
Creator: ${this.creator}
Likes: ${this._likes.length}
Comments:${fullCommentsString}`;
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
