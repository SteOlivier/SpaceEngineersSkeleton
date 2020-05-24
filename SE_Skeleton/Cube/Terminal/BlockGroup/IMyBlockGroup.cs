using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Cube.Terminal
{
    /// <summary>
    /// IMyTerminalBlock is base class for every terminal block, all of the block will have following properties and methods
    /// Using Object type for unconstructed types
    /// </summary>
    public interface IMyBlockGroup : IMyTerminalBlock
    {
        List<IMyTerminalBlock> Blocks { get; } // Blocks in the Grid
        [Obsolete]
        Object CubeGrid { get; } // IMyCubeGrid
        string Name { get; } // Name of the Grid
        [Obsolete]
        float Radius { get; } // Don't know if this really exists in the class

        void GetBlocks(List<IMyTerminalBlock> NameOfBlocks);
        //[Obsolete]
        //List<IMyTerminalBlock> GetBlocks();
        //public IMyBlockGroup()
        //{
        //    Blocks = new List<IMyTerminalBlock>();
        //}
    }
}
