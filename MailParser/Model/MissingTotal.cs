using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailParser
{
    public class MissingTotal : IStepParameter
    {
        public bool IsFinalStep => true;

        public string GetMessage()
        {
            return "Total field missing";
        }
    }
}
