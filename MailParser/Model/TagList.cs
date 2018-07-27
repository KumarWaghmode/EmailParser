using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailParser
{
    public class TagList : List<Tag>, IStepParameter
    {
        public TagList(IEnumerable<Tag> list) : base(list)
        {

        }
        public string OriginalMessage { get; set; }

        public bool IsFinalStep => false;

        public string GetMessage()
        {
            throw new NotImplementedException();
        }
    }

    public class Tag
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public TagType Type { get; set; }
    }

    public enum TagType
    {
        Start,
        End
    }
}
