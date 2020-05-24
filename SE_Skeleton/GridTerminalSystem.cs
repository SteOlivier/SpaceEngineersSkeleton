using SE_Skeleton.Cube;
using SE_Skeleton.Cube.Terminal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton
{
    /// <summary>
    /// Main entry level of the program. Think about a way to create this with existing properties from a programmer block? Recreate the entire environment
    /// </summary>
    public static class GridTerminalSystem
    {
        
        public static List<IMyTerminalBlock> Blocks { get; }
        public static List<IMyBlockGroup> BlockGroups { get; }
        public static IMyTerminalBlock GetBlockWithName(string name)
        {
            if (_getBlockWithName.ContainsKey(name)) return _getBlockWithName[name];
            return null;
        }

        public static List<IMyTerminalBlock> SearchBlocksOfName(string name, List<IMyTerminalBlock> blocks)
        {
            List<IMyTerminalBlock> rList = new List<IMyTerminalBlock>();

            for (int ii = 0; ii < blocks.Count; ii++)
            {
                if (blocks[ii].CustomName.ToLower().Contains(name.ToLower())) rList.Add(blocks[ii]);
            }

            if (rList.Count == 0) return null;
            return rList;
        }

        private static Dictionary<string, IMyTerminalBlock> _getBlockWithName;
        private static Dictionary<string, IMyBlockGroup> _getBlockGroupName;

        /// <summary>
        /// Call this method to structure all the other dictionaries and things that are used by other methods that are build from the the structure
        /// </summary>
        private static void setupBlockNames()
        {
            _getBlockWithName.Clear();
            for (int ii = 0; ii < Blocks.Count; ii++)
            {
                _getBlockWithName.Add(Blocks[ii].CustomName, Blocks[ii]);
            }
            // Currently I think this is how it works
            for (int ii = 0; ii < Blocks.Count; ii++)
            {
                _getBlockWithName.Add(Blocks[ii].CustomName, Blocks[ii]);
            }
        }

        public static IMyBlockGroup GetBlockGroupWithName(string groupName)
        {
            if (_getBlockGroupName.ContainsKey(groupName)) return _getBlockGroupName[groupName];
            return null;
        }

        public static void GetBlocksOfType<T>(List<IMyTerminalBlock> typeObjectReturn)
        {
            // I'm not going to implement this class just because...
        }

        //public GridTerminalSystem()
        //{
        //    Blocks = new List<IMyTerminalBlock>();
        //    BlockGroups = new List<IMyBlockGroup>();
        //    _getBlockWithName = new Dictionary<string, IMyTerminalBlock>();
        //}
    }
}
