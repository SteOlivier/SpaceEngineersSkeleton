using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton
{
    /// <summary>
    /// IMyTerminalBlock is base class for every terminal block, all of the block will have following properties and methods
    /// </summary>
    public class IMyTerminalBlock
    {
        public string CustomName;
        public string CustomNameWithFaction;
        public string DetailedInfo;

        public bool ShowOnHUD;

        public bool HasLocalPlayerAccess()
        {
            return _hasLocalPlayerAccess;
        }
        public bool HasPlayerAccess(long playerId)
        {
            if (!_hasPlayerAccess.ContainsKey(playerId)) _hasPlayerAccess.Add(playerId, _hasLocalPlayerAccess);
            return _hasPlayerAccess[playerId];
        }
        public void RequestShowOnHUD(bool enable)
        {

        }
        public void SetCustomName(string text)
        {

        }
        public void SetCustomName(StringBuilder text)
        {

        }
        

        private bool _hasLocalPlayerAccess;
        private Dictionary<long, bool> _hasPlayerAccess;

        public IMyTerminalBlock()
        {
            _hasLocalPlayerAccess = true;
            _hasPlayerAccess = new Dictionary<long, bool>();
        }
    }
}
