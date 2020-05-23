using System;
using System.Collections.Generic;
using System.Text;
using SE_Skeleton;
using SE_Skeleton.Terminal.Functional.Programmable;
using SE_Skeleton.Terminal.Functional.Ship.Cockpit;
using SE_Skeleton.Terminal.Functional.TextSurface;
using SE_Skeleton.Terminal.Functional.Timer;

namespace ClassBuilderConsole
{
    /// <summary>
    /// At the program file the void should be removed
    /// The Echo method should be removed
    /// </summary>
    class ContainerFill
    {
        [Obsolete]
        void Echo(string writing) { }
        // What the your cargo group.    
        const string groupName = "ContainerGroup";

        // What the cockpits name needs to be.       
        const string displayName = "Cockpit";
        const string displayProgrammer = "program";

        // The Timer to be triggered When Full   
        const string timerName = "Timer Full Cap";

        // The Timer to be Triggered When Capacity of Cargo Group is at 0 pct  for unloading
        const string timerName2 = "Timer Unloaded";

        // The number of percent integers the Display shows   
        const int roundpercent = 1;

        // End of Editing!    

        IMyCockpit cockpit;
        IMyProgrammableBlock programBlock;
        IMyTextSurface display;
        IMyTextSurface secondDisplay;
        IMyTimerBlock timer;
        IMyTimerBlock timer2;


        public void Program() // The void should be removed at program
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update10;
        }
        void Main(string arg)
        {

            float usedVolume = 0.0f;
            float maxVolume = 0.0f;
            
            timer = GridTerminalSystem.GetBlockWithName(timerName) as IMyTimerBlock;
            timer2 = GridTerminalSystem.GetBlockWithName(timerName2) as IMyTimerBlock;
            cockpit = GridTerminalSystem.GetBlockWithName(displayName) as IMyCockpit;
            programBlock = GridTerminalSystem.GetBlockWithName(displayProgrammer) as IMyProgrammableBlock;

            //Change the number in the following line to match the selected dispaly you want.  Used list below for Reference
            display = cockpit.GetSurface(0);
            secondDisplay = programBlock.GetSurface(0);

            //GetSurface Locations within Cockpits
            //Large Grid
            // Industrial - 0= Large Display, 1= Top Left, 2= Top Center, 3= Top Right. 4= Keyboard, 5= Number Pad
            // Utility - 0= Top Center Screen, 1= Top Left, 2= Top Right, 3= Keyboard, 4= Bottom Left, 5= Bottom Right
            //Small Grid
            // Fighter - 0= Top Center Screen, 1= Top Left, 2= Top Right, 3= Keyboard, 4= Bottom Center, 5= Number Pad
            // Industrial - 0= Top Left, 1= Top Center, 2= Top Right. 3= Keyboard, 4= Number Pad
            // Utility - 0 = Center Display, 1 = Left Display, 2 = Right Display, 3 = Keyboard 


            //var group = this.GridTerminalSystem.GetBlockGroupWithName(groupName);
            var group = GridTerminalSystem.GetBlockGroupWithName(groupName);
            if (group == null)
            {
                this.Echo("No Group named " + "\n'' " + groupName + " ''\n");
            }
            if (display == null)
            {
                this.Echo("No display named " + "\n'' " + displayName + " ''\n");
            }
            if (group == null || display == null)
            {
                return;
            }

            var groupBlocks = new List<IMyTerminalBlock>();
            group.GetBlocks(groupBlocks);
            for (int i = 0; i < groupBlocks.Count; i++)
            {
                var block = groupBlocks[i];
                usedVolume += (float)block.GetInventory(0).CurrentVolume;
                maxVolume += (float)block.GetInventory(0).MaxVolume;
            }

            float pctUsed = 100.0f * usedVolume / maxVolume;

            if (display != null && group != null)
            {

                string displayText = String.Format("" + groupName + "\nOverall: {0}%\n", (int)pctUsed);

                for (int x = 0; x <= 10; x++)
                {
                    if (pctUsed >= 100 - x * 10)
                    {
                        displayText += "[ <=========> ]\n";
                    }
                    else
                    {
                        displayText += "|                          |\n";
                    }
                }

                if (pctUsed >= 99)
                {
                    timer.ApplyAction("TriggerNow");
                }

                if (pctUsed <= 0)
                {
                    timer2.ApplyAction("TriggerNow");
                }

                var fill = (float)(usedVolume / maxVolume);
                var roundfill = (int)Math.Round(fill * 100.0 / roundpercent) * roundpercent;
                var log = "Capacity: " + (fill).ToString("P2");
                Echo(log);

                display.WriteText(displayText, false);

            }

            /// Added region
            if (secondDisplay != null && group != null)
            {

                string displayText = String.Format("" + groupName + "\nOverall: {0}%\n", (int)pctUsed);

                for (int x = 0; x <= 10; x++)
                {
                    if (pctUsed >= 100 - x * 10)
                    {
                        displayText += "[ <=========> ]\n";
                    }
                    else
                    {
                        displayText += "|                          |\n";
                    }
                }

                var fill = (float)(usedVolume / maxVolume);
                var roundfill = (int)Math.Round(fill * 100.0 / roundpercent) * roundpercent;
                var log = "Capacity: " + (fill).ToString("P2");
                Echo(log);

                secondDisplay.WriteText(displayText, false);

            }

            //// 	

        }
    }
}

