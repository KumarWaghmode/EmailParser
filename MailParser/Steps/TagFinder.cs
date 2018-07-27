using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailParser
{
    public class TagFinder : Steps<Text,TagList>
    {
        private static readonly string _pattern = "<(.*?)>";
        public override TagList Execute(Text input)
        {
            var textMessage = input.Message;
            var tags = Regex.Matches(textMessage, _pattern, RegexOptions.Singleline);
            var groupedTags = tags.Select(tag =>
              {
                  if (tag.Groups[1].Value.Contains("/"))
                  {
                      return new Tag
                      {
                          Name = tag.Groups[1].Value.Replace("/",""),
                          Text = tag.Groups[0].Value,
                          Type = TagType.End
                      };
                  }
                  else
                  {
                      return new Tag
                      {
                          Name = tag.Groups[1].Value,
                          Text = tag.Groups[0].Value,
                          Type = TagType.Start
                      };
                  }
              });
            return new TagList(groupedTags) { OriginalMessage = input.Message };
        }
    }
}
