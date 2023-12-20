using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class MoveCommand : ICommand
    {
        Model _model;
        Point _startPoint;
        Point _endPoint;
        int _index;
        int _pageIndex;
        public MoveCommand(Model model , int pageIndex , int index , Point startPoint , Point endPoint)
        {
            _model = model;
            _index = index;
            _startPoint = startPoint;
            _endPoint = endPoint;
            _pageIndex = pageIndex;
        }

        //Execute
        public void Execute()
        {
            _model.MoveShapeByIndexCommand(_pageIndex , _index, _startPoint, _endPoint);
        }

        //RollBackExecute
        public void RollBackExecute()
        {
            _model.MoveShapeByIndexCommand(_pageIndex, _index, _endPoint, _startPoint);
        }
    }
}
