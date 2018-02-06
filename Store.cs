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

        public abstract void OnDispatch(Payload payload);
    }
}
