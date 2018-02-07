using System;
using System.Collections.Generic;
using System.Text;

namespace Mux
{
    public abstract class Store
    {
        private string mStoreID;
        private Dispatcher dispatcher;
        private List<IStoreListener> listeners;

        public Store()
        {
            System.Diagnostics.Debug.WriteLine("Creating store object");
            mStoreID = System.Guid.NewGuid().ToString();
            dispatcher = Dispatcher.GetInstance();
            dispatcher.Register(mStoreID, this);
            listeners = new List<IStoreListener>();
        }

        ~Store()
        {
            System.Diagnostics.Debug.WriteLine("Deleting store object");
            dispatcher.Unregister(mStoreID);
        }

        public void AddStoreListener(IStoreListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveStoreListener(IStoreListener listener)
        {
            listeners.Remove(listener);
        }

        public abstract void OnDispatch<T>(Payload<T> payload) where T : IState;

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
