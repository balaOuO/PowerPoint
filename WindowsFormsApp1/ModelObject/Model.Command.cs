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
        public void AddShapeCommand(int pageIndex , string shapeType , Point startPoint , Point endPoint)
        {
            PageIndex = pageIndex;
            PageList[pageIndex].AddShape(shapeType, startPoint, endPoint);
            PageList[pageIndex].AddShapeToList();
        }

        //DeleteShapeCommand
        public void DeleteShapeCommand(int pageIndex , int index = -1)
        {
            PageIndex = pageIndex;
            PageList[pageIndex].DeleteShapeByIndex(index);
        }

        //InsertShapeToList
        public void InsertShapeToList(int pageIndex , string shapeType, Point startPoint , Point endPoint , int index)
        {
            PageIndex = pageIndex;
            PageList[pageIndex].InsertShapeToList(shapeType, startPoint, endPoint, index);
        }

        const string INFO = "Info";

        //MoveShapeByIndexCommand
        public void MoveShapeByIndexCommand(int pageIndex , int index , Point startPoint , Point endPoint)
        {
            PageIndex = pageIndex;
            PageList[pageIndex].ShapeList[index].ReferPart(startPoint);
            PageList[pageIndex].ShapeList[index].Move(new Point(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));
            PageList[pageIndex].ShapeList[index].Update(INFO);
            NotifyDataChanged();
        }

        //AddPageCommand
        public void AddPageCommand(int index , Shapes shapes)
        {
            _pageList.Insert(index, shapes);
            _pageList[index]._shapeDataChanged += NotifyDataChanged;
            PageIndex = index;
            SetRefer();
            NotifyPageDataChange();
        }

        //DeletePageCommand
        public void DeletePageCommand(int index)
        {
            PageIndex = index;
            _pageList.RemoveAt(index);
            if (PageIndex > _pageList.Count - 1)
            {
                PageIndex -= 1;
            }
            NotifyPageDataChange();
        }
    }
}
