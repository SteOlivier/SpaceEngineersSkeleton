using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Cube.Terminal.Functional
{
    public interface IMyShipDrill : IMyFunctionalBlock
    {
        bool UseConveyorSystem { get; }
        /**
            Actions:
            OnOff -> Toggle block On/Off
            OnOff_On -> Toggle block On
            OnOff_Off -> Toggle block Off
            UseConveyor -> Use Conveyor System On/Off
        */
    }
}
