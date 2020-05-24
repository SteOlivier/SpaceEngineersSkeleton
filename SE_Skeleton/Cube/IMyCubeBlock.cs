using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Cube
{
    public interface IMyCubeBlock
    {
        bool IsBeingHacked { get; }
        bool IsFunctional { get; }
        bool IsWorking { get; }
        System.Numerics.Vector3 Position { get; }
    }
}
