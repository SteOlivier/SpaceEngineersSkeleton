using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Cube.Terminal.Functional
{
    public interface IMyShipConnector : IMyFunctionalBlock
    {
        bool ThrowOut { get; }
        bool CollectAll { get; }
        bool IsLocked { get; }

        /**
            Actions:
            OnOff -> Toggle block On/Off
            OnOff_On -> Toggle block On
            OnOff_Off -> Toggle block Off
            ThrowOut -> Throw Out On/Off
            CollectAll -> Collect All On/Off
            SwitchLock -> Switch lock
    */
    }
}
