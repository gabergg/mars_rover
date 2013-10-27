using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace marsRover
{
    public class Rovers : List<IRover>
    {
        public Rovers(IMap map)
        {
            this.Map = map;
        }

        public IMap Map
        {
            get;
            private set;
        }

        public void newRover(string position, string steps)
        {
            this.Add(new Rover(position, steps, this, this.Map));
        }
    }
}
