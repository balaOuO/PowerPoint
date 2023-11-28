using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    public abstract partial class Shape
    {
        //set point method
        public virtual void SetPoint(Point point1, Point point2)
        {
            _startPoint = new Point(point1.X, point1.Y);
            _endPoint = new Point(point2.X, point2.Y);
            CompareCoordinateX();
            CompareCoordinateY();
        }

        //set end point
        public virtual void SetEndPoint(Point endPoint)
        {
            SetPoint(_startPoint, endPoint);
        }

        //select
        public virtual void Select(Point startPoint, Point endPoint)
        {
            double inputLeftX = Math.Min(startPoint.X, endPoint.X);
            double inputUpperY = Math.Min(startPoint.Y, endPoint.Y);
            double inputRightX = Math.Max(startPoint.X, endPoint.X);
            double inputLowerY = Math.Max(startPoint.Y, endPoint.Y);
            bool xIsSelect = false;
            bool yIsSelect = false;
            if (inputRightX >= UpperLeftPoint.X && inputLeftX <= LowerRightPoint.X)
                xIsSelect = true;
            if (inputUpperY <= LowerRightPoint.Y && inputLowerY >= UpperLeftPoint.Y)
                yIsSelect = true;
            ReferPart(endPoint);
            if (xIsSelect && yIsSelect || _referArea != ShapePart.ELSE)
            {
                _isSelect = true;
            }
        }

        //move
        public virtual void Move(Point point)
        {
            if (_referArea == ShapePart.LOWER_RIGHT_POINT)
            {
                _xBigPoint.X += point.X;
                _yBigPoint.Y += point.Y;
            }
            else
            {
                _startPoint.X += point.X;
                _startPoint.Y += point.Y;
                _endPoint.X += point.X;
                _endPoint.Y += point.Y;
            }
        }

        //cancel select
        public void CancelSelect()
        {
            _isSelect = false;
            _referArea = ShapePart.ELSE;
            NotifyRefer();
        }

        //draw mathod interface
        public virtual void Draw(IGraphics graphics)
        {
            if (_isSelect)
            {
                graphics.DrawSelectPoint(UpperLeftPoint, LowerRightPoint, SELECT_POINT_SIZE);
            }
        }

        //data binding notify method
        public void Update(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            CompareCoordinateX();
            CompareCoordinateY();
        }

        //CompareXcoordinates
        public void CompareCoordinateX()
        {
            if (_startPoint.X >= _endPoint.X)
            {
                _xBigPoint = _startPoint;
                _xSmallPoint = _endPoint;
            }
            else
            {
                _xBigPoint = _endPoint;
                _xSmallPoint = _startPoint;
            }
        }

        //CompareYCoordinate
        public void CompareCoordinateY()
        {
            if (_startPoint.Y >= _endPoint.Y)
            {
                _yBigPoint = _startPoint;
                _ySmallPoint = _endPoint;
            }
            else
            {
                _yBigPoint = _endPoint;
                _ySmallPoint = _startPoint;
            }
        }

        //refer part
        public void ReferPart(Point point)
        {
            if (Point.CalculateDistance(point, LowerRightPoint) <= SELECT_POINT_SIZE / TWO)
            {
                _referArea = ShapePart.LOWER_RIGHT_POINT;
            }
            else
            {
                _referArea = ShapePart.ELSE;
            }
            NotifyRefer();
        }

        //notify refer
        public void NotifyRefer()
        {
            if (_referToThePart != null)
            {
                _referToThePart(_referArea);
            }
        }
    }
}
