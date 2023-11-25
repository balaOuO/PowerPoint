using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class ButtonStateTests
    {
        string _propertyName;

        //Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _propertyName = string.Empty;
        }

        //TestButtonState
        [TestMethod()]
        public void TestButtonState()
        {
            ButtonState buttonState;

            buttonState = new ButtonState(false);
            Assert.AreEqual(buttonState.State, false);

            buttonState = new ButtonState(true);
            Assert.AreEqual(buttonState.State, true);
        }

        //TestResetState
        [TestMethod()]
        public void TestResetState()
        {
            ButtonState buttonState;

            buttonState = new ButtonState(false);
            buttonState.ResetState();
            Assert.AreEqual(buttonState.State, false);

            buttonState = new ButtonState(true);
            buttonState.ResetState();
            Assert.AreEqual(buttonState.State, false);
        }

        //TestSetState
        [TestMethod()]
        public void TestSetState()
        {
            ButtonState buttonState;

            buttonState = new ButtonState(false);
            buttonState.PropertyChanged += GetNotifyPropertyName;
            buttonState.State = true;
            Assert.AreEqual(_propertyName, "State");

            Initialize();
            buttonState = new ButtonState(true);
            buttonState.PropertyChanged += GetNotifyPropertyName;
            buttonState.State = false;
            Assert.AreEqual(_propertyName, "State");
        }

        //GetNotifyPropertyName
        public void GetNotifyPropertyName(object nothing, PropertyChangedEventArgs e)
        {
            _propertyName = e.PropertyName;
        }
    }
}