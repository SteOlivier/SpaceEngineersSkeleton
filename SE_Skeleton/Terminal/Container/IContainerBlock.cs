using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Terminal.Container
{
    [Obsolete]
    public interface IContainerBlock
    {
        float CurrentVolume { get; }
        float MaxVolume { get; }
    }
}
