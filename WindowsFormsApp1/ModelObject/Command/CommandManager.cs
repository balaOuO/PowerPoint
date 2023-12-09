using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsFormsApp1
{
    public class CommandManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        const string IS_UNDO_ENABLED = "IsUndoEnabled";
        const string IS_REDO_ENABLE = "IsRedoEnabled";

        //Execute
        public void Execute(ICommand command)
        {
            command.Execute();
            Add(command);
        }

        //Add
        public void Add(ICommand command)
        {
            _undo.Push(command);
            _redo.Clear();
            Notify(IS_UNDO_ENABLED);
            Notify(IS_REDO_ENABLE);
        }

        //Undo
        public void Undo()
        {
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.RollBackExecute();
            Notify(IS_UNDO_ENABLED);
            Notify(IS_REDO_ENABLE);
        }

        //Redo
        public void Redo()
        {
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
            Notify(IS_UNDO_ENABLED);
            Notify(IS_REDO_ENABLE);
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }

        //data binding notify method
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
