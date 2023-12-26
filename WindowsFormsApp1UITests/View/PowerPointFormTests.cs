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

        //Mapping
        public Point Mapping(Point point)
        {
            const double WIDTH = 1600;
            const double HEIGHT = 900;
            int width = _driver.FindElementByAccessibilityId("_canvas").Size.Width;
            int height = _driver.FindElementByAccessibilityId("_canvas").Size.Height;
            return new Point((int)((double)point.X / WIDTH * (double)width), (int)((double)point.Y / HEIGHT * (double)height));
        }

        //Draw
        public void Draw(string shapeType , Point startPoint , Point endPoint)
        {
            Point newStartPoint = Mapping(startPoint);
            Point newEndPoint = Mapping(endPoint);

            _driver.FindElementByName(shapeType).Click();

            int x = _driver.FindElementByAccessibilityId("_canvas").LocationOnScreenOnceScrolledIntoView.X;
            int y = _driver.FindElementByAccessibilityId("_canvas").LocationOnScreenOnceScrolledIntoView.Y;
            int width = _driver.FindElementByAccessibilityId("_canvas").Size.Width;
            int height = _driver.FindElementByAccessibilityId("_canvas").Size.Height;

            _actions.MoveToElement(_driver.FindElementByAccessibilityId("_canvas")).Perform();
            //_actions.MoveByOffset(-1 * width / 2, -1 * height / 2).Perform();
            //_actions.MoveByOffset((int)newStartPoint.X, (int)newStartPoint.Y).Perform();
            _actions.ClickAndHold().Perform();
            _actions.MoveByOffset(-1 * width / 2, -1 * height / 2).Perform();
            //_actions.MoveByOffset((int)(newEndPoint.X - newStartPoint.X), (int)(newEndPoint.Y - newStartPoint.Y)).Perform();
            _actions.Release().Perform();
            _robot.Sleep(5);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 1);
            _robot.AssertDataGridViewRowDataBy("_shapeList", 0,new string[]{"刪除" , ShapeName.RECTANGLE , string.Format("({0},{1}),({2},{3})", startPoint.X, startPoint.Y, endPoint.X, endPoint.Y) });
        }

        //TestDraw
        [TestMethod]
        public void TestDraw()
        {
            Draw("☐" , new Point(200,100) , new Point(400, 225));
        }

        List<string> Key = new List<string>()
        {
            Keys.NumberPad0,Keys.NumberPad1,Keys.NumberPad2,Keys.NumberPad3,Keys.NumberPad4,Keys.NumberPad5,Keys.NumberPad6,Keys.NumberPad7,Keys.NumberPad8,Keys.NumberPad9
        };

        //AddShape
        public void AddShape(string shapeType , string startX , string startY , string endX , string endY)
        {
            int dataCount = _robot.DataGridViewCount("_shapeList");
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
            _robot.AssertDataGridViewRowDataBy("_shapeList", dataCount + 1, new string[] { "刪除", shapeType, string.Format("({0},{1}),({2},{3})" , startX , startY , endX , endY) });
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
        [TestMethod()]
        public void TestAddDeleteShape()
        {
            AddShape(ShapeName.ELLIPSE , "10" , "10" , "100" , "200");
            _robot.DeletDataGridView("_shapeList", 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);

            AddShape(ShapeName.RECTANGLE, "100", "200", "500", "600");
            _robot.DeletDataGridView("_shapeList", 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);

            AddShape(ShapeName.LINE, "1500", "850", "357", "44");
            _robot.DeletDataGridView("_shapeList", 0);
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);
        }

        //TestUndoRedo
        [TestMethod()]
        public void TestUndoRedo()
        {
            AddShape(ShapeName.LINE, "100", "700", "3", "200");
            _driver.FindElementByName("↩︎").Click();
            _robot.AssertDataGridViewRowCountBy("_shapeList", 0);
            _driver.FindElementByName("↪︎").Click();
            _robot.AssertDataGridViewRowDataBy("_shapeList", 0, new string[] { "刪除", ShapeName.LINE, "(100,700),(3,200)" });
        }

        //TestAddPage
        [TestMethod()]
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
        [TestMethod()]
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
        [TestMethod()]
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
    }
}