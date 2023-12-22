using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ModelObject.File
{
    public class PageFormat
    {
        public PageFormat(Shapes shapes)
        {
            this.ShapeList = new List<ShapeFormat>();
            foreach (Shape shape in shapes.ShapeList)
            {
                this.ShapeList.Add(new ShapeFormat(shape));
            }
        }

        public PageFormat()
        {
            
        }

        public List<ShapeFormat> ShapeList
        {
            get; set;
        }

        //Read
        public Shapes Read()
        {
            Shapes shapes = new Shapes();
            foreach (ShapeFormat shapeFormat in this.ShapeList)
            {
                shapes.AddShape(shapeFormat.ShapeName , new Point(shapeFormat.StartPointX , shapeFormat.StartPointY) , new Point(shapeFormat.EndPointX , shapeFormat.EndPointY));
                shapes.AddShapeToList();
            }
            return shapes;
        }
    }
}
