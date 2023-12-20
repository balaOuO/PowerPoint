using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AddPageCommand : ICommand
    {
        Model _model;
        Shapes _shapes;
        int _pageIndex;

        public AddPageCommand(Model model , int pageIndex , Shapes shapes)
        {
            _model = model;
            _pageIndex = pageIndex;
            _shapes = shapes;
        }

        //Execute
        public void Execute()
        {
            _model.AddPageCommand(_pageIndex, _shapes);
        }

        //RollBackExecute
        public void RollBackExecute()
        {
            _model.DeletePageCommand(_pageIndex);
        }
    }
}
