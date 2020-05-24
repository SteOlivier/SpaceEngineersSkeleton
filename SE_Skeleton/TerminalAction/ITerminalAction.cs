using SE_Skeleton.Cube;
using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.TerminalAction
{
    public interface ITerminalAction
    {
        string Id { get; }
        StringBuilder Name { get; }
        void Apply(IMyCubeBlock block);
    }
}
