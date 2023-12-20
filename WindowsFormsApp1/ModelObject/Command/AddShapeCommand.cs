using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AddShapeCommand : ICommand
    {
        Model _model;
        string _shapeType;
        Point _startPoint;
        Point _endPoint;
        int _pageIndex;
        public AddShapeCommand(Model model, int pageIndex , string shapeType , Point startPoint , Point endPoint)
        {
            _model = model;
            _shapeType = shapeType;
            _startPoint = startPoint;
            _endPoint = endPoint;
            _pageIndex = pageIndex;
        }

        //Execute
        public void Execute()
        {
            _model.AddShapeCommand(_pageIndex, _shapeType, _startPoint, _endPoint);
        }

        //UnExecute
        public void RollBackExecute()
        {
            _model.DeleteShapeCommand(_pageIndex);
        }
    }
}
