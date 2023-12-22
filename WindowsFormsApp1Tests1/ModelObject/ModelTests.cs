using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1Tests1;
using WindowsFormsApp1.ModelObject.State;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model _model;
        PrivateObject _modelPrivateObject;
        MockShapes _mockShapes;
        bool _isNotifyDataChange;
        bool _isNotifyDrawingFinish;
        bool _isPageDataChanged;
        ICanvasState _canvasState;

        //HandleShapeDataChanged
        public void HandleShapeDataChanged()
        {
            _isNotifyDataChange = true;
        }

        //HandleDrawingFinish
        public void HandleDrawingFinish()
        {
            _isNotifyDrawingFinish = true;
        }

        //HandleDrawingFinish
        public void HandlePageDataChanged()
        {
            _isPageDataChanged = true;
        }

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _modelPrivateObject = new PrivateObject(_model);
            _mockShapes = new MockShapes();
            _model.Shapes = _mockShapes;
            _canvasState = (ICanvasState)_modelPrivateObject.GetFieldOrProperty("_canvasState");

            _model._shapeDataChanged += HandleShapeDataChanged;
            _model._drawingFinish += HandleDrawingFinish;
            _model._pageDataChange += HandlePageDataChanged;

            _isNotifyDataChange = false;
            _isNotifyDrawingFinish = false;
            _isPageDataChanged = false;
        }

        //TestModel
        [TestMethod()]
        public void TestModel()
        {
            Assert.IsTrue(_model.Shapes is Shapes);
            Assert.IsTrue(_modelPrivateObject.GetFieldOrProperty("_pointerState") is PointerState);
            Assert.IsTrue(_modelPrivateObject.GetFieldOrProperty("_drawingState") is DrawingState);
            Assert.IsTrue(_modelPrivateObject.GetFieldOrProperty("_canvasState") is ICanvasState);
        }

        //TestInitialize
        [TestMethod()]
        public void TestInitialize()
        {
            _model.Initialize();
            Assert.IsTrue(_model.Shapes is Shapes);
            Assert.AreEqual(_model.PageIndex, 0);
        }

        //TestAddShape
        [TestMethod()]
        public void TestAddShape()
        {
            _model.AddShape(ShapeName.LINE, new Point(0, 0), new Point(0, 0));

            Assert.IsTrue(_mockShapes.IsAddShape);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestDeleteShapeButton
        [TestMethod()]
        public void TestDeleteShapeByIndex()
        {
            _model.AddShape(ShapeName.LINE, new Point(0, 0), new Point(0, 0));
            _model.DeleteShapeByIndex(0);

            Assert.IsTrue(_mockShapes.IsDeleteShapeByIndex);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestDeleteSelect
        [TestMethod()]
        public void TestDeleteSelect()
        {
            _model.AddShapeCommand(0, ShapeName.LINE, new Point(1600, 900), new Point(1600, 900));
            _mockShapes.SelectShape(new Point(1600, 900));
            Assert.IsTrue(_isNotifyDataChange);
            _isNotifyDataChange = false;

            _model.Delete();

            Assert.IsTrue(_mockShapes.IsDeleteShapeByIndex);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestDeletePage
        [TestMethod()]
        public void TestDeletePage()
        {
            _model.AddPage(0);
            _model.AddShape(ShapeName.RECTANGLE, new Point(0, 0), new Point(0, 0));

            _model.AddPage(2);
            _model.AddShape(ShapeName.ELLIPSE, new Point(0, 0), new Point(0, 0));

            Assert.AreEqual(_model.PageList.Count(), 3);

            _model.SetPageIndex(1);
            _model.Delete();
            Assert.AreEqual(_model.PageList.Count(), 2);
            Assert.AreEqual(_model.PageIndex, 1);
            Assert.AreEqual(_model.Shapes.ShapeList[0].ShapeName, ShapeName.ELLIPSE);

            _model.SetPageIndex(1);
            _model.Delete();
            Assert.AreEqual(_model.PageList.Count(), 1);
            Assert.AreEqual(_model.PageIndex, 0);
            Assert.AreEqual(_model.Shapes.ShapeList[0].ShapeName, ShapeName.RECTANGLE);

            _model.Delete();
            Assert.AreEqual(_model.PageList.Count(), 1);
            Assert.AreEqual(_model.PageIndex, 0);
            Assert.AreEqual(_model.Shapes.ShapeList[0].ShapeName, ShapeName.RECTANGLE);
        }

        //TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _model.Draw(new MockGraphicAdaptor());

            Assert.IsTrue(_mockShapes.IsDraw);
        }

        //TestDraw1
        [TestMethod()]
        public void TestDraw1()
        {
            _model.Draw(new MockGraphicAdaptor(), 0);

            Assert.IsTrue(_mockShapes.IsDraw);
        }

        //testNotifyDataChanged
        [TestMethod()]
        public void TestNotifyDataChanged()
        {
            _modelPrivateObject.Invoke("NotifyDataChanged");
            Assert.IsTrue(_isNotifyDataChange);

            Initialize();
            _model._shapeDataChanged -= HandleShapeDataChanged;
            Assert.IsFalse(_isNotifyDataChange);
        }

        //TestChooseShape
        [TestMethod()]
        public void TestChooseShape()
        {
            _model.ChooseShape(ShapeName.LINE);
            _canvasState = (ICanvasState)_modelPrivateObject.GetFieldOrProperty("_canvasState");
            Assert.AreEqual(_canvasState.GetStateName(), "DrawingState");

            _model.ChooseShape(ShapeName.RECTANGLE);
            _canvasState = (ICanvasState)_modelPrivateObject.GetFieldOrProperty("_canvasState");
            Assert.AreEqual(_canvasState.GetStateName(), "DrawingState");

            _model.ChooseShape(ShapeName.ELLIPSE);
            _canvasState = (ICanvasState)_modelPrivateObject.GetFieldOrProperty("_canvasState");
            Assert.AreEqual(_canvasState.GetStateName(), "DrawingState");

            _model.ChooseShape(ShapeName.POINTER);
            _canvasState = (ICanvasState)_modelPrivateObject.GetFieldOrProperty("_canvasState");
            Assert.AreEqual(_canvasState.GetStateName(), "PointerState");

        }

        //TestPressCanvas
        [TestMethod()]
        public void TestPressCanvas()
        {
            _model.PressCanvas(new Point(1, 2));
            Assert.IsTrue(_mockShapes.IsSelectShape);

            Initialize();
            _model.ChooseShape(ShapeName.LINE);
            _model.PressCanvas(new Point(1, 2));
            Assert.IsTrue(_mockShapes.IsAddShape);
        }

        //TestMoveOnCanvas
        [TestMethod()]
        public void TestMoveOnCanvas()
        {
            _model.PressCanvas(new Point(1, 2));
            _model.MoveOnCanvas(new Point(3, 4));
            Assert.IsTrue(_mockShapes.IsMoveShape);

            Initialize();
            _model.ChooseShape(ShapeName.LINE);
            _model.PressCanvas(new Point(1, 2));
            _model.MoveOnCanvas(new Point(3, 4));
            Assert.IsTrue(_mockShapes.IsModifyShape);
        }

        //TestReleaseCanvas
        [TestMethod()]
        public void TestReleaseCanvas()
        {
            _model.PressCanvas(new Point(1, 2));
            _model.MoveOnCanvas(new Point(3, 4));
            _model.ReleaseCanvas(new Point(5, 6));
            Assert.IsTrue(true);

            Initialize();
            _model.ChooseShape(ShapeName.LINE);
            _model.PressCanvas(new Point(1, 2));
            _model.MoveOnCanvas(new Point(3, 4));
            _model.ReleaseCanvas(new Point(5, 6));
            Assert.IsTrue(_mockShapes.IsAddShapeToList);
        }

        //TestNotifyDrawingFinish
        [TestMethod()]
        public void TestNotifyDrawingFinish()
        {
            _model.NotifyDrawingFinish();
            Assert.IsTrue(_isNotifyDrawingFinish);
            Assert.AreEqual(_canvasState.GetStateName(), "PointerState");

            Initialize();
            _model._drawingFinish -= HandleDrawingFinish;
            _model.NotifyDrawingFinish();
            Assert.IsFalse(_isNotifyDrawingFinish);
            Assert.AreEqual(_canvasState.GetStateName(), "PointerState");

            Initialize();
            _model.ChooseShape(ShapeName.LINE);
            _model.NotifyDrawingFinish();
            Assert.IsTrue(_isNotifyDrawingFinish);
            Assert.AreEqual(_canvasState.GetStateName(), "PointerState");
        }

        //TestGetShapes
        [TestMethod()]
        public void TestGetShapes()
        {
            Assert.AreEqual(_model.Shapes, _mockShapes);
        }

        //TestGetShapeList
        [TestMethod()]
        public void TestGetShapeList()
        {
            Assert.AreEqual(_model.ShapeList, _mockShapes.ShapeList);
        }

        //TestSetRefer
        [TestMethod()]
        public void TestSetRefer()
        {
            Assert.IsTrue(true);
        }

        //TestUndo
        [TestMethod()]
        public void TestUndo()
        {
            _model.AddShape(ShapeName.LINE, new Point(0, 0), new Point(0, 0));
            _model.Undo();
            Assert.AreEqual(_model.ShapeList.Count, 0);
        }

        //TestRedo
        [TestMethod()]
        public void TestRedo()
        {
            _model.AddShape(ShapeName.LINE, new Point(0, 0), new Point(0, 0));
            _model.Undo();
            _model.Redo();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].ShapeName, ShapeName.LINE);
        }

        //TestAddShapeCommand
        [TestMethod()]
        public void TestAddShapeCommand()
        {
            _model.AddShape(ShapeName.LINE, new Point(0, 0), new Point(0, 0));

            Assert.IsTrue(_mockShapes.IsAddShape);
            Assert.IsTrue(_mockShapes.IsAddShapeToList);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestDeleteShapeCommand
        [TestMethod()]
        public void TestDeleteShapeCommand()
        {
            _model.AddShape(ShapeName.ELLIPSE, new Point(0, 0), new Point(0, 0));
            _model.DeleteShapeCommand(0);
            Assert.AreEqual(_model.ShapeList.Count, 0);
            Assert.IsTrue(_mockShapes.IsDeleteShapeByIndex);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestInsertShapeToList
        [TestMethod()]
        public void TestInsertShapeToList()
        {
            _model.InsertShapeToList(0, ShapeName.RECTANGLE, new Point(10, 10), new Point(200, 200), 0);
            Assert.IsTrue(_mockShapes.IsInsertShapeToList);
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].ShapeName, ShapeName.RECTANGLE);
            Assert.AreEqual(_model.ShapeList[0].Info, "(10,10),(200,200)");
        }

        //TestMoveShapeByIndexCommand
        [TestMethod()]
        public void TestMoveShapeByIndexCommand()
        {
            _model.AddShapeCommand(0, ShapeName.ELLIPSE, new Point(10, 10), new Point(500, 500));
            _model.MoveShapeByIndexCommand(0, 0, new Point(10, 10), new Point(100, 100));

            Assert.AreEqual(_model.ShapeList[0].Info, "(100,100),(500,500)");
        }

        //TestAddPageCommand
        [TestMethod()]
        public void TestAddPageCommand()
        {
            Shapes shapes2 = new Shapes();
            _model.AddPageCommand(0, shapes2);

            Assert.AreEqual(_model.PageIndex, 0);
            Assert.AreEqual(_model.PageList.Count(), 2);
            Assert.AreNotEqual(_model.Shapes, _mockShapes);
            Assert.AreEqual(_model.Shapes, shapes2);
            Assert.AreEqual(_model.PageList[1], _mockShapes);
        }

        //TestDeletePageCommand
        [TestMethod()]
        public void TestDeletePageCommand()
        {
            Shapes shapes2 = new Shapes();
            _model.AddPageCommand(0, shapes2);
            _model.DeletePageCommand(1);

            Assert.AreEqual(_model.PageIndex, 0);
            Assert.AreEqual(_model.PageList.Count(), 1);
            Assert.AreEqual(_model.Shapes, shapes2);
        }

        //TestNotifyPageDataChange
        [TestMethod()]
        public void TestNotifyPageDataChange()
        {
            _model.NotifyPageDataChange();
            Assert.AreEqual(_isPageDataChanged, true);
        }

        //TestChoosePage
        [TestMethod()]
        public void TestChoosePage()
        {
            _model.AddPage(0);
            _model.AddShape(ShapeName.RECTANGLE, new Point(0, 0), new Point(0, 0));
            _model.AddPage(2);
            _model.AddShape(ShapeName.ELLIPSE, new Point(0, 0), new Point(0, 0));

            _model.SetPageIndex(0);
            Assert.AreEqual(_model.Shapes.ShapeList[0].ShapeName, ShapeName.RECTANGLE);
            _model.SetPageIndex(1);
            Assert.AreEqual(_model.Shapes, _mockShapes);
            _model.SetPageIndex(2);
            Assert.AreEqual(_model.Shapes.ShapeList[0].ShapeName, ShapeName.ELLIPSE);
        }

        //TestAddPage
        [TestMethod()]
        public void TestAddPage()
        {
            _model.AddPage(0);
            _model.AddShape(ShapeName.RECTANGLE, new Point(0, 0), new Point(0, 0));
            Assert.AreEqual(_model.PageList.Count, 2);

            _model.AddPage(2);
            _model.AddShape(ShapeName.ELLIPSE, new Point(0, 0), new Point(0, 0));
            Assert.AreEqual(_model.PageList.Count, 3);

            _model.SetPageIndex(0);
            Assert.AreEqual(_model.Shapes.ShapeList[0].ShapeName, ShapeName.RECTANGLE);

            _model.SetPageIndex(1);
            Assert.AreEqual(_model.Shapes, _mockShapes);

            _model.SetPageIndex(2);
            Assert.AreEqual(_model.Shapes.ShapeList[0].ShapeName, ShapeName.ELLIPSE);
        }

        //TestSave
        [TestMethod()]
        public void TestSave()
        {
            _model.AddShape(ShapeName.LINE, new Point(1, 2), new Point(300, 400));
            _model.AddPage(1);
            _model.AddShape(ShapeName.ELLIPSE, new Point(300, 400), new Point(500, 600));
            _model.AddPage(2);
            _model.AddShape(ShapeName.RECTANGLE, new Point(500, 600), new Point(1500, 700));
            _model.AddPage(0);
            _model.Save();
            Assert.IsTrue(true);
        }

        //TestLoad
        [TestMethod()]
        public void TestLoad()
        {
            _model.Load();
            Assert.AreEqual(_model.PageList[0].ShapeList.Count, 0);
            Assert.AreEqual(_model.PageList[1].ShapeList.Count, 1);
            Assert.AreEqual(_model.PageList[1].ShapeList[0].ShapeName, ShapeName.LINE);
            Assert.AreEqual(_model.PageList[1].ShapeList[0].Info, "(1,2),(300,400)");
            Assert.AreEqual(_model.PageList[2].ShapeList.Count, 1);
            Assert.AreEqual(_model.PageList[2].ShapeList[0].ShapeName, ShapeName.ELLIPSE);
            Assert.AreEqual(_model.PageList[2].ShapeList[0].Info, "(300,400),(500,600)");
            Assert.AreEqual(_model.PageList[3].ShapeList.Count, 1);
            Assert.AreEqual(_model.PageList[3].ShapeList[0].ShapeName, ShapeName.RECTANGLE);
            Assert.AreEqual(_model.PageList[3].ShapeList[0].Info, "(500,600),(1500,700)");
        }
    }
}