using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DeletePageCommand : ICommand
    {
        Model _model;
        Shapes _shapes;
        int _pageIndex;
        public DeletePageCommand(Model model , int pageIndex)
        {
            _model = model;
            _pageIndex = pageIndex;
            _shapes = _model.PageList[pageIndex];
        }

        //Execute
        public void Execute()
        {
            _model.DeletePageCommand(_pageIndex);
        }

        //RollBackExecute
        public void RollBackExecute()
        {
            _model.AddPageCommand(_pageIndex, _shapes);
        }
    }
}
