using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1.ModelObject.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1Tests1;
using WindowsFormsApp1;

namespace WindowsFormsApp1.ModelObject.State.Tests
{
    [TestClass()]
    public class DrawingStateTests
    {
        Model _model;
        MockShapes _mockShapes;
        ICanvasState _canvasState;
        bool _isDrawingFinish;
        bool _isNotifyDataChange;
        PrivateObject _canvasStatePrivateObject;

        //HandleShapeDataChanged
        public void HandleShapeDataChanged()
        {
            _isNotifyDataChange = true;
        }

        //HandleDrawingFinish
        public void HandleDrawingFinish()
        {
            _isDrawingFinish = true;
        }

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _isNotifyDataChange = false;
            _isDrawingFinish = false;

            _model = new Model();
            _mockShapes = new MockShapes();

            _model.Shapes = _mockShapes;
            _model._shapeDataChanged += HandleShapeDataChanged;
            _model._drawingFinish += HandleDrawingFinish;

            _canvasState = new DrawingState(_model);
            _canvasStatePrivateObject = new PrivateObject(_canvasState);
        }

        //TestDrawingState
        [TestMethod()]
        public void TestDrawingState()
        {
            Assert.AreEqual((Model)_canvasStatePrivateObject.GetFieldOrProperty("_model"), _model);
        }

        //TestGetStateName
        [TestMethod()]
        public void TestGetStateName()
        {
            Assert.AreEqual(_canvasState.GetStateName(), "DrawingState");
        }

        //TestMove
        [TestMethod()]
        public void TestMove()
        {
            _canvasState.Move(new Point(40, 50));
            Assert.IsFalse(_isNotifyDataChange);
            Assert.IsFalse(_mockShapes.IsModifyShape);
            Assert.IsFalse((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));

            Initialize();
            _canvasState.Press(new Point(4, 5));
            _isNotifyDataChange = false;
            _mockShapes.IsModifyShape = false;
            _canvasState.Move(new Point(40, 50));
            Assert.IsTrue(_isNotifyDataChange);
            Assert.IsTrue(_mockShapes.IsModifyShape);
            Assert.IsTrue((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
        }

        //TestPress
        [TestMethod()]
        public void TestPress()
        {
            _canvasState.Press(new Point(4, 5));
            Assert.IsTrue(_isNotifyDataChange);
            Assert.IsTrue(_mockShapes.IsAddShape);
            Assert.IsTrue((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
            Assert.AreEqual(_mockShapes.AddShapeInput, "(4,5),(4,5)");

            Initialize();
            _canvasState.Press(new Point(4, 5));
            _isNotifyDataChange = false;
            _mockShapes.IsAddShape = false;
            _canvasState.Press(new Point(7, 8));
            Assert.IsFalse(_isNotifyDataChange);
            Assert.IsFalse(_mockShapes.IsAddShape);
            Assert.IsTrue((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
            Assert.AreEqual(_mockShapes.AddShapeInput, "(4,5),(4,5)");
        }

        //TestRelease
        [TestMethod()]
        public void TestRelease()
        {
            _canvasState.Release();
            Assert.IsFalse(_isNotifyDataChange);
            Assert.IsFalse(_mockShapes.IsAddShape);
            Assert.IsFalse(_isDrawingFinish);
            Assert.IsFalse((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));

            Initialize();
            _canvasState.Press(new Point(4, 5));
            _canvasState.Move(new Point(40, 50));
            _isNotifyDataChange = false;
            _canvasState.Release();
            Assert.IsTrue(_isNotifyDataChange);
            Assert.IsTrue(_mockShapes.IsAddShapeToList);
            Assert.IsTrue(_isDrawingFinish);
            Assert.IsFalse((bool)_canvasStatePrivateObject.GetFieldOrProperty("_isPress"));
        }
    }
}