using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WindowsFormsApp1.ModelObject.State;

namespace WindowsFormsApp1
{
    public partial class Model
    {
        public delegate void ShapeDataChangedEventHandler();
        public event ShapeDataChangedEventHandler _shapeDataChanged;        

        private Shapes _shapes = new Shapes();

        public Model()
        {
            InitializeCanvas();
            _shapes._shapeDataChanged += NotifyDataChanged;
        }

        public Shapes Shapes
        {
            get
            {
                return _shapes;
            }
            set
            {
                _shapes = value;
                _shapes._shapeDataChanged += NotifyDataChanged;
            }
        }

        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapes.ShapeList;
            }
        }

        //add shape random
        public void AddShape(string shapeType , int screenWidth , int screenHeight)
        {
            _shapes.AddShape(shapeType , screenWidth, screenHeight);
        }

        //delete shape
        public void DeleteShapeButton(int index)
        {
            _shapes.DeleteShape(index);
        }

        //delete select
        public void DeleteSelect()
        {
            _shapes.DeleteSelectShape();
        }

        //draw method
        public void Draw(IGraphics graphics)
        {
            _shapes.Draw(graphics);
        }

        //notify data change
        private void NotifyDataChanged()
        {
            if (_shapeDataChanged != null)
            {
                _shapeDataChanged();
            }
        }
    }
}
