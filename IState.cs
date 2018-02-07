using System;
using System.Collections.Generic;
using System.Text;

namespace Mux
{
    /*
     * Implementing classes of this interface will be where your data is
     * stored. Because objects of this class will always be wrapped by
     * either a Store or Payload, properties of this class can (and should)
     * be public. That way the wrapping class can control access to this
     * objects properties.
     * 
     * Objects of this class should be pure state-holders, with no methods.
     * The wrapping Store class should control how the properties are 
     * modified and distributed to the listeners.
     */
    public interface IState
    {
    }
}
