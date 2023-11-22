using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1Tests1;
using System.ComponentModel;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes _shapes;
        Point _testPoint1;
        Point _testPoint2;
        string _testPoint1String;
        string _testPoint2String;
        bool _isDataChange;
        PrivateObject _shapesPrivateObject;

        //DataChangeHandler
        public void DataChangeHandler()
        {
            _isDataChange = true;
        }

        //CheckShape
        public void CheckShape(Shape shape, string checkType, string point1, string point2, bool isSelect = false)
        {
            Assert.IsTrue(_isDataChange);
            Assert.AreEqual(shape.GetType(), Factory.CreateShapes(checkType).GetType());
            Assert.AreEqual(shape.StartPoint.ToString(), point1);
            Assert.AreEqual(shape.EndPoint.ToString(), point2);
            Assert.AreEqual(shape.IsSelect, isSelect);
            _isDataChange = false;
        }

        //GetShapeString
        public string GetShapeString(Shape shape)
        {
            return String.Format("\n{0},Info:{1},IsSelect:{2}", shape.ShapeName, shape.Info, shape.IsSelect);
        }

        //GetShapeListString
        public string GetShapeListString(BindingList<Shape> shapeList)
        {
            string listString = "";
            foreach (Shape aShape in shapeList)
            {
                listString += GetShapeString(aShape);
            }
            return listString;
        }

        //CreateShapeList
        public void CreateShapeList()
        {
            Shape shape;

            _shapes.AddShape(ShapeName.LINE, _testPoint1, _testPoint2);
            _shapes.AddShapeToList();
            shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");
            Assert.AreEqual(shape, null);
            CheckShape(_shapes.ShapeList[0], ShapeName.LINE, _testPoint1String, _testPoint2String);

            _shapes.AddShape(ShapeName.RECTANGLE, _testPoint2, _testPoint1);
            _shapes.AddShapeToList();
            shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");
            Assert.AreEqual(shape, null);
            CheckShape(_shapes.ShapeList[1], ShapeName.RECTANGLE, _testPoint2String, _testPoint1String);

            _shapes.AddShape(ShapeName.ELLIPSE, _testPoint1, _testPoint2);
            _shapes.AddShapeToList();
            shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");
            Assert.AreEqual(shape, null);
            CheckShape(_shapes.ShapeList[2], ShapeName.ELLIPSE, _testPoint1String, _testPoint2String);
        }

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _testPoint1 = new Point(10, 10);
            _testPoint2 = new Point(20, 20);
            _testPoint1String = _testPoint1.ToString();
            _testPoint2String = _testPoint2.ToString();
            _shapes = new Shapes();
            _isDataChange = false;
            _shapes._shapeDataChanged += DataChangeHandler;
            _shapesPrivateObject = new PrivateObject(_shapes);
            _shapesPrivateObject.SetFieldOrProperty("_factory", new Factory(new MockRandom()));
        }

        //TestAddShape
        [TestMethod()]
        public void TestAddShape()
        {
            Shape shape;

            _shapes.AddShape(ShapeName.LINE, _testPoint1, _testPoint2);
            shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");
            CheckShape(shape, ShapeName.LINE, _testPoint1String, _testPoint2String);
            Assert.AreEqual(_shapes.ShapeList.Count, 0);

            Initialize();
            _shapes.AddShape(ShapeName.RECTANGLE, _testPoint1, _testPoint2);
            shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");
            CheckShape(shape, ShapeName.RECTANGLE, _testPoint1String, _testPoint2String);
            Assert.AreEqual(_shapes.ShapeList.Count, 0);

            Initialize();
            _shapes.AddShape(ShapeName.ELLIPSE, _testPoint1, _testPoint2);
            shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");
            CheckShape(shape, ShapeName.ELLIPSE, _testPoint1String, _testPoint2String);
            Assert.AreEqual(_shapes.ShapeList.Count, 0);
        }

        //TestAddShape1
        [TestMethod()]
        public void TestAddShape1()
        {
            string testPointString = "(800,600)";
            Shape shape;

            _shapes.AddShape(ShapeName.LINE, 800, 600);
            shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");
            Assert.AreEqual(shape, null);
            Assert.AreEqual(_shapes.ShapeList.Count, 1);
            CheckShape(_shapes.ShapeList[0], ShapeName.LINE, testPointString, testPointString);

            _shapes.AddShape(ShapeName.RECTANGLE, 800, 600);
            shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");
            Assert.AreEqual(shape, null);
            Assert.AreEqual(_shapes.ShapeList.Count, 2);
            CheckShape(_shapes.ShapeList[1], ShapeName.RECTANGLE, testPointString, testPointString);

            _shapes.AddShape(ShapeName.ELLIPSE, 800, 600);
            shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");
            Assert.AreEqual(shape, null);
            Assert.AreEqual(_shapes.ShapeList.Count, 3);
            CheckShape(_shapes.ShapeList[2], ShapeName.ELLIPSE, testPointString, testPointString);
        }

        //TestAddShapeToList
        [TestMethod()]
        public void TestAddShapeToList()
        {
            CreateShapeList();
        }

        //TestDeleteShape
        [TestMethod()]
        public void TestDeleteShape()
        {
            string shapeListString;

            Initialize();
            CreateShapeList();
            shapeListString = GetShapeListString(_shapes.ShapeList);
            _shapes.DeleteShape(-1);
            Assert.AreEqual(GetShapeListString(_shapes.ShapeList), shapeListString);

            Initialize();
            CreateShapeList();
            shapeListString = GetShapeString(_shapes.ShapeList[1]) + GetShapeString(_shapes.ShapeList[2]);   
            _shapes.DeleteShape(0);
            Assert.AreEqual(GetShapeListString(_shapes.ShapeList), shapeListString);

            Initialize();
            CreateShapeList();
            shapeListString = GetShapeString(_shapes.ShapeList[0]) + GetShapeString(_shapes.ShapeList[2]);
            _shapes.DeleteShape(1);
            Assert.AreEqual(GetShapeListString(_shapes.ShapeList), shapeListString);

            Initialize();
            CreateShapeList();
            shapeListString = GetShapeString(_shapes.ShapeList[0]) + GetShapeString(_shapes.ShapeList[1]);
            _shapes.DeleteShape(2);
            Assert.AreEqual(GetShapeListString(_shapes.ShapeList), shapeListString);

            Initialize();
            CreateShapeList();
            shapeListString = GetShapeListString(_shapes.ShapeList);
            _shapes.DeleteShape(3);
            Assert.AreEqual(GetShapeListString(_shapes.ShapeList), shapeListString);
        }

        //TestSelectShape
        [TestMethod()]
        public void TestSelectShape()
        {
            _shapes.AddShape(ShapeName.LINE, _testPoint1, _testPoint2);
            _shapes.AddShapeToList();
            _shapes.SelectShape(new Point(15, 15));
            Assert.AreEqual(_shapes.ShapeList.Count, 1);
            CheckShape(_shapes.ShapeList[0], ShapeName.LINE, _testPoint1String, _testPoint2String, true);

            _shapes.SelectShape(new Point(5, 5));
            Assert.AreEqual(_shapes.ShapeList.Count, 1);
            CheckShape(_shapes.ShapeList[0], ShapeName.LINE, _testPoint1String, _testPoint2String, false);

            Initialize();
            CreateShapeList();
            _shapes.SelectShape(new Point(15, 15));
            Assert.AreEqual(_shapes.ShapeList.Count, 3);
            CheckShape(_shapes.ShapeList[0], ShapeName.LINE, _testPoint1String, _testPoint2String, false);
            _isDataChange = true;
            CheckShape(_shapes.ShapeList[1], ShapeName.RECTANGLE, _testPoint2String, _testPoint1String, false);
            _isDataChange = true;
            CheckShape(_shapes.ShapeList[2], ShapeName.ELLIPSE, _testPoint1String, _testPoint2String, true);

            _shapes.ShapeList[0].Move(new Point(100, 100));
            _shapes.SelectShape(new Point(115, 115));
            CheckShape(_shapes.ShapeList[0], ShapeName.LINE, "(110,110)", "(120,120)", true);
            _isDataChange = true;
            CheckShape(_shapes.ShapeList[1], ShapeName.RECTANGLE, _testPoint2String, _testPoint1String, false);
            _isDataChange = true;
            CheckShape(_shapes.ShapeList[2], ShapeName.ELLIPSE, _testPoint1String, _testPoint2String, false);
        }

        //TestDeleteSelectShape
        [TestMethod()]
        public void TestDeleteSelectShape()
        {
            string shapeListString;
            CreateShapeList();
            shapeListString = GetShapeString(_shapes.ShapeList[0]) + GetShapeString(_shapes.ShapeList[1]);
            Assert.AreEqual(_shapes.ShapeList.Count, 3);

            _shapes.SelectShape(new Point(15, 15));
            Assert.IsTrue(_shapes.ShapeList[2].IsSelect);

            _shapes.DeleteSelectShape();
            Assert.AreEqual(GetShapeListString(_shapes.ShapeList), shapeListString);           
        }

        //TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            MockGraphicAdaptor mockGraphicAdaptor = new MockGraphicAdaptor();

            _shapes.Draw(mockGraphicAdaptor);
            Assert.AreEqual(mockGraphicAdaptor.TotalDrawShape, 0);

            CreateShapeList();
            _shapes.AddShape(ShapeName.RECTANGLE, _testPoint2, _testPoint1);
            _shapes.Draw(mockGraphicAdaptor);
            Assert.AreEqual(mockGraphicAdaptor.TotalDrawShape, 4);
            Assert.IsFalse(mockGraphicAdaptor.IsDrawSelectPoint);
            mockGraphicAdaptor = new MockGraphicAdaptor();

            _shapes.SelectShape(new Point(15, 15));
            _shapes.Draw(mockGraphicAdaptor);
            Assert.AreEqual(mockGraphicAdaptor.TotalDrawShape, 4);
            Assert.IsTrue(mockGraphicAdaptor.IsDrawSelectPoint);
        }

        //TestModifyShape
        [TestMethod()]
        public void TestModifyShape()
        {
            _shapes.AddShape(ShapeName.LINE, _testPoint1, _testPoint2);
            Point newEndPoint = new Point(100, 100);
            _shapes.ModifyShape(newEndPoint);
            Shape shape = (Shape)_shapesPrivateObject.GetFieldOrProperty("_shape");

            CheckShape(shape, ShapeName.LINE, _testPoint1String, newEndPoint.ToString());
        }

        //TestMoveShape
        [TestMethod()]
        public void TestMoveShape()
        {
            _shapes.MoveShape(new Point(1, 1));
            Assert.IsFalse(_isDataChange);

            Initialize();
            CreateShapeList();
            _shapes.SelectShape(new Point(15, 15));
            _shapes.MoveShape(new Point(8, 8));

            Assert.AreEqual(_shapesPrivateObject.GetFieldOrProperty("_shape"), null);
            CheckShape(_shapes.ShapeList[0], ShapeName.LINE, _testPoint1String, _testPoint2String, false);
            _isDataChange = true;
            CheckShape(_shapes.ShapeList[1], ShapeName.RECTANGLE, _testPoint2String, _testPoint1String, false);
            _isDataChange = true;
            CheckShape(_shapes.ShapeList[2], ShapeName.ELLIPSE, "(18,18)", "(28,28)", true);
        }

        //TestClearSelect
        [TestMethod()]
        public void TestClearSelect()
        {
            CreateShapeList();
            string InitShapeListString = GetShapeListString(_shapes.ShapeList);
            _shapes.SelectShape(new Point(15, 15));
            _shapes.ClearSelect();

            Assert.AreEqual(GetShapeListString(_shapes.ShapeList), InitShapeListString);
            Assert.AreEqual(_shapesPrivateObject.GetFieldOrProperty("_shape"), null);
        }

        //testNotifyDataChanged
        [TestMethod()]
        public void TestNotifyDataChanged()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(ShapeName.LINE, 1, 2);
            Assert.IsFalse(_isDataChange);
        }
    }
}