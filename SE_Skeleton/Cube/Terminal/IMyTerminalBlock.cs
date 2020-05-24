using SE_Skeleton.Cube.Terminal;
using SE_Skeleton.Cube.Terminal.Container;
using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Cube
{
    /// <summary>
    /// IMyTerminalBlock is base class for every terminal block, all of the block will have following properties and methods
    /// </summary>
    public interface IMyTerminalBlock : IMyCubeBlock
    {
        string CustomName { get; set; }
        string CustomNameWithFaction  { get; set; }
        string DetailedInfo           { get; set; }

        bool ShowOnHUD { get; set; }

        //[Obsolete]
        //IContentType Content { get; }

        bool HasLocalPlayerAccess();
        //{
        //    return _hasLocalPlayerAccess;
        //}
        bool HasPlayerAccess(long playerId);// { }
        //{
        //    if (!_hasPlayerAccess.ContainsKey(playerId)) _hasPlayerAccess.Add(playerId, _hasLocalPlayerAccess);
        //    return _hasPlayerAccess[playerId];
        //}
        void RequestShowOnHUD(bool enable);
        void SetCustomName(string text);
        void SetCustomName(StringBuilder text);
        [Obsolete]
        IMyCargoContainer GetInventory(int itemIndex);

        void ApplyAction(string Action);

        void GetActions(List<Object> Actions);
        Object GetActionWithName(string name);

        //void GetBlocksOfType<T>(List<IMyTerminalBlock> blocks, Func<IMyTerminalBlock, bool> collect = null);


        //private bool _hasLocalPlayerAccess;
        //private Dictionary<long, bool> _hasPlayerAccess;

        //public IMyTerminalBlock()
        //{
        //    _hasLocalPlayerAccess = true;
        //    _hasPlayerAccess = new Dictionary<long, bool>();
        //}
    }
}
