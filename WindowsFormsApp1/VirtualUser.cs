using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class VirtualUser
    {
        Random _random = new Random();
        public Point UpperLeftPoint
        {
            get;
            set;
        }

        public Point LowerRightPoint
        {
            get;
            set;
        }

        //simulate user select a area
        public void SelectArea(int screenWidth , int screenHeight)
        {
            UpperLeftPoint = new Point(_random.Next(screenWidth), _random.Next(screenHeight));
            LowerRightPoint = new Point(_random.Next(screenWidth), _random.Next(screenHeight));
        }
    }
}
