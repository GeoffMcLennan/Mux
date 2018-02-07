using System;
using System.Collections.Generic;
using System.Text;

namespace Mux
{
    public class Dispatcher
    {
        /*
         * Dispatcher is a singleton. 
         * This class controls access to its single instance of itself.
         * Retrieve this common instance by calling the GetInstance() method.
         * Default constructor is private to prevent unauthorized Dispatcher creation.
         */
        private static Dispatcher sDispatcher;
        public static Dispatcher GetInstance()
        {
            if (sDispatcher == null)
            {
                sDispatcher = new Dispatcher();
            }
            return sDispatcher;
        }

        private Dictionary<string, Store> mStores;

        private Dispatcher()
        {
            mStores = new Dictionary<string, Store>();
        }

        /*
         * Register/Unregister stores with the dispatcher.
         * Callback for all registered stores will be called when an action is dispatched.
         */
        public void Register(string id, Store store)
        {
            mStores.Add(id, store);
        }

        public void Unregister(string id)
        {
            mStores.Remove(id);
        }

        public void Dispatch<T>(Payload<T> payload) where T : IState
        {
            foreach (Store s in mStores.Values)
            {
                try
                {
                    s.OnDispatch(payload);
                } catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
        }

    }
}
