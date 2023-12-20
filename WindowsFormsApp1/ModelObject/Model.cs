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
            AddPageCommand(0 , new Shapes());
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
            CommandManager.Execute(new AddShapeCommand(this, PageIndex , shapeType , pointFactory.GetPoint(), pointFactory.GetPoint()));
        }

        //delete shape
        public void DeleteShapeByIndex(int index)
        {
            _commandManager.Execute(new DeleteShapeByIndexCommand(this, PageIndex , index));
        }

        //delete select
        public void Delete()
        {
            if (Shapes.GetSelectedShapeIndex() != -1)
            {
                _commandManager.Execute(new DeleteShapeByIndexCommand(this, PageIndex ,Shapes.GetSelectedShapeIndex()));
            }
            else
            {
                if (PageList.Count() > 1)
                {
                    _commandManager.Execute(new DeletePageCommand(this, PageIndex));
                }
            }
        }

        //draw method
        public void Draw(IGraphics graphics)
        {
            Shapes.Draw(graphics);
        }

        //Draw preview page
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
