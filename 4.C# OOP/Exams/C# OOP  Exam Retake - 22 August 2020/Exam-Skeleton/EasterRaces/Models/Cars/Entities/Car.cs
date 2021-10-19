﻿using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private int minHorsePower;
        private int maxHorsePower;

        private int horsePower;
        private string model;
        private double cubicCentimeters;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }
                model = value;
            }

        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");

                }
                horsePower = value;
            }

        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double result = CubicCentimeters / HorsePower * laps;
            return result;
        }
    }
}
