using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailParser
{
    public class XmlValidator : Steps<XmlTagList, IStepParameter>
    {
        public override IStepParameter Execute(XmlTagList input)
        {
            if (input.Exists(tag => tag.Name == "total"))
            {
                if (input.Exists(tag => tag.Name == "cost_centre") == false)
                {
                    input.Add(new XmlTag() { Name = "cost_center", Value = "UNKNOWN" });
                }
                return new XmlTagList(input, true);
            }
            return new MissingTotal();
        }


    }
}
