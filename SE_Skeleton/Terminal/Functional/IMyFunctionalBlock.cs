using SE_Skeleton.Terminal.Functional.TextSurface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Terminal
{
    public interface IMyFunctionalBlock : IMyTerminalBlock
    {
        bool Enabled { get;  }

        [Obsolete]
        IMyTextSurface GetSurface(int itemIndex);
    }
}
