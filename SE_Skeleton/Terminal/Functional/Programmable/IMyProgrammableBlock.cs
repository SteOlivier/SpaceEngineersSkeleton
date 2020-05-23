using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Skeleton.Terminal.Functional.Programmable
{
    public interface IMyProgrammableBlock : IMyFunctionalBlock
    {
        bool isRunning { get; }
        /*
        Actions:
        OnOff -> Toggle block On/Off
        OnOff_On -> Toggle block On
        OnOff_Off -> Toggle block Off
        Run -> Run
        */
    }
}
