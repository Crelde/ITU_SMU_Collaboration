using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /*
     * This class was supposed to contain our own custom exceptions
     * But as i thought abit more about it i dont really think we will need any custom exceptions
     * In case i missed something ill leave it here for abit, in case we do need to make some
     */
    public class Exceptions 
    {
        [Serializable]
        public class UserAlreadyExistsException : Exception
        {
            public UserAlreadyExistsException() { }
            public UserAlreadyExistsException(string msg) { }
        }

        // Can be user/item or anything in the database
        [Serializable]
        public class EntryNotFoundException : Exception
        {
            public EntryNotFoundException() { }
            public EntryNotFoundException(string msg) { }
        }

    }
}
