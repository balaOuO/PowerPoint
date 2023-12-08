using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WindowsFormsApp1Tests1
{
    class MockShapes : Shapes
    {
        const string COMMA = ",";
        public MockShapes()
        {
            IsAddShape = false;
            AddShapeInput = string.Empty;
            IsDeleteShape = false;
            IsDraw = false;
            IsSelectShape = false;
            MoveInput = string.Empty;
            IsMoveShape = false;
            IsModifyShape = false;
            IsAddShapeToList = false;
            IsUpdateInfo = false;
            IsReferSelectedShape = false;
        }

        public bool IsAddShape
        {
            get; set;
        }

        public string AddShapeInput
        {
            get; set;
        }

        public bool IsDeleteShape
        {
            get; set;
        }

        public bool IsDraw
        {
            get; set;
        }

        public bool IsSelectShape
        {
            get; set;
        }

        public string MoveInput
        {
            get; set;
        }

        public bool IsMoveShape
        {
            get; set;
        }

        public bool IsModifyShape
        {
            get; set;
        }

        public bool IsAddShapeToList
        {
            get; set;
        }

        public bool IsUpdateInfo
        {
            get; set;
        }

        public bool IsReferSelectedShape
        {
            get; set;
        }

        //AddShape
        public override void AddShape(string shapeType, Point upperLeftPoint, Point lowerRightPoint)
        {
            IsAddShape = true;
            AddShapeInput = upperLeftPoint.ToString() + COMMA + lowerRightPoint.ToString();
            base.AddShape(shapeType, upperLeftPoint, lowerRightPoint);
        }

        //DeleteShape
        public override void DeleteShapeByIndex(int index)
        {
            IsDeleteShape = true;
            base.DeleteShapeByIndex(index);
        }

        //Draw
        public override void Draw(IGraphics graphics)
        {
            IsDraw = true;
            base.Draw(graphics);
        }

        //SelectShape
        public override void SelectShape(Point point)
        {
            IsSelectShape = true;
            base.SelectShape(point);
        }

        //MoveShape
        public override void MoveShape(Point point)
        {
            IsMoveShape = true;
            MoveInput = point.ToString();
            base.MoveShape(point);
        }

        //ModifyShape
        public override void ModifyShape(Point point)
        {
            IsModifyShape = true;
            base.ModifyShape(point);
        }

        //AddShapeToList
        public override void AddShapeToList()
        {
            IsAddShapeToList = true;
            base.AddShapeToList();
        }

        //UpdateInfo
        public override void UpdateInfo()
        {
            IsUpdateInfo = true;
            base.UpdateInfo();
        }

        //ReferSelectedShape
        public override void ReferSelectedShape(Point point)
        {
            IsReferSelectedShape = true;
            base.ReferSelectedShape(point);
        }
    }
}
