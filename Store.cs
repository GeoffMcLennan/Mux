using System;
using System.Collections.Generic;
using System.Text;

namespace Mux
{
    /*
     * A class implementing this interface should be created for every
     * IState implementing class. This store will be subscribed to the 
     * Dispatcher and listen for any actions that apply to it. It should
     * use those actions to update its internal state object (IState).
     * 
     * Implementing classes should be a singleton. This can be achieved
     * by making your default constructor private and creating a 
     * static GetInstance method that creates/returns a reference to a 
     * static store object.
     * 
     * Every time this state is updated, it should call the 
     * Store::OnStoreChange() method which will update all listeners
     * subscribed to this store with the new data.
     * 
     * This class should also provide getters for all of its state 
     * properties. 
     */
    public abstract class Store
    {
        private string mStoreID;
        private Dispatcher dispatcher;
        private List<IStoreListener> listeners;

        /*
         * Registers this store with the dispatcher and initializes an
         * empty list of listeners.
         */ 
        public Store()
        {
            mStoreID = System.Guid.NewGuid().ToString();
            dispatcher = Dispatcher.GetInstance();
            dispatcher.Register(mStoreID, this);
            listeners = new List<IStoreListener>();
        }

        /*
         * Unregisters the store with the dispatcher.
         */ 
        ~Store()
        {
            dispatcher.Unregister(mStoreID);
        }

        /*
         * Registers a listener to be updated when this store changes.
         */
        public void AddStoreListener(IStoreListener listener)
        {
            listeners.Add(listener);
        }

        /*
         * Unregisters a registered store listener.
         */
        public void RemoveStoreListener(IStoreListener listener)
        {
            listeners.Remove(listener);
        }

        /*
         * Method that is called when the dispatcher recieves an action.
         * Should check to see if the action is relevant to its state, and
         * if so udpate its state and notify all listeners of a change.
         */ 
        public abstract void OnDispatch<T>(Payload<T> payload) where T : IState;

        /*
         * Should be called by the OnDispatch method when the stores state
         * is changed.
         * 
         * Updates all listeners that there is a change of state.
         */ 
        public void OnStoreChange()
        {
            foreach (IStoreListener listener in listeners)
            {
                try
                {
                    listener.OnStoreChange();
                } catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
