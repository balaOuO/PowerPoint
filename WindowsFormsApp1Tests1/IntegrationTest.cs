using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using WindowsFormsApp1Tests1;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class IntegrationTest
    {
        PresentationModel _presentationModel;
        Model _model;
        Shapes _shapes;

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _shapes = new MockShapes();
            _model = new Model();
            _model.Shapes = _shapes;
            _presentationModel = new PresentationModel(_model);
        }

        //CheckShape
        public void CheckShape(Shape shape ,string shapeName, string Info, bool isSelect = false)
        {
            Assert.AreEqual(shape.ShapeName, shapeName);
            Assert.AreEqual(shape.Info, Info);
            Assert.AreEqual(shape.IsSelect, isSelect);
        }

        //DrawSomeShape
        public void DrawSomeShape()
        {
            _presentationModel.SetChooseShapeButton(ShapeName.ELLIPSE);
            _model.PressCanvas(new Point(10, 10));
            _model.MoveOnCanvas(new Point(20, 20));
            _model.MoveOnCanvas(new Point(40, 40));
            _model.ReleaseCanvas(new Point(40, 40));

            _presentationModel.SetChooseShapeButton(ShapeName.LINE);
            _model.PressCanvas(new Point(50, 10));
            _model.MoveOnCanvas(new Point(60, 20));
            _model.MoveOnCanvas(new Point(80, 40));
            _model.ReleaseCanvas(new Point(80, 40));

            _presentationModel.SetChooseShapeButton(ShapeName.RECTANGLE);
            _model.PressCanvas(new Point(10, 50));
            _model.MoveOnCanvas(new Point(20, 60));
            _model.MoveOnCanvas(new Point(40, 80));
            _model.ReleaseCanvas(new Point(40, 80));

            _presentationModel.SetChooseShapeButton(ShapeName.ELLIPSE);
            _model.PressCanvas(new Point(50, 50));
            _model.MoveOnCanvas(new Point(60, 60));
            _model.MoveOnCanvas(new Point(80, 80));
            _model.ReleaseCanvas(new Point(80, 80));
        }

        //Test1
        [TestMethod()]
        public void TestDraw()
        {
            DrawSomeShape();

            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, true);
            Assert.AreEqual(_model.ShapeList.Count, 4);
            CheckShape(_model.ShapeList[0], ShapeName.ELLIPSE, "(10,10),(40,40)");
            CheckShape(_model.ShapeList[1], ShapeName.LINE, "(50,10),(80,40)");
            CheckShape(_model.ShapeList[2], ShapeName.RECTANGLE, "(10,50),(40,80)");
            CheckShape(_model.ShapeList[3], ShapeName.ELLIPSE, "(50,50),(80,80)");

            //test2
            _model.DeleteShapeByIndex(2);
            _model.DeleteShapeByIndex(1);

            Assert.AreEqual(_model.ShapeList.Count, 2);
            CheckShape(_model.ShapeList[0], ShapeName.ELLIPSE, "(10,10),(40,40)");
            CheckShape(_model.ShapeList[1], ShapeName.ELLIPSE, "(50,50),(80,80)");

            //test3
            _model.AddShape(ShapeName.LINE);
            _model.AddShape(ShapeName.RECTANGLE);

            Assert.AreEqual(_model.ShapeList.Count, 4);
            Assert.AreEqual(_model.ShapeList[2].ShapeName, ShapeName.LINE);
            Assert.AreEqual(_model.ShapeList[3].ShapeName, ShapeName.RECTANGLE);
        }

        //TestOverlapModify
        [TestMethod()]
        public void TestOverlapModify()
        {
            _presentationModel.SetChooseShapeButton(ShapeName.RECTANGLE);
            _model.PressCanvas(new Point(10, 10));
            _model.MoveOnCanvas(new Point(30, 30));
            _model.ReleaseCanvas(new Point(30, 30));

            _presentationModel.SetChooseShapeButton(ShapeName.RECTANGLE);
            _model.PressCanvas(new Point(0, 20));
            _model.MoveOnCanvas(new Point(40, 40));
            _model.ReleaseCanvas(new Point(40, 40));

            _model.PressCanvas(new Point(10, 10));
            _model.ReleaseCanvas(new Point(10, 10));

            Assert.AreEqual(_model.ShapeList[0].IsSelect, true);

            _model.MoveOnCanvas(new Point(30, 30));

            Assert.AreEqual(new PrivateObject(_model.ShapeList[0]).GetFieldOrProperty("_referArea"), ShapePart.LOWER_RIGHT_POINT);

            _model.PressCanvas(new Point(30, 30));

            Assert.AreEqual(_model.ShapeList[0].IsSelect, false);
            Assert.AreEqual(_model.ShapeList[1].IsSelect, true);

            string shape1Info = _model.ShapeList[0].Info;            
            _model.MoveOnCanvas(new Point(31, 31));

            Assert.AreEqual(_model.ShapeList[0].Info, shape1Info);
            Assert.AreEqual(_model.ShapeList[1].Info, "(1,21),(41,41)");

            _model.ReleaseCanvas(new Point(31, 31));
            Assert.AreEqual(_model.ShapeList[0].IsSelect, false);
            Assert.AreEqual(_model.ShapeList[1].IsSelect, true);
        }
    }
}
