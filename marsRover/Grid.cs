using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace marsRover
{
    public class Grid : IMap
    {
        public Grid(int xMax, int yMax)
        {
            this.xMaxCoordinate = xMax;
            this.yMaxCoordinate = yMax;
        }

        public Grid(string coordinates)
        {
            this.getCoordinates(coordinates);
        }

        public virtual int xMaxCoordinate
        {
            get;
            private set;
        }
        public virtual int yMaxCoordinate
        {
            get;
            private set;
        }

        private void getCoordinates(string coordinates)
        {
            string[] finalCoordinates = coordinates.Split(' ');

            if (finalCoordinates.Length != 2)
                throw new ArgumentOutOfRangeException();

            this.xMaxCoordinate = Convert.ToInt32(finalCoordinates[0]);
            this.yMaxCoordinate = Convert.ToInt32(finalCoordinates[1]);

        }
    }
}
