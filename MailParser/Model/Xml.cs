using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MailParser.Model
{
    public class Xml : IStepParameter
    {
        public XmlDocument Message { get; set; }

        public bool IsFinalStep => true;

        public string GetMessage()
        {
            return Message.OuterXml;
        }
    }
}
