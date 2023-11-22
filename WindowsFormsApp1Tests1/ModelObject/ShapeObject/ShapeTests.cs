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
    public class ShapeTests
    {
        Shape _shape;
        Point _testPoint1;
        Point _testPoint2;
        string _propertyName;

        PrivateObject _shapePrivateObject;

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _propertyName = string.Empty;

            _shape = new Line();
            _testPoint1 = new Point(10, 10);
            _testPoint2 = new Point(20, 20);

            _shapePrivateObject = new PrivateObject(_shape);
        }

        //TestSetPoint
        [TestMethod()]
        public void TestSetPoint()
        {
            _shape.SetPoint(_testPoint1, _testPoint2);

            Assert.AreEqual(_shape.Info, "(10,10),(20,20)");
        }

        //TestSetEndPoint
        [TestMethod()]
        public void TestSetEndPoint()
        {
            _shape.SetPoint(_testPoint1, _testPoint2);
            _shape.SetEndPoint(new Point(50, 60));

            Assert.AreEqual(_shape.Info, "(10,10),(50,60)");
        }


        //TestSelect
        [TestMethod()]
        public void TestSelect()
        {
            List<List<Point>> xSelectTestData = new List<List<Point>>()
            {
                new List<Point>(){ new Point(0 , 15) , new Point(0 , 15) },  //F
                new List<Point>(){ new Point(0 , 15) , new Point(10 , 15) }, //T
                new List<Point>(){ new Point(0 , 15) , new Point(15 , 15) }, //T
                new List<Point>(){ new Point(10 , 15) , new Point(15 , 15) },//T
                new List<Point>(){ new Point(15 , 15) , new Point(15 , 15) },//T
                new List<Point>(){ new Point(15 , 15) , new Point(20 , 15) },//T
                new List<Point>(){ new Point(15 , 15) , new Point(30 , 15) },//T
                new List<Point>(){ new Point(20 , 15) , new Point(30 , 15) },//T
                new List<Point>(){ new Point(30 , 15) , new Point(30 , 15) },//F
            };

            List<bool> xSelectTestAnswer = new List<bool>() { false, true, true, true, true, true, true, true, false};

            List<List<Point>> ySelectTestData = new List<List<Point>>()
            {
                new List<Point>(){ new Point(15 , 0) , new Point(15 , 0) },  //F
                new List<Point>(){ new Point(15 , 0) , new Point(15 , 10) }, //T
                new List<Point>(){ new Point(15 , 0) , new Point(15 , 15) }, //T
                new List<Point>(){ new Point(15 , 10) , new Point(15 , 15) },//T
                new List<Point>(){ new Point(15 , 15) , new Point(15 , 15) },//T
                new List<Point>(){ new Point(15 , 15) , new Point(15 , 20) },//T
                new List<Point>(){ new Point(15 , 15) , new Point(15 , 30) },//T
                new List<Point>(){ new Point(15 , 20) , new Point(15 , 30) },//T
                new List<Point>(){ new Point(15 , 30) , new Point(15 , 30) },//F
            };

            List<bool> ySelectTestAnswer = new List<bool>() { false, true, true, true, true, true, true, true, false };

            for (int i = 0; i < xSelectTestData.Count; i++)
            {
                Initialize();
                _shape.SetPoint(_testPoint1, _testPoint2);
                _shape.Select(xSelectTestData[i][0], xSelectTestData[i][1]);
                Assert.AreEqual(_shape.IsSelect, xSelectTestAnswer[i]);
            }

            for (int i = 0; i < ySelectTestData.Count; i++)
            {
                Initialize();
                _shape.SetPoint(_testPoint1, _testPoint2);
                _shape.Select(ySelectTestData[i][0], ySelectTestData[i][1]);
                Assert.AreEqual(_shape.IsSelect, ySelectTestAnswer[i]);
            }
        }

        //TestUpperLeftPoint
        [TestMethod()]
        public void TestUpperLeftPoint()
        {
            _shape.SetPoint(new Point(20, 20), new Point(10, 10));
            Assert.AreEqual(_shape.UpperLeftPoint.ToString(), "(10,10)");
            _shape.SetPoint(new Point(20, 10), new Point(10, 20));
            Assert.AreEqual(_shape.UpperLeftPoint.ToString(), "(10,10)");
            _shape.SetPoint(new Point(10, 20), new Point(20, 10));
            Assert.AreEqual(_shape.UpperLeftPoint.ToString(), "(10,10)");
            _shape.SetPoint(new Point(10, 10), new Point(20, 20));
            Assert.AreEqual(_shape.UpperLeftPoint.ToString(), "(10,10)");
        }

        //TestLowerRightPoint
        [TestMethod()]
        public void TestLowerRightPoint()
        {
            _shape.SetPoint(new Point(20, 20), new Point(10, 10));
            Assert.AreEqual(_shape.LowerRightPoint.ToString(), "(20,20)");
            _shape.SetPoint(new Point(20, 10), new Point(10, 20));
            Assert.AreEqual(_shape.LowerRightPoint.ToString(), "(20,20)");
            _shape.SetPoint(new Point(10, 20), new Point(20, 10));
            Assert.AreEqual(_shape.LowerRightPoint.ToString(), "(20,20)");
            _shape.SetPoint(new Point(10, 10), new Point(20, 20));
            Assert.AreEqual(_shape.LowerRightPoint.ToString(), "(20,20)");
        }

        //TestMove
        [TestMethod()]
        public void TestMove()
        {
            _shape.SetPoint(_testPoint1, _testPoint2);

            _shape.Move(new Point(10, 20));

            Assert.AreEqual(_shape.Info, "(20,30),(30,40)");

            _shape.Move(new Point(-100, -100));

            Assert.AreEqual(_shape.Info, "(-80,-70),(-70,-60)");
        }

        //TestCancelSelect
        [TestMethod()]
        public void TestCancelSelect()
        {
            _shape.SetPoint(_testPoint1, _testPoint2);
            _shape.Select(new Point(1, 1), new Point(40, 40));
            Assert.IsTrue(_shape.IsSelect);

            _shape.CancelSelect();
            Assert.IsFalse(_shape.IsSelect);
        }

        //TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _shape.SetPoint(_testPoint1, _testPoint2);
            _shape.Select(new Point(1, 1), new Point(40, 40));
            Assert.IsTrue(_shape.IsSelect);

            MockGraphicAdaptor mockGraphicAdaptor = new MockGraphicAdaptor();
            _shape.Draw(mockGraphicAdaptor);
            Assert.IsTrue(mockGraphicAdaptor.IsDrawSelectPoint);
        }

        //test Notify
        [TestMethod()]
        public void TestNotify()
        {
            _shape.PropertyChanged += GetNotifyPropertyName;
            _shapePrivateObject.Invoke("Notify", new object[] {"Info"});

            Assert.AreEqual(_propertyName, "Info");
        }

        //GetNotifyPropertyName
        public void GetNotifyPropertyName(object nothing, PropertyChangedEventArgs e)
        {
            _propertyName = e.PropertyName;
        }
    }
}