using SE_Skeleton.Terminal.Container;
using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton
{
    /// <summary>
    /// IMyTerminalBlock is base class for every terminal block, all of the block will have following properties and methods
    /// </summary>
    public interface IMyTerminalBlock
    {
        string CustomName { get; set; }
        string CustomNameWithFaction  { get; set; }
        string DetailedInfo           { get; set; }

        bool ShowOnHUD { get; set; }

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
        IContainerBlock GetInventory(int itemIndex);

        void ApplyAction(string Action);



        //private bool _hasLocalPlayerAccess;
        //private Dictionary<long, bool> _hasPlayerAccess;

        //public IMyTerminalBlock()
        //{
        //    _hasLocalPlayerAccess = true;
        //    _hasPlayerAccess = new Dictionary<long, bool>();
        //}
    }
}
