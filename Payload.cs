using System;
using System.Collections.Generic;
using System.Text;

namespace Mux
{
    public abstract class Payload<T> where T : IState
    {
        private string actionName;
        private Dispatcher dispatcher;
        public T State;

        public Payload(string name)
        {
            actionName = name;
            dispatcher = Dispatcher.GetInstance();
        }

        public string GetActionName()
        {
            return actionName;
        }

        public void Dispatch()
        {
            dispatcher.Dispatch(this);
        }
    }
}
