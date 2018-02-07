using System;
using System.Collections.Generic;
using System.Text;

namespace Mux
{
    /*
     * Objects of this type are what the Dispatcher sends to all subscribed
     * stores. When creating an object of this type, an ActionName must
     * be passed to this constructor. This ActionName must be unique within
     * all possible ActionNames in the scope of the Dispatcher.
     * 
     * Instead of creating a custom object for every Action/Payload sent 
     * to the Dispatcher, it is recommended to use a sort of Factory 
     * pattern. For each action to be dispatched, create a static method
     * that generates a custom object using a const ActionName and
     * dispatches it.
     * 
     * Note that although the State is public, it is not recommended that
     * it is modified by any store that receives it as this could cause 
     * unexpected behaviour. The state properties should be set only in its 
     * static factory method and read by stores.
     */
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
