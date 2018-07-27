using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailParser
{
    public class XmlTagList : List<XmlTag>, IStepParameter
    {

        private bool _isFinalStep = false;
        public XmlTagList(IEnumerable<XmlTag> xmlTags, bool isFinalStep = false) : base(xmlTags)
        {
            _isFinalStep = isFinalStep;
        }
        public XmlTagList(bool isFinalStep = false) : base()
        {
            _isFinalStep = isFinalStep;
        }

        public bool IsFinalStep => _isFinalStep;

        public string GetMessage()
        {
            var stringBuilder = new StringBuilder();
            this.ForEach(tag =>
            {
                stringBuilder.Append($"{tag.Name}:{tag.Value}");
                stringBuilder.AppendLine();
            });
            return stringBuilder.ToString();
        }
    }
    public class XmlTag
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
