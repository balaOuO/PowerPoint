using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public interface CanvasState
    {
        //press method
        void Press(Point pointer);

        //move method
        void Move(Point pointer);

        //release method
        void Release();

        //get Cursor State
        Cursor GetCursorState();
    }
}
