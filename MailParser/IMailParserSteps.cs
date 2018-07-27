using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailParser
{
    public abstract class Steps<T1, T2> : IStep where T1 : IStepParameter where T2 : IStepParameter
    {
        public abstract T2 Execute(T1 input);
        public IStepParameter Execute(IStepParameter input)
        {
            var output = Execute((T1)input);
            return output;
        }
    }

    public interface IStep
    {
        IStepParameter Execute(IStepParameter input);
    }

    public interface IStepParameter
    {
        string GetMessage();
        bool IsFinalStep { get; }
    }

}
