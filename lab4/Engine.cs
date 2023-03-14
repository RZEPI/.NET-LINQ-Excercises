using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Engine : IComparable
    {
        public double displacement;
        public double horsePower;
        public string model;

        public Engine(double displacement, double horsePower, string model)
        {
            this.displacement = displacement;
            this.horsePower = horsePower;
            this.model = model;
        }
        public int CompareTo(object obj)
        {
            Engine engine = obj as Engine;
            if(model.CompareTo(engine.model) != 0)
                return model.CompareTo(engine.model);
            else if(displacement.CompareTo(engine.displacement) != 0)
                return displacement.CompareTo(engine.displacement);
            else
                return horsePower.CompareTo(engine.horsePower);
        }

        public string EngineInfo()
        {
            return this.model + "/" + this.horsePower.ToString() + "/" + this.displacement.ToString();
        }
    }
}
