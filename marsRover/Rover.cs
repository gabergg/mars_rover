using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace marsRover
{
    class Rover : IRover
    {
        public Rover(string position, string steps, List<IRover> collection, IMap map)
        {
            this.collection = collection;

            //Initially rover is off edges of grid
            if (!roverOnMap(map))
            {
                throw new IndexOutOfRangeException();
            }

            this.setPosition(position);
            this.setSteps(steps, map);
        }

        public int xCoordinate
        {
            get;
            set;
        }
        public int yCoordinate
        {
            get;
            set;
        }
        public char direction
        {
            get;
            set;
        }
        public List<IRover> collection
        {
            get;
            set;
        }

        private void setPosition(string position)
        {
            string[] positionSep = position.Split(' ');

            this.xCoordinate = Convert.ToInt32(positionSep[0]);
            this.yCoordinate = Convert.ToInt32(positionSep[1]);
            this.direction = positionSep[2][0];
        }

        private void setSteps(string steps, IMap map)
        {
            char[] stepList = steps.ToCharArray();

            foreach (char step in stepList)
            {
                if (step == 'M')
                    this.move(map);
                else if (step == 'L')
                    this.turnLeft();
                else if (step == 'R')
                    this.turnRight();
                else
                    throw new ArgumentException();
            }
        }

        private bool roverOnMap(IMap map)
        {
            return this.xCoordinate >= 0 && this.yCoordinate >= 0 && this.xCoordinate <= map.xMaxCoordinate && this.yCoordinate <= map.yMaxCoordinate;
        }

        public void move(IMap map)
        {
            if (this.direction == 'N')
                this.yCoordinate += 1;
            else if (this.direction == 'E')
                this.xCoordinate += 1;
            else if (this.direction == 'S')
                this.yCoordinate -= 1;
            else
                this.xCoordinate -= 1;

            //rover trying to move off of grid
            if (!roverOnMap(map))
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void turnLeft()
        {
            if (this.direction == 'N')
                this.direction = 'W';
            else if (this.direction == 'E')
                this.direction = 'N';
            else if (this.direction == 'S')
                this.direction = 'E';
            else
                this.direction = 'S';
        }

        public void turnRight()
        {
            if (this.direction == 'N')
                this.direction = 'E';
            else if (this.direction == 'E')
                this.direction = 'S';
            else if (this.direction == 'S')
                this.direction = 'W';
            else
                this.direction = 'N';
        }
    }
}
