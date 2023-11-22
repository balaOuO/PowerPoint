using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string FORMAT = "{0},{1}";
        private const string INFO = "Info";
        private bool _isSelect = false;
        protected Point _startPoint = new Point(0, 0);
        protected Point _endPoint = new Point(0, 0);

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
                return string.Format(FORMAT, StartPoint.ToString(), EndPoint.ToString());
            }
        }

        // GetShapeName method
        public abstract string ShapeName
        {
            get;
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
            double inputLeftX = Math.Min(startPoint.X , endPoint.X);
            double inputUpperY = Math.Min(startPoint.Y, endPoint.Y);
            double inputRightX = Math.Max(startPoint.X, endPoint.X);
            double inputLowerY = Math.Max(startPoint.Y, endPoint.Y);
            bool xIsSelect = false;
            bool yIsSelect = false;
            if (inputRightX >= UpperLeftPoint.X && inputLeftX <= LowerRightPoint.X)
                xIsSelect = true;
            if (inputUpperY <= LowerRightPoint.Y && inputLowerY >= UpperLeftPoint.Y)
                yIsSelect = true;
            if (xIsSelect && yIsSelect)
            {
                _isSelect = true;
            }
        }

        //move
        public virtual void Move(Point point)
        {
            _startPoint = new Point(_startPoint.X + point.X, _startPoint.Y + point.Y);
            _endPoint = new Point(_endPoint.X + point.X, _endPoint.Y + point.Y);

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
        protected void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
