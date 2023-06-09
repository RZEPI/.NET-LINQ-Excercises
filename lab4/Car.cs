﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Car
    {
        public string model;
        public Engine motor;
        public int year;
        public Car(string model, Engine motor, int year)
        {
            this.model = model;
            this.motor = motor;
            this.year = year;
        }

        public override string ToString()
        {
            return "Model: " + this.model + "\nEngine: " + this.motor.ToString() + "\nYear: " + this.year;
        }
    }
    
}
