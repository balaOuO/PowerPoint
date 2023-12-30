using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1UITests;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using OpenQA.Selenium.Interactions;
using System.Windows.Automation;
using OpenQA.Selenium.Remote;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class PowerPointFormTests
    {
        private string targetAppPath;
        private const string MAIN_FORM = "Form1";
        private Robot _robot;
        private WindowsDriver<WindowsElement> _driver;
        RemoteTouchScreen _touchScreen;
        Actions _actions;
        string _templateString;

        //https://kkboxsqa.wordpress.com/2019/03/10/windows-automation-with-winappdriver/
        // init
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "WindowsFormsApp1";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "WindowsFormsApp1.exe");
            _robot = new Robot(targetAppPath, MAIN_FORM);
            _driver = _robot.Driver;
            _touchScreen = new RemoteTouchScreen(_driver);
            _actions = new Actions(_driver);
        }

        //Cleanup
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        //TransformPoint
        public Point TransformPoint(Point point)
        {
            return new Point((point.X / _driver.FindElementByAccessibilityId("_canvas").Size.Width) * ScreenSize.WIDTH, (point.Y / _driver.FindElementByAccessibilityId("_canvas").Size.Height) * ScreenSize.HEIGHT);
        }

        //Mapping
        public Point Mapping(Point point)
        {
            const double WIDTH = ScreenSize.WIDTH;
            const double HEIGHT = ScreenSize.HEIGHT;
            int width = _driver.FindElementByAccessibilityId("_canvas").Size.Width;
            int height = _driver.FindElementByAccessibilityId("_canvas").Size.Height;
            return new Point((int) ((double)point.X / WIDTH * (double)width), (int) ((double)point.Y / HEIGHT * (double)height));
        }

        //DoubleTranspose
        public Point DoubleTranspose(Point point)
        {
            return TransformPoint(Mapping(point));
        }

        Dictionary<string, string> ShapeNameToButton = new Dictionary<string, string>()
        {
            {ShapeName.RECTANGLE , "☐"},
            {ShapeName.ELLIPSE , "○"},
            {ShapeName.LINE ,"╱"}
        };

        //Draw
        public void Draw(string shapeType, Point startPoint, Point endPoint , int index)
        {
            Point newStartPoint = Mapping(startPoint);
            Point newEndPoint = Mapping(endPoint);

            _driver.FindElementByName(ShapeNameToButton[shapeType]).Click();

            int x = _driver.FindElementByAccessibilityId("_canvas").Location.X;
            int y = _driver.FindElementByAccessibilityId("_canvas").Location.Y;
            x += 1;
            y += 1;

            Point InitialStartPoint = TransformPoint(newStartPoint);
            Point InitialEndPoint = TransformPoint(newEndPoint);

            _touchScreen.Down(x + (int)newStartPoint.X, y + (int)newStartPoint.Y);
            _touchScreen.Up(x + (int)newEndPoint.X, y + (int)newEndPoint.Y);
            _templateString = InitialStartPoint.ToString() + "," + InitialEndPoint.ToString();

            _robot.AssertDataGridViewRowDataBy("_shapeList", index, new string[] { "刪除", shapeType, _templateString });
        }

        //Move 
        public Point Move(Point startPoint, Point endPoint)
        {
            Point newStartPoint = Mapping(startPoint);
            Point newEndPoint = Mapping(endPoint);
            _driver.FindElementByName("➛").Click();
            int x = _driver.FindElementByAccessibilityId("_canvas").Location.X;
            int y = _driver.FindElementByAccessibilityId("_canvas").Location.Y;
            x += 1;
            y += 1;
            _touchScreen.Down(x + (int)newStartPoint.X, y + (int)newStartPoint.Y);
            _touchScreen.Up(x + (int)newEndPoint.X, y + (int)newEndPoint.Y);
            return new Point(TransformPoint(newEndPoint).X - TransformPoint(newStartPoint).X, TransformPoint(newEndPoint).Y - TransformPoint(newStartPoint).Y);
        }

        //TestDrawRectangle
        [TestMethod , Priority(1)]
        public void TestDrawRectangle()
        {
            Draw(ShapeName.RECTANGLE, new Point(100, 100), new Point(400, 400), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            Draw(ShapeName.RECTANGLE, new Point(500, 100), new Point(800, 400), 1);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 2);
            Draw(ShapeName.RECTANGLE, new Point(100, 500), new Point(400, 800), 2);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 3);
            Draw(ShapeName.RECTANGLE, new Point(500, 500), new Point(800, 800), 3);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 4);
        }

        //TestDrawEllipse
        [TestMethod, Priority(2)]
        public void TestDrawEllipse()
        {
            Draw(ShapeName.ELLIPSE, new Point(100, 100), new Point(400, 400), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            Draw(ShapeName.ELLIPSE, new Point(500, 100), new Point(900, 400), 1);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 2);
            Draw(ShapeName.ELLIPSE, new Point(100, 500), new Point(400, 900), 2);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 3);
            Draw(ShapeName.ELLIPSE, new Point(500, 500), new Point(1200, 800), 3);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 4);
        }

        //TestDrawLine
        [TestMethod, Priority(3)]
        public void TestDrawLine()
        {
            Draw(ShapeName.LINE, new Point(400, 100), new Point(100, 400), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            Draw(ShapeName.LINE, new Point(500, 100), new Point(800, 400), 1);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 2);
            Draw(ShapeName.LINE, new Point(400, 800), new Point(100, 500), 2);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 3);
            Draw(ShapeName.LINE, new Point(500, 800), new Point(800, 500), 3);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 4);
        }

        //TestModifyRectangle
        [TestMethod(), Priority(4)]
        public void TestModifyRectangle()
        {
            Draw(ShapeName.RECTANGLE, new Point(100, 100), new Point(400, 400), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            Move(new Point(400, 400), new Point(800, 800));
            _robot.AssertDataGridViewRowDataBy("_shapeList", 0, new string[] { "刪除", ShapeName.RECTANGLE, DoubleTranspose(new Point(100, 100)).ToString() + "," + DoubleTranspose(new Point(800, 800)).ToString() });
        }

        //TestModifyEllipse
        [TestMethod(), Priority(5)]
        public void TestModifyEllipse()
        {
            Draw(ShapeName.ELLIPSE, new Point(400, 400), new Point(800, 800), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            Move(new Point(800, 800), new Point(100, 100));
            _robot.AssertDataGridViewRowDataBy("_shapeList", 0, new string[] { "刪除", ShapeName.ELLIPSE, DoubleTranspose(new Point(400, 400)).ToString() + "," + DoubleTranspose(new Point(100, 100)).ToString() });
        }

        //TestModifyLine
        [TestMethod(), Priority(6)]
        public void TestModifyLine()
        {
            Draw(ShapeName.LINE, new Point(500, 800), new Point(800, 500), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            Move(new Point(800, 800), new Point(800, 100));
            _robot.AssertDataGridViewRowDataBy("_shapeList", 0, new string[] { "刪除", ShapeName.LINE, DoubleTranspose(new Point(500, 100)).ToString() + "," + DoubleTranspose(new Point(800, 500)).ToString() });
            Move(new Point(800, 500), new Point(100, 500));
            _robot.AssertDataGridViewRowDataBy("_shapeList", 0, new string[] { "刪除", ShapeName.LINE, DoubleTranspose(new Point(500, 100)).ToString() + "," + DoubleTranspose(new Point(100, 500)).ToString() });
        }

        //TestMove
        [TestMethod(), Priority(7)]
        public void TestMove()
        {
            Draw(ShapeName.RECTANGLE, new Point(100, 100), new Point(400, 400), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            Point offset = Move(new Point(200, 200), new Point(400, 400));
            Point answerStartPoint = new Point(DoubleTranspose(new Point(100, 100)).X + offset.X, DoubleTranspose(new Point(100, 100)).Y + offset.Y);
            Point answerEndPoint = new Point(DoubleTranspose(new Point(400, 400)).X + offset.X, DoubleTranspose(new Point(400, 400)).Y + offset.Y);
            _robot.AssertDataGridViewRowDataBy("_shapeList", 0, new string[] { "刪除", ShapeName.RECTANGLE, answerStartPoint.ToString() + "," + answerEndPoint.ToString() });
        }

        List<string> Key = new List<string>()
        {
            Keys.NumberPad0,Keys.NumberPad1,Keys.NumberPad2,Keys.NumberPad3,Keys.NumberPad4,Keys.NumberPad5,Keys.NumberPad6,Keys.NumberPad7,Keys.NumberPad8,Keys.NumberPad9
        };

        //AddShape
        public void AddShape(string shapeType , string startX , string startY , string endX , string endY , int rowIndex)
        {
            _driver.FindElementByName("開啟").Click();
            _driver.FindElementByName(shapeType).Click();
            _robot.ClickButton("_addShape");
            _robot.SwitchTo("AddShapeForm");
            _robot.AssertEnable("_okButton", false);
            _robot.InputText("_startXInput", MappingNumberToKey(startX));
            _robot.InputText("_startYInput", MappingNumberToKey(startY));
            _robot.InputText("_endXInput", MappingNumberToKey(endX));
            _robot.InputText("_endYInput", MappingNumberToKey(endY));
            _robot.AssertEnable("_okButton", true);
            _robot.ClickButton("_okButton");
            _robot.SwitchTo("Form1");
            _robot.AssertDataGridViewRowDataBy("_shapeList", rowIndex , new string[] { "刪除", shapeType, string.Format("({0},{1}),({2},{3})" , startX , startY , endX , endY) });
        }

        //MappingNumberToKey
        public string MappingNumberToKey(string number)
        {
            string result = "";
            int index;
            for (int i = 0; i < number.Length; i++)
            {
                if (int.TryParse(number[i].ToString(), out index))
                    result += Key[index];
                else
                    result += number[i];
            }
            return result;
        }

        //TestAddEllipse
        [TestMethod(), Priority(8)]
        public void TestAddDeleteShape()
        {
            AddShape(ShapeName.ELLIPSE , "10" , "10" , "100" , "200" , 0);
            _robot.DeletDataGridView("_shapeList", 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);

            AddShape(ShapeName.RECTANGLE, "100", "200", "500", "600", 0);
            _robot.DeletDataGridView("_shapeList", 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);

            AddShape(ShapeName.LINE, "1500", "850", "357", "44", 0);
            _robot.DeletDataGridView("_shapeList", 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);
        }

        //TestUndoRedo
        [TestMethod(), Priority(9)]
        public void TestUndoRedo()
        {
            AddShape(ShapeName.LINE, "100", "700", "3", "200", 0);
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);
            _driver.FindElementByName("↪︎").Click();
            _robot.AssertDataGridViewRowDataBy("_shapeList", 0, new string[] { "刪除", ShapeName.LINE, "(100,700),(3,200)" });
        }

        //TestAddPage
        [TestMethod(), Priority(10)]
        public void TestAddPage()
        {
            _robot.AssertDataGridViewRowCountBy("_pageList", 1);
            _driver.FindElementByName("📄").Click();
            _robot.AssertDataGridViewRowCountBy("_pageList", 2);
            _driver.FindElementByName("📄").Click();
            _robot.AssertDataGridViewRowCountBy("_pageList", 3);

            _robot.ClickButton("0");
            _actions.SendKeys(Keys.Delete).Perform();
            _robot.AssertDataGridViewRowCountBy("_pageList", 2);
            _robot.ClickButton("1");
            _actions.SendKeys(Keys.Delete).Perform();
            _robot.AssertDataGridViewRowCountBy("_pageList", 1);
            _robot.ClickButton("0");
            _actions.SendKeys(Keys.Delete).Perform();
            _robot.AssertDataGridViewRowCountBy("_pageList", 1);
        }

        //TestLeftSpliterResize
        [TestMethod(), Priority(11)]
        public void TestLeftSpliterResize()
        {
            int x = _driver.FindElementByAccessibilityId("_canvas").Location.X;
            int y = _driver.FindElementByAccessibilityId("_canvas").Location.Y;
            int width = _driver.FindElementByAccessibilityId("_canvas").Size.Width;
            int height = _driver.FindElementByAccessibilityId("_canvas").Size.Height;

            _touchScreen.Down(x - 1, y + height / 2);
            _robot.Sleep(0.1);
            _touchScreen.Up(x + width / 3, y + height / 2);

            width = _driver.FindElementByAccessibilityId("_canvas").Size.Width;
            height = _driver.FindElementByAccessibilityId("_canvas").Size.Height;
            Assert.AreEqual(width / height, 16 / 9);

            width = _driver.FindElementByAccessibilityId("0").Size.Width;
            height = _driver.FindElementByAccessibilityId("0").Size.Height;
            Assert.AreEqual(width / height, 16 / 9);
        }

        //TestLeftSpliterResize
        [TestMethod(), Priority(12)]
        public void TestRightSpliterResize()
        {
            int x = _driver.FindElementByAccessibilityId("_canvas").Location.X;
            int y = _driver.FindElementByAccessibilityId("_canvas").Location.Y;
            int width = _driver.FindElementByAccessibilityId("_canvas").Size.Width;
            int height = _driver.FindElementByAccessibilityId("_canvas").Size.Height;

            _touchScreen.Down(x + width + 1 , y + height / 2);
            _robot.Sleep(0.1);
            _touchScreen.Up(x + width / 3, y + height / 2);

            width = _driver.FindElementByAccessibilityId("_canvas").Size.Width;
            height = _driver.FindElementByAccessibilityId("_canvas").Size.Height;
            Assert.AreEqual(width / height, 16 / 9);

            width = _driver.FindElementByAccessibilityId("0").Size.Width;
            height = _driver.FindElementByAccessibilityId("0").Size.Height;
            Assert.AreEqual(width / height, 16 / 9);
        }

        //test modify window
        [TestMethod(), Priority(13)]
        public void TestModifyWindow()
        {
            int width;
            int height;

            _driver.Manage().Window.Maximize();

            width = _driver.FindElementByAccessibilityId("_canvas").Size.Width;
            height = _driver.FindElementByAccessibilityId("_canvas").Size.Height;
            Assert.AreEqual(width / height, 16 / 9);

            width = _driver.FindElementByAccessibilityId("0").Size.Width;
            height = _driver.FindElementByAccessibilityId("0").Size.Height;
            Assert.AreEqual(width / height, 16 / 9);
        }

        //test save
        [TestMethod(), Priority(14)]
        public void TestSaveLoad()
        {
            Draw(ShapeName.LINE, new Point(400, 100), new Point(100, 400), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);

            _driver.FindElementByName("save").Click();
            _robot.SwitchTo("MessageBox");
            _driver.FindElementByName("確定").Click();
            _robot.SwitchTo("Form1");

            Assert.AreEqual(_driver.FindElementByName("save").Enabled, false);
            Assert.AreEqual(_driver.FindElementByName("load").Enabled, false);
            _driver.FindElementByAccessibilityId("0").Click();
            Move(new Point(200, 200), new Point(200, 200));
            _actions.SendKeys(Keys.Delete).Perform();
            _robot.Sleep(10);

            _robot.SwitchTo("MessageBox");
            _driver.FindElementByName("確定").Click();
            _robot.SwitchTo("Form1");

            _driver.FindElementByName("load").Click();
            _robot.SwitchTo("MessageBox");
            _driver.FindElementByName("確定").Click();
            _robot.SwitchTo("Form1");
            _robot.Sleep(5);

            _driver.FindElementByAccessibilityId("0").Click();
            _robot.AssertDataGridViewRowDataBy("_shapeList", 0, new string[] { "刪除", ShapeName.LINE, _templateString});
        }

        //TestIntegration
        [TestMethod(), Priority(14)]
        public void TestIntegration()
        {
            //draw wrong
            Draw(ShapeName.RECTANGLE, new Point(100, 100), new Point(200, 200), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            Move(new Point(200, 200), new Point(300, 300));
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);

            //draw head and body
            Draw(ShapeName.ELLIPSE, new Point(100, 100), new Point(200, 200), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            Move(new Point(200, 200), new Point(400, 400));
            Draw(ShapeName.ELLIPSE, new Point(100, 100), new Point(500, 500), 1);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 2);
            Move(new Point(200, 200), new Point(500, 500));
            Move(new Point(200, 200), new Point(550, 200));

            //draw left eye
            Draw(ShapeName.RECTANGLE, new Point(200, 200), new Point(250, 250), 2);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 3);
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 2);
            Draw(ShapeName.RECTANGLE, new Point(400, 200), new Point(450, 250), 2);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 3);
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 2);
            Draw(ShapeName.RECTANGLE, new Point(500, 200), new Point(550, 250), 2);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 3);

            //draw right eye
            AddShape(ShapeName.RECTANGLE, "600", "200", "650", "250", 3);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 4);
            Move(new Point(625, 225), new Point(675, 225));

            //draw left hand
            AddShape(ShapeName.LINE, "200", "400", "400", "600", 4);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 5);

            //draw right hand
            Draw(ShapeName.LINE, new Point(800, 600), new Point(1000, 400), 5);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 6);
            Move(new Point(1000, 400), new Point(1000, 800));
            _driver.FindElementByName("↩︎").Click();
            _driver.FindElementByName("↪︎").Click();

            //save
            _driver.FindElementByName("save").Click();
            _robot.SwitchTo("MessageBox");
            _driver.FindElementByName("確定").Click();
            _robot.SwitchTo("Form1");

            Assert.AreEqual(_driver.FindElementByName("save").Enabled, false);
            Assert.AreEqual(_driver.FindElementByName("load").Enabled, false);
            _robot.AssertDataGridViewRowCountBy("_pageList", 1);
            _driver.FindElementByName("📄").Click();
            _robot.AssertDataGridViewRowCountBy("_pageList", 2);
            _robot.Sleep(0.5);
            _driver.FindElementByAccessibilityId("0").Click();
            _robot.Sleep(0.5);
            _driver.FindElementByAccessibilityId("1").Click();
            Draw(ShapeName.LINE, new Point(100, 100), new Point(100, 800), 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            _driver.Manage().Window.Maximize();

            //wait save finish
            _robot.Sleep(10);
            _robot.SwitchTo("MessageBox");
            _driver.FindElementByName("確定").Click();
            _robot.SwitchTo("Form1");

            //draw page 2
            //draw H
            Draw(ShapeName.LINE, new Point(100, 450), new Point(300, 450), 1);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 2);

            Draw(ShapeName.LINE, new Point(300, 100), new Point(300, 800), 2);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 3);

            //delete page 1
            _driver.FindElementByAccessibilityId("1").Click();
            _robot.Sleep(0.5);
            _actions.SendKeys(Keys.Delete).Perform();
            _driver.FindElementByName("↩︎").Click();
            _driver.FindElementByAccessibilityId("0").Click();
            _actions.SendKeys(Keys.Delete).Perform();
            _robot.AssertDataGridViewRowCountBy("_pageList", 1);

            //Draw I
            Draw(ShapeName.ELLIPSE, new Point(600, 100), new Point(800, 300), 3);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 4);
            Draw(ShapeName.RECTANGLE, new Point(600, 400), new Point(800, 800), 4);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 5);

            //Load
            _driver.FindElementByName("load").Click();
            _robot.SwitchTo("MessageBox");
            _driver.FindElementByName("確定").Click();
            _robot.SwitchTo("Form1");
            _robot.Sleep(5);

            //check
            _driver.FindElementByAccessibilityId("0").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 6);

            //delete snowman on screen
            Move(new Point(500, 200), new Point(500, 200));
            _actions.SendKeys(Keys.Delete).Perform();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 5);

            Move(new Point(500, 500), new Point(500, 500));
            _actions.SendKeys(Keys.Delete).Perform();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 4);

            _robot.DeletDataGridView("_shapeList", 1);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 3);

            _robot.DeletDataGridView("_shapeList", 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 2);

            _robot.DeletDataGridView("_shapeList", 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);

            _robot.DeletDataGridView("_shapeList", 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);

            _robot.Sleep(1);

            Assert.AreEqual(_driver.FindElementByName("↩︎").Enabled, true);
            Assert.AreEqual(_driver.FindElementByName("↪︎").Enabled, false);

            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 2);
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 3);
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 4);
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 5);
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 6);

            Assert.AreEqual(_driver.FindElementByName("↩︎").Enabled, false);
            Assert.AreEqual(_driver.FindElementByName("↪︎").Enabled, true);
        }
    }
}