using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Cube.Terminal.Functional.Timer
{
    /**
        Actions:
        OnOff -> Toggle block On/Off
        OnOff_On -> Toggle block On
        OnOff_Off -> Toggle block Off
        IncreaseTriggerDelay -> Increase Delay
        DecreaseTriggerDelay -> Decrease Delay
        TriggerNow -> Trigger now
        Start -> Start
        Stop -> Stop
    **/
    public interface IMyTimerBlock : IMyFunctionalBlock
    {
        bool isCountingDown { get; }
        float TriggerDelay { get; }


        
    }
}
