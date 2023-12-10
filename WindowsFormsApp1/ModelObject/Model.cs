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

        private Shapes _shapes;

        public Model()
        {
            Shapes = new Shapes();
            InitializeCanvas();
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
        public void AddShape(string shapeType)
        {
            PointFactory pointFactory = new PointFactory();
            CommandManager.Execute(new AddShapeCommand(this, shapeType , pointFactory.GetPoint(), pointFactory.GetPoint()));
        }

        //delete shape
        public void DeleteShapeByIndex(int index)
        {
            _commandManager.Execute(new DeleteShapeByIndexCommand(this, index));
        }

        //delete select
        public void DeleteSelect()
        {
            _commandManager.Execute(new DeleteShapeByIndexCommand(this, _shapes.GetSelectedShapeIndex()));
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
