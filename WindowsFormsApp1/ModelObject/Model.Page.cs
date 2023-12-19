using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class Model
    {
        public delegate void PageDataChangeEventHandler();
        public event PageDataChangeEventHandler _pageDataChange;

        List<Shapes> _pageList = new List<Shapes>();
        int _pageIndex = 0;

        public List<Shapes> PageList
        {
            get
            {
                return _pageList;
            }
        }

        public void AddPage(int index)
        {
            AddPageCommand(index, new Shapes());
        }

        public void NotifyPageDataChange()
        {
            if (_pageDataChange != null)
            {
                _pageDataChange();
            }
        }
    }
}
