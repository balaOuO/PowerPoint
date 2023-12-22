using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ModelObject.File
{
    public class PowerPointFileFormat
    {
        public PowerPointFileFormat(List<Shapes> pageList)
        {
            this.PageList = new List<PageFormat>();
            foreach (Shapes shapes in pageList)
            {
                this.PageList.Add(new PageFormat(shapes));
            }
        }

        public PowerPointFileFormat()
        {

        }

        public List<PageFormat> PageList
        {
            get; set;
        }

        //Read
        public List<Shapes> Read()
        {
            List<Shapes> pageList = new List<Shapes>();
            foreach (PageFormat pageFormat in this.PageList)
            {
                pageList.Add(pageFormat.Read());
            }
            return pageList;
        }
    }
}
