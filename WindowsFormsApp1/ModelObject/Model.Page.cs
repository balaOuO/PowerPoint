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
        int _pageIndex;

        public List<Shapes> PageList
        {
            get
            {
                return _pageList;
            }
        }

        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
                NotifyPageDataChange();
            }
        }

        //AddPage
        public void AddPage(int index)
        {
            _commandManager.Execute(new AddPageCommand(this, index , new Shapes()));
        }

        //NotifyPageDataChange
        public void NotifyPageDataChange()
        {
            if (_pageDataChange != null)
            {
                _pageDataChange();
            }
        }

        //ChoosePage
        public void SetPageIndex(int index)
        {
            PageIndex = index;
        }
    }
}
