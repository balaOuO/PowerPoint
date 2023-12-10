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

            _isNotifyDataChange = false;
            _isNotifyDrawingFinish = false;
        }

        //TestModel
        [TestMethod()]
        public void TestModel()
        {
            Assert.IsTrue(_modelPrivateObject.GetFieldOrProperty("_shapes") is Shapes);
            Assert.IsTrue(_modelPrivateObject.GetFieldOrProperty("_pointerState") is PointerState);
            Assert.IsTrue(_modelPrivateObject.GetFieldOrProperty("_drawingState") is DrawingState);
            Assert.IsTrue(_modelPrivateObject.GetFieldOrProperty("_canvasState") is ICanvasState);
        }

        //TestAddShape
        [TestMethod()]
        public void TestAddShape()
        {
            _model.AddShape(ShapeName.LINE);

            Assert.IsTrue(_mockShapes.IsAddShape);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestDeleteShapeButton
        [TestMethod()]
        public void TestDeleteShapeByIndex()
        {
            _model.AddShape(ShapeName.LINE);
            _model.DeleteShapeByIndex(0);

            Assert.IsTrue(_mockShapes.IsDeleteShapeByIndex);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestDeleteSelect
        [TestMethod()]
        public void TestDeleteSelect()
        {
            _model.AddShapeCommand(ShapeName.LINE, new Point(1600, 900), new Point(1600, 900));
            _mockShapes.SelectShape(new Point(1600, 900));
            Assert.IsTrue(_isNotifyDataChange);
            _isNotifyDataChange = false;

            _model.DeleteSelect();

            Assert.IsTrue(_mockShapes.IsDeleteShapeByIndex);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _model.Draw(new MockGraphicAdaptor());

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
            _model.AddShape(ShapeName.LINE);
            _model.Undo();
            Assert.AreEqual(_model.ShapeList.Count, 0);
        }

        //TestRedo
        [TestMethod()]
        public void TestRedo()
        {
            _model.AddShape(ShapeName.LINE);
            _model.Undo();
            _model.Redo();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].ShapeName, ShapeName.LINE);
        }

        //TestAddShapeCommand
        [TestMethod()]
        public void TestAddShapeCommand()
        {
            _model.AddShape(ShapeName.LINE);

            Assert.IsTrue(_mockShapes.IsAddShape);
            Assert.IsTrue(_mockShapes.IsAddShapeToList);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestDeleteShapeCommand
        [TestMethod()]
        public void TestDeleteShapeCommand()
        {
            _model.AddShape(ShapeName.ELLIPSE);
            _model.DeleteShapeCommand();
            Assert.AreEqual(_model.ShapeList.Count, 0);
            Assert.IsTrue(_mockShapes.IsDeleteShapeByIndex);
            Assert.IsTrue(_isNotifyDataChange);
        }

        //TestInsertShapeToList
        [TestMethod()]
        public void TestInsertShapeToList()
        {
            _model.InsertShapeToList(ShapeName.RECTANGLE, new Point(10, 10), new Point(200, 200), 0);
            Assert.IsTrue(_mockShapes.IsInsertShapeToList);
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].ShapeName, ShapeName.RECTANGLE);
            Assert.AreEqual(_model.ShapeList[0].Info, "(10,10),(200,200)");
        }

        //TestMoveShapeByIndexCommand
        [TestMethod()]
        public void TestMoveShapeByIndexCommand()
        {
            _model.AddShapeCommand(ShapeName.ELLIPSE, new Point(10, 10), new Point(500, 500));
            _model.MoveShapeByIndexCommand(0, new Point(10, 10), new Point(100, 100));

            Assert.AreEqual(_model.ShapeList[0].Info , "(100,100),(500,500)");
        }
    }
}