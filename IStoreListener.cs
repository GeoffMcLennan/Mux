using System;
using System.Collections.Generic;
using System.Text;

namespace Mux
{
    /*
     * Implementing classes of this interface have objects that wish
     * to be updated when the state of the store changes.
     * 
     * When an object is created it should subscribe to the store (usually
     * in the constructor) by passing itself to the 
     * Store::AddStoreListener() method.
     * 
     * When the object is no longer used or garbage collected it needs to
     * be unsubscribed from the store (i.e. in a finalizer) otherwise it 
     * will leave a null reference. This can be done by passing itself to 
     * the Store::RemoveStoreListener() method. 
     */
    public interface IStoreListener
    {
        void OnStoreChange();
    }
}
