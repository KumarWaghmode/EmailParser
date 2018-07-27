using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailParser
{
    public class MissingEndTag : IStepParameter
    {
        private readonly string _tagName;
        public MissingEndTag(string tagName)
        {
            _tagName = tagName;
        }

        public bool IsFinalStep => true;

        public string GetMessage()
        {
            return $"Closing tag missing for {_tagName}";
        }
    }
}
