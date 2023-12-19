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

        public Model()
        {
            AddPage(0);
            InitializeCanvas();
        }

        public Shapes Shapes
        {
            get
            {
                return _pageList[PageIndex];
            }
            set
            {
                _pageList[PageIndex] = value;
                _pageList[PageIndex]._shapeDataChanged += NotifyDataChanged;
            }
        }

        public BindingList<Shape> ShapeList
        {
            get
            {
                return Shapes.ShapeList;
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
            if (Shapes.GetSelectedShapeIndex() != -1)
            {
                _commandManager.Execute(new DeleteShapeByIndexCommand(this, Shapes.GetSelectedShapeIndex()));
            }
            else
            {
                if (PageList.Count() > 1)
                {
                    DeletePageCommand(PageIndex);
                }
            }
        }

        //draw method
        public void Draw(IGraphics graphics)
        {
            Shapes.Draw(graphics);
        }

        public void Draw(IGraphics graphics , int index)
        {
            _pageList[index].Draw(graphics);
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
