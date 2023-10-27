using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    public class ButtonState : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private bool _state;

        private const string STATE = "State";

        public ButtonState(bool state)
        {
            State = state;
        }

        public bool State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                Notify(STATE);
            }
        }

        //set state false
        public void ResetState()
        {
            State = false;
        }    

        //data binding notify method
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
