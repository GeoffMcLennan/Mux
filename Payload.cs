using System;
using System.Collections.Generic;
using System.Text;

namespace Mux
{
    public abstract class Payload
    {
        private string actionName;
        private Dispatcher dispatcher;

        public Payload(String name)
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
