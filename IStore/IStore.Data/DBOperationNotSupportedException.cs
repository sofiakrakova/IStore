using System;

namespace IStore.Data
{
    internal class DBOperationNotSupportedException : NotSupportedException
    {
        public DBOperationNotSupportedException() : base(message: "This operation cannot be invoked from code behind.") { }
    }
}
