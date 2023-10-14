namespace WindowsFormsApp1
{
    class Rectangle : Shape
    {
        private const string SHAPE = "Rectangle";

        //Rectangle getinfo method
        public override string GetInfo()
        {
            const string COMMA = ",";
            return UpperLeftPoint.ToString() + COMMA + LowerRightPoint.ToString();
        }

        //Rectangle get shape name method
        public override string GetShapeName()
        {
            return SHAPE;
        }
    }
}
