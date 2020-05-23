using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Terminal.Functional.TextSurface
{
    public interface IMyTextSurface : IMyFunctionalBlock
    {
        [Obsolete]
        void WriteText(string WriteAllText, bool ClearTerminal);
    }
}
