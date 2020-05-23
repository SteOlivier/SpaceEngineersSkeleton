using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Terminal.Functional.Ship
{
    public interface IMyShipController : IMyFunctionalBlock
    {
        bool ControlWheels { get; }
        bool ControlThrusters { get; }
        bool HandBrake { get; }
        bool DampenersOverride { get; }
        /*
            Actions:
            ControlThrusters -> Control thrusters On/Off
            ControlWheels -> Control wheels On/Off
            HandBrake -> Handbrake On/Off
            DampenersOverride -> Inertia dampeners On/Off
        */
    }
}
