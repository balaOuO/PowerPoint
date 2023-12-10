using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class PointFactory
    {
        Random _random = new Random();

        //GetPoint
        public Point GetPoint()
        {
            return new Point(_random.Next(ScreenSize.WIDTH) , _random.Next(ScreenSize.HEIGHT));
        }
    }
}
