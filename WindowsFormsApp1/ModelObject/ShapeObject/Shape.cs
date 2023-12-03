using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    public abstract partial class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void ReferPartEventHandler(string referPart);
        public event ReferPartEventHandler _referToThePart;

        private const string FORMAT = "{0},{1}";
        private const string INFO = "Info";
        private bool _isSelect = false;
        protected string _referArea = ShapePart.ELSE;
        protected Point _startPoint = new Point(0, 0);
        protected Point _endPoint = new Point(0, 0);
        protected Point _xSmallPoint;
        protected Point _xBigPoint;
        protected Point _ySmallPoint;
        protected Point _yBigPoint;
        public const float SELECT_POINT_SIZE = 20;
        private const float TWO = 2;

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
    }
}
