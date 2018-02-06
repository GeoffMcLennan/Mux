using System;
using System.Collections.Generic;
using System.Text;

namespace Mux
{
    /*
     * To avoid memory issues, make sure that before this object 
     * is garbage collected its reference in its store is removed
     */
    public interface IStoreListener
    {
        void OnStoreChange();
    }
}
