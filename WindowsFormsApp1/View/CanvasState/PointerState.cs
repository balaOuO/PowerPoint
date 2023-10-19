using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    class PointerState : CanvasState
    {
        private PresentationModel _presentationModel;
        public PointerState(PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
        }

        //press method
        public void Press(Point pointer)
        {
            
        }

        //move method
        public void Move(Point pointer)
        {
            
        }

        //release method
        public void Release()
        {
            
        }

        //Get Cursor State
        public Cursor GetCursorState()
        {
            return Cursors.Default;
        }
    }
}
