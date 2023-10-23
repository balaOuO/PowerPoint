﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.ShapeObject;

namespace WindowsFormsApp1
{
    class Factory
    {
        Random _random = new Random();
        //creat shape
        public Shape CreateShapes(string shapeType)
        {
            switch (shapeType)
            {
                case ShapeName.RECTANGLE:
                    return new Rectangle();
                case ShapeName.LINE:
                    return new Line();
                case ShapeName.ELLIPSE:
                    return new Ellipse();
            }
            return null;
        }

        //give random point
        public Point CreateRandomPoint(int screenWidth , int screenHeight)
        {
            return new Point(_random.Next(screenWidth), _random.Next(screenHeight));
        }
    }
}
