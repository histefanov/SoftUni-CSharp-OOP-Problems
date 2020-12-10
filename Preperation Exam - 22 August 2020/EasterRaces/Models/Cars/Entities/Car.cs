﻿using System;
using System.Collections.Generic;
using System.Text;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string _model;
        private int _horsePower;
        private double _cubicCentimeters;
        private int _minHorsePower;
        private int _maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            _minHorsePower = minHorsePower;
            _maxHorsePower = maxHorsePower;

            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get
            {
                return _model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                _model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return _horsePower;
            }
            private set
            {
                if (value < _minHorsePower || value > _maxHorsePower)
                {
                    throw new ArgumentException(
                        String.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                _horsePower = value;
            }
        }

        public double CubicCentimeters 
        { 
            get => _cubicCentimeters; 
            private set => _cubicCentimeters = value; 
        }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
