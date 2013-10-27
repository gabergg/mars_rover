using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace marsRover
{
    public interface IRover
    {
        int xCoordinate
        {
            get;
            set;
        }
        int yCoordinate
        {
            get;
            set;
        }
        char direction
        {
            get;
            set;
        }
        List<IRover> collection
        {
            get;
            set;
        }
    }
}
