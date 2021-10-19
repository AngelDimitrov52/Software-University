class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(pointA, pointB) {
        let xAbs = Math.abs(pointA.x - pointB.x)
        let yAbs = Math.abs(pointA.y - pointB.y)
        let result = Math.sqrt(xAbs ** 2 + yAbs ** 2);
        return result;
    }
}



let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
