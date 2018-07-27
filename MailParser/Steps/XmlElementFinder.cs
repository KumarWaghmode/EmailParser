using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailParser
{
    public class XmlElementFinder : Steps<TagList, IStepParameter>
    {
        public override IStepParameter Execute(TagList input)
        {
            var copiedTagsList = new TagList(input);
            var xmlTagList = new XmlTagList();
            foreach (var tag in input)
            {
                if (tag.Type == TagType.Start)
                {
                    var matchingEndTag = copiedTagsList.SingleOrDefault(t => t.Type == TagType.End && t.Name == tag.Name);
                    if (matchingEndTag != null)
                    {
                        var xmlTag = Regex.Match(input.OriginalMessage, $"{tag.Text}(.*?){matchingEndTag.Text}", RegexOptions.Singleline);
                        xmlTagList.Add(new XmlTag()
                        {
                            Name = tag.Name,
                            Value = xmlTag.Groups[1].Value
                        });
                    }
                    else
                    {
                        return new MissingEndTag(tag.Name);
                    }
                }
            };
            return xmlTagList;
        }
    }
}



