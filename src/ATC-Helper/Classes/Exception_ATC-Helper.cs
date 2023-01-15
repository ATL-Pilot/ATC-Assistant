using System;

namespace ATC_Helper.Classes
{
    internal class Exception_ATC_Helper : Exception
    {
        private string _SourceMethod;
        public string SourceMethod { get { return _SourceMethod; } set { _SourceMethod = value; } }

        private Exception _OriginalException;
        public Exception Exception { get { return _OriginalException; } set { _OriginalException = value; } }

        public Exception_ATC_Helper(string source, Exception originalException)
        {
            _SourceMethod = source;
            _OriginalException = originalException;
        }

    }
}
