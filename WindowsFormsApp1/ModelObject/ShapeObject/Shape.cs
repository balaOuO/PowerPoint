using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    public class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string INFO = "Info";
        private const string SHAPE = "None";
        private bool _isSelect = false;
        protected Point _startPoint;
        protected Point _endPoint;

        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
        }

        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
        }

        public Point UpperLeftPoint
        {
            get
            {
                return new Point(
                    Math.Min(_startPoint.X, _endPoint.X),
                    Math.Min(_startPoint.Y, _endPoint.Y)
                );
            }
        }

        public Point LowerRightPoint
        {
            get
            {
                return new Point(
                    Math.Max(_startPoint.X, _endPoint.X),
                    Math.Max(_startPoint.Y, _endPoint.Y)
                );
            }
        }

        public bool IsSelect
        {
            get
            {
                return _isSelect;
            }
        }

        // GetInfo method
        public virtual string Info
        {
            get
            {
                return INFO;
            }
        }

        // GetShapeName method
        public virtual string ShapeName
        {
            get
            {
                return SHAPE;
            }
        }

        //set point method
        public virtual void SetPoint(Point point1 , Point point2)
        {
            _startPoint = point1;
            _endPoint = point2;
        }

        //set end point
        public virtual void SetEndPoint(Point endPoint)
        {
            SetPoint(_startPoint, endPoint);
        }

        //select
        public virtual void Select(Point startPoint , Point endPoint)
        {
            double inputUpperLeftX = Math.Min(startPoint.X , endPoint.X);
            double inputUpperLeftY = Math.Min(startPoint.Y, endPoint.Y);
            double inputLowerRightX = Math.Max(startPoint.X, endPoint.X);
            double inputLowerRightY = Math.Max(startPoint.Y, endPoint.Y);
            if ((inputUpperLeftX < LowerRightPoint.X && inputLowerRightX > UpperLeftPoint.X) && (inputUpperLeftY < LowerRightPoint.Y && inputLowerRightY > UpperLeftPoint.Y))
            {
                _isSelect = true;
            }
        }

        //move
        public virtual void Move(Point point)
        {
            _startPoint.X += point.X;
            _startPoint.Y += point.Y;
            _endPoint.X += point.X;
            _endPoint.Y += point.Y;
            
            Notify(INFO);
        }

        //cancel select
        public void CancelSelect()
        {
            _isSelect = false;
        }

        //draw mathod interface
        public virtual void Draw(IGraphics graphics)
        {
            if (_isSelect)
            {
                graphics.DrawSelectPoint(UpperLeftPoint , LowerRightPoint);
            }
        }

        //data binding notify method
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
