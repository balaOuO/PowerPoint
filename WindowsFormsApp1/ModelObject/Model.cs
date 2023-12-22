using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WindowsFormsApp1.ModelObject.State;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Model
    {
        public delegate void ShapeDataChangedEventHandler();
        public event ShapeDataChangedEventHandler _shapeDataChanged;

        public Model()
        {
            _pageList = new List<Shapes>() 
            {
                new Shapes() 
            };
            _commandManager = new CommandManager();
            Initialize();
        }

        //Initialize
        public void Initialize()
        {
            _pageIndex = 0;
            InitializeCanvas();
            _commandManager.Initialize();
            SetRefer();
            foreach (Shapes shapes in _pageList)
            {
                shapes._shapeDataChanged += NotifyDataChanged;
                shapes.DelegateAllRefer();
            }
            NotifyDataChanged();
            NotifyPageDataChange();
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
        public void AddShape(string shapeType , Point startPoint , Point endPoint)
        {
            Debug.Assert(shapeType == ShapeName.RECTANGLE || shapeType == ShapeName.ELLIPSE || shapeType == ShapeName.LINE);
            CommandManager.Execute(new AddShapeCommand(this, PageIndex , shapeType , startPoint, endPoint));
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

        //Save
        public void Save()
        {
            FileManager.Save(PageList);
        }

        //Load
        public void Load()
        {
            _pageList = FileManager.Load();
            Initialize();
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
