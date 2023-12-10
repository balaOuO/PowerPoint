using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DeleteShapeByIndexCommand : ICommand
    {
        Model _model;
        string _shapeType;
        Point _startdPoint;
        Point _endPoint;
        int _index;
        public DeleteShapeByIndexCommand(Model model , int index)
        {
            _model = model;
            _index = index;

            _shapeType = _model.ShapeList[_index].ShapeName;
            _startdPoint = _model.ShapeList[_index].StartPoint;
            _endPoint = _model.ShapeList[_index].EndPoint;
        }

        //Execute
        public void Execute()
        {
            _model.DeleteShapeCommand(_index);
        }

        //RollBackExecute
        public void RollBackExecute()
        {
            _model.InsertShapeToList(_shapeType, _startdPoint, _endPoint, _index);
        }
    }
}
