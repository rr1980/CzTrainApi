using System;
using System.Collections.Generic;
using System.Text;

namespace CzTrainApi.Common.Exceptions
{
    public class IdNotFoundException<T> : Exception
    {
        public IdNotFoundException(long id) : base("ID '" + id + "' not found for '" + typeof(T).Name + "'")
        {

        }
    }
}
