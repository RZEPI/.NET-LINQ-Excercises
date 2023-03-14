using System;
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

        public string CarInfo()
        {
            return "Model: " + this.model + "\nEngine: " + this.motor.EngineInfo() + "\nYear: " + this.year;
        }
    }
    
}
