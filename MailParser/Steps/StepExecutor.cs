using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailParser
{
    public class StepsExecutor
    {
        private readonly List<IStep> steps = new List<IStep>
        {
            new TagFinder(),
            new XmlElementFinder(),
            new XmlValidator()

        };

        public string Execute(string requestMessage)
        {
            var stepParameter = new Text() { Message = requestMessage } as IStepParameter;
            steps.ForEach(step =>
            {
                stepParameter = step.Execute(stepParameter);
                if (stepParameter.IsFinalStep)
                    return;

            });
            return stepParameter.GetMessage();
        }
    }
}
