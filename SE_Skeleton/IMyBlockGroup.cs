using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton
{
    /// <summary>
    /// IMyTerminalBlock is base class for every terminal block, all of the block will have following properties and methods
    /// Using Object type for unconstructed types
    /// </summary>
    public class IMyBlockGroup : IMyTerminalBlock
    {
        public List<IMyTerminalBlock> Blocks; // Blocks in the Grid
        [Obsolete]
        public Object CubeGrid; // IMyCubeGrid
        public string Name; // Name of the Grid
        [Obsolete]
        public float Radius; // Don't know if this really exists in the class

        public IMyBlockGroup()
        {
            Blocks = new List<IMyTerminalBlock>();
        }
    }
}
