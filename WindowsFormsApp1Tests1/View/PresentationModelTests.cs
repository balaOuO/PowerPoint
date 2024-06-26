﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1Tests1;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        Model _model = new Model(new MockGoogleDriveManager());
        PresentationModel _presentationModel;
        PrivateObject _presentationPrivateObject;

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _presentationModel = new PresentationModel(_model);
            _presentationPrivateObject = new PrivateObject(_presentationModel);
        }

        //TestPresentationModel
        [TestMethod()]
        public void TestPresentationModel()
        {
            Assert.AreEqual(_presentationPrivateObject.GetFieldOrProperty("_model"), _model);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState.Count, 4);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.LINE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, true);
        }

        //TestSetChooseShapeButton
        [TestMethod()]
        public void TestSetChooseShapeButton()
        {
            _presentationModel.SetChooseShapeButton(ShapeName.LINE);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.LINE].State, true);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, false);

            _presentationModel.SetChooseShapeButton(ShapeName.RECTANGLE);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.LINE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE].State, true);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, false);

            _presentationModel.SetChooseShapeButton(ShapeName.ELLIPSE);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.LINE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE].State, true);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, false);

            _presentationModel.SetChooseShapeButton(ShapeName.POINTER);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.LINE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, true);
        }

        //test cursor
        [TestMethod()]
        public void TestSetCursorState()
        {
            _presentationPrivateObject.Invoke("SetCursorState", new object[] { ShapePart.ELSE });
            Assert.AreEqual(_presentationModel.GetCursors(), Cursors.Default);

            _presentationPrivateObject.Invoke("SetCursorState", new object[] { ShapePart.LOWER_RIGHT_POINT });
            Assert.AreEqual(_presentationModel.GetCursors(), Cursors.SizeNWSE);

            _presentationPrivateObject.Invoke("SetCursorState", new object[] { ShapePart.UPPER_LEFT_POINT });
            Assert.AreEqual(_presentationModel.GetCursors(), Cursors.SizeNWSE);

            _presentationPrivateObject.Invoke("SetCursorState", new object[] { ShapePart.LOWER_LEFT_POINT });
            Assert.AreEqual(_presentationModel.GetCursors(), Cursors.SizeNESW);

            _presentationPrivateObject.Invoke("SetCursorState", new object[] { ShapePart.UPPER_RIGHT_POINT });
            Assert.AreEqual(_presentationModel.GetCursors(), Cursors.SizeNESW);
        }

        //TestGetCursors
        [TestMethod()]
        public void TestGetCursors()
        {
            _presentationModel.SetChooseShapeButton(ShapeName.LINE);
            Assert.AreEqual(_presentationModel.GetCursors(), Cursors.Cross);

            _presentationModel.SetChooseShapeButton(ShapeName.RECTANGLE);
            Assert.AreEqual(_presentationModel.GetCursors(), Cursors.Cross);

            _presentationModel.SetChooseShapeButton(ShapeName.ELLIPSE);
            Assert.AreEqual(_presentationModel.GetCursors(), Cursors.Cross);

            _presentationModel.SetChooseShapeButton(ShapeName.POINTER);
            Assert.AreEqual(_presentationModel.GetCursors(), Cursors.Default);
        }

        //TestInitializeChooseShapeButton
        [TestMethod()]
        public void TestInitializeChooseShapeButton()
        {
            _presentationModel.SetChooseShapeButton(ShapeName.LINE);
            _presentationPrivateObject.Invoke("InitializeChooseShapeButton");
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.LINE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, true);

            _presentationModel.SetChooseShapeButton(ShapeName.RECTANGLE);
            _presentationPrivateObject.Invoke("InitializeChooseShapeButton");
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.LINE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, true);

            _presentationModel.SetChooseShapeButton(ShapeName.ELLIPSE);
            _presentationPrivateObject.Invoke("InitializeChooseShapeButton");
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.LINE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, true);

            _presentationModel.SetChooseShapeButton(ShapeName.POINTER);
            _presentationPrivateObject.Invoke("InitializeChooseShapeButton");
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.LINE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.RECTANGLE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.ELLIPSE].State, false);
            Assert.AreEqual(_presentationModel.ChooseShapeButtonState[ShapeName.POINTER].State, true);
        }

        //TestChoosePage
        [TestMethod()]
        public void TestChoosePage()
        {
            _model.AddPage(0);
            _model.AddPage(0);
            _presentationModel.UpdatePageCheckList();
            _presentationModel.ChoosePage(2);
            Assert.AreEqual(_model.PageIndex, 2);
            Assert.AreEqual(_presentationModel.PageCheckList[0], false);
            Assert.AreEqual(_presentationModel.PageCheckList[1], false);
            Assert.AreEqual(_presentationModel.PageCheckList[2], true);

            _presentationModel.ChoosePage(1);
            Assert.AreEqual(_model.PageIndex, 1);
            Assert.AreEqual(_presentationModel.PageCheckList[0], false);
            Assert.AreEqual(_presentationModel.PageCheckList[1], true);
            Assert.AreEqual(_presentationModel.PageCheckList[2], false);

            _presentationModel.ChoosePage(0);
            Assert.AreEqual(_model.PageIndex, 0);
            Assert.AreEqual(_presentationModel.PageCheckList[0], true);
            Assert.AreEqual(_presentationModel.PageCheckList[1], false);
            Assert.AreEqual(_presentationModel.PageCheckList[2], false);
        }

        //TestUpdatePageCheckList
        [TestMethod()]
        public void TestUpdatePageCheckList()
        {
            Assert.AreEqual(_presentationModel.PageCheckList.Count, 1);
            _model.AddPage(0);
            _model.AddPage(0);
            _presentationModel.UpdatePageCheckList();
            Assert.AreEqual(_presentationModel.PageCheckList.Count, 3);
        }

        //TestResize
        [TestMethod()]
        public void TestResize()
        {
            Assert.AreEqual(PresentationModel.Resize(100, 20, 10), 200);
            Assert.AreEqual(PresentationModel.Resize(512, 128, 64), 1024);
            Assert.AreEqual(PresentationModel.Resize(77, 121, 11), 847);
            Assert.AreEqual(PresentationModel.Resize(171, 14, 266), 9);
        }

        //TestTransformPoint
        [TestMethod()]
        public void TestTransformPoint()
        {
            Assert.AreEqual(PresentationModel.TransformPoint(new Point(10, 10), new Point(20, 20)).ToString(), (new Point(800, 450)).ToString());
            Assert.AreEqual(PresentationModel.TransformPoint(new Point(5000, 5000), new Point(80000, 45000)).ToString(), (new Point(100, 100)).ToString());
            Assert.AreEqual(PresentationModel.TransformPoint(new Point(8, 10), new Point(40, 50)).ToString(), (new Point(320, 180)).ToString());
            Assert.AreEqual(PresentationModel.TransformPoint(new Point(10, 10), new Point(100, 100)).ToString(), (new Point(160, 90)).ToString());
        }

        //TestCalculateLocation
        [TestMethod()]
        public void TestCalculateLocation()
        {
            Assert.AreEqual(PresentationModel.CalculateLocation(400, 200), 100);
            Assert.AreEqual(PresentationModel.CalculateLocation(128, 64), 32);
            Assert.AreEqual(PresentationModel.CalculateLocation(2048, 2000), 24);
            Assert.AreEqual(PresentationModel.CalculateLocation(6543210, 123456), 3209877);
        }
    }
}