using System;

namespace Snooker
{
    public class ExamException : Exception
    {
        public ExamException(string msg)
            : base(String.Format("Valami elromlott: {0}", msg))
        {
        }
    }
}
