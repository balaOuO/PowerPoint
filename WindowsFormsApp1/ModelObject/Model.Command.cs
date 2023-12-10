﻿using System;
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
            _shapes.AddShape(shapeType, startPoint, endPoint);
            _shapes.AddShapeToList();
        }

        //DeleteShapeCommand
        public void DeleteShapeCommand(int index = -1)
        {
            _shapes.DeleteShapeByIndex(index);
        }

        //InsertShapeToList
        public void InsertShapeToList(string shapeType, Point startPoint , Point endPoint , int index)
        {
            _shapes.InsertShapeToList(shapeType, startPoint, endPoint, index);
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
    }
}