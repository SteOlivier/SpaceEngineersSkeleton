﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Cube.Terminal.Container
{
    [Obsolete]
    public interface IMyCargoContainer : IMyTerminalBlock
    {
        float CurrentVolume { get; }
        float MaxVolume { get; }
    }
}
