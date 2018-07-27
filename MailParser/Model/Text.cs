using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailParser
{
    public class Text : IStepParameter
    {
        public string Message { get; set; }

        public bool IsFinalStep => false;

        public string GetMessage()
        {
            return Message;
        }
    }
}
