using System;
using System.Collections.Generic;
using System.Text;
using SE_Skeleton;
using SE_Skeleton.Cube;
using SE_Skeleton.Cube.Terminal.Container;
using SE_Skeleton.Cube.Terminal.Functional.Programmable;
using SE_Skeleton.Cube.Terminal.Functional.Ship.Cockpit;
using SE_Skeleton.Cube.Terminal.Functional.TextSurface;
using SE_Skeleton.Cube.Terminal.Functional.Timer;

namespace ClassBuilderConsole
{
    /// <summary>
    /// At the program file the void should be removed
    /// The Echo method should be removed
    /// </summary>
    class ContainerFill
    {
        [Obsolete]
        void Echo(string writing) { } // Todo: remove this automatically in build
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
            if (cockpit != null) display = cockpit.GetSurface(0);
            if (programBlock != null) secondDisplay = programBlock.GetSurface(0);

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

    /// <summary>
    /// At the program file the void should be removed
    /// The Echo method should be removed
    /// </summary>
    class ContainerFillAssignNames
    {
        //[Obsolete]
        void Echo(string writing) { } // Todo: remove this automatically in build
        // What the your cargo group.    
        //const string groupName = "ContainerGroup"; //if no group is found, it will be auto assigned
        const string groupName = "-1"; //if no group is found, it will be auto assigned

        // What the cockpits name needs to be.       
        const string displayName = "Cockpit"; //if no Cockpit is found, it will be auto assigned
        const string displayProgrammer = "-1"; // attempt to look for this programmer block screen unless -1

        // The Timer to be triggered When Full   
        const string timerName = "Timer Full Cap"; // Not required

        // The Timer to be Triggered When Capacity of Cargo Group is at 0 pct  for unloading
        const string timerName2 = "Timer Unloaded"; // Not required

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
            if (cockpit != null) display = cockpit.GetSurface(0);
            if (programBlock != null) secondDisplay = programBlock.GetSurface(0);
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
                this.Echo("No Group named '" + groupName + "'");
            }
            if (display == null)
            {
                this.Echo("No display named '" + displayName + "'");
            }

            var groupBlocks = new List<IMyTerminalBlock>();
            if (group == null)
            {
                Echo("group is null");
                GridTerminalSystem.GetBlocksOfType<IMyCargoContainer>(groupBlocks);	//put all Containers in this list 
                Echo("Groups found: " + groupBlocks.Count);
                //GridTerminalSystem.GetBlocksOfType<IMyShipDrill>(groupBlocks);	//put all Batterys in this list 
                //GridTerminalSystem.GetBlocksOfType<IMyCockpit>(groupBlocks);	//put all Batterys in this list 
                //GridTerminalSystem.GetBlocksOfType<IMyShipConnector>(groupBlocks);	//put all Batterys in this list 
                if (groupBlocks.Count == 0) return;
                //group = cargoContainers;
            }
            if (group != null) group.GetBlocks(groupBlocks);
            for (int i = 0; i < groupBlocks.Count; i++)
            {
                var block = groupBlocks[i];
                if (!groupBlocks[i].GetType().ToString().Contains("MyCargoContainer")) Echo(block.GetType().ToString());
                usedVolume += (float)block.GetInventory(0).CurrentVolume;
                maxVolume += (float)block.GetInventory(0).MaxVolume;
            }
            Echo("Used/Max");
            Echo(usedVolume + "/" + maxVolume);
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

                

                display.WriteText(displayText, false);

            }

            if (group != null)
            {
                var fill = (float)(usedVolume / maxVolume);
                var roundfill = (int)Math.Round(fill * 100.0 / roundpercent) * roundpercent;
                var log = "Capacity: " + (fill).ToString("P2");
                Echo(log);
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
                secondDisplay.WriteText(displayText, false);

            }

            //// 	

        }


        /// Copy to here
    }



}

