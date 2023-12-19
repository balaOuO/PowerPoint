using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class Model
    {
        private CommandManager _commandManager = new CommandManager();
        public CommandManager CommandManager
        {
            get
            {
                return _commandManager;
            }
        }

        //Undo
        public void Undo()
        {
            _commandManager.Undo();
        }

        //Redo
        public void Redo()
        {
            _commandManager.Redo();
        }

        //AddShapeCommand
        public void AddShapeCommand(string shapeType , Point startPoint , Point endPoint)
        {
            Shapes.AddShape(shapeType, startPoint, endPoint);
            Shapes.AddShapeToList();
        }

        //DeleteShapeCommand
        public void DeleteShapeCommand(int index = -1)
        {
            Shapes.DeleteShapeByIndex(index);
        }

        //InsertShapeToList
        public void InsertShapeToList(string shapeType, Point startPoint , Point endPoint , int index)
        {
            Shapes.InsertShapeToList(shapeType, startPoint, endPoint, index);
        }

        const string INFO = "Info";

        //MoveShapeByIndexCommand
        public void MoveShapeByIndexCommand(int index , Point startPoint , Point endPoint)
        {
            ShapeList[index].ReferPart(startPoint);
            ShapeList[index].Move(new Point(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));
            ShapeList[index].Update(INFO);
            NotifyDataChanged();
        }

        public void AddPageCommand(int index , Shapes shapes)
        {
            _pageList.Insert(index, shapes);
            _pageList[index]._shapeDataChanged += NotifyDataChanged;
            PageIndex = index;
            SetRefer();
            NotifyPageDataChange();
        }

        public void DeletePageCommand(int index)
        {
            _pageList.RemoveAt(index);
            if (PageIndex > _pageList.Count - 1)
            {
                PageIndex -= 1;
            }
            NotifyPageDataChange();
        }
    }
}
