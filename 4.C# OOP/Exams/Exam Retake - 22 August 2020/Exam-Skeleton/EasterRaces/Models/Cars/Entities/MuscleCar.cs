﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int MinHorsePower = 400;
        private const int MaxHorsePower = 600;
        private const double CubicCentimeters = 5000;
        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, CubicCentimeters, MinHorsePower, MaxHorsePower)
        {
        }
    }
}