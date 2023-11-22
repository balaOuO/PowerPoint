using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ModelObject.State
{
    public interface ICanvasState
    {
        //press method
        void Press(Point pointer);

        //move method
        void Move(Point pointer);

        //release method
        void Release();

        //GetStateName
        string GetStateName();
    }
}
