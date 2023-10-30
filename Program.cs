using System;
using System.Xml.Linq;

namespace MyTestProject
{
    class RobotSimulator
    {
        static int XStartingPosition = -1;
        static int YStartingPosition = -1;
        static string StartingDirection = "";
        static int TableLength = 5;
        static int TableWidth = 5;
        
         

        public static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Enter your Command");

                
                string Commands = Console.ReadLine();

                if (string.IsNullOrEmpty(Commands))
                {
                    Console.WriteLine("Please Enter your Command");
                    return;
                }
                string[] Inputs = Commands.Split(' ');
                string Command = Inputs[0];
                switch (Command)
                {
                    case "PLACE":
                        if (Inputs.Length == 2)
                        {
                            string[] PositionParams = Inputs[1].Split(',');
                            int x = Convert.ToInt32(PositionParams[0]);
                            int y = Convert.ToInt32(PositionParams[1]);
                            string Direction = PositionParams[2];
                            PlaceRobot(x, y, Direction);
                        }
                        break;
                    case "MOVE":
                            MoveRobot();
                        break;
                    case "REPORT":
                        ReportRobot();
                        break;
                    case "TURN":
                        if(Inputs.Length == 2)
                        {
                            string Towards = Inputs[1];
                            Turn(Towards);
                        }
                         
                        
                        break;
                }
            }
            static void PlaceRobot(int x, int y, string Direction)
            {
                Console.WriteLine("Positioing the Robot");
                XStartingPosition = x;
                YStartingPosition = y;
                StartingDirection = Direction;

                //Console.WriteLine("Robot is at " + x + "," + y + "," + Direction);
            }
            static void MoveRobot()
            {
                int NewX = XStartingPosition;
                int NewY = YStartingPosition;
                string Direction = StartingDirection;
                if (IsValidPosition(NewX, NewY))
                {
                    switch (Direction)
                    {
                        case "SOUTH":
                            NewX = XStartingPosition;
                            NewY = YStartingPosition--;
                            //StartingDirection = Direction;
                            break;
                        case "EAST":
                            NewY = YStartingPosition;
                            NewX = XStartingPosition++;
                            //StartingDirection = Direction;
                            break;
                        case "WEST":
                            NewY = YStartingPosition;
                            NewX = XStartingPosition--;
                            //StartingDirection = Direction;
                            break;
                        case "NORTH":
                            NewX = XStartingPosition;
                            NewY = YStartingPosition++;
                            //StartingDirection = Direction;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Can't Move already at Maximum Position");
                }
            }
            static void ReportRobot()
            {
                if (XStartingPosition == -1 || YStartingPosition == -1)
                    Console.WriteLine("Robot is not placed on the table.");
                else
                    Console.WriteLine("Robot is at " + XStartingPosition + ","+ YStartingPosition+","+StartingDirection);
            }
            static void Turn(string Towards)
            {
                string Direction = StartingDirection;
                if (Direction == "NORTH")
                {
                    switch (Towards)
                    {
                        case "LEFT":
                            StartingDirection = "WEST";
                            break;
                        case "RIGHT":
                            StartingDirection = "EAST";
                            break;
                    }
                }
                if(Direction =="SOUTH")
                {
                    switch (Towards)
                    {
                        case "LEFT":
                            StartingDirection = "EAST";
                            break;
                        case "RIGHT":
                            StartingDirection = "WEST";
                            break;
                    }
                }
                if (Direction == "EAST")
                {
                    switch (Towards)
                    {
                        case "LEFT":
                            StartingDirection = "NORTH";
                            break;
                        case "RIGHT":
                            StartingDirection = "SOUTH";
                            break;
                    }
                }
                if (Direction == "WEST")
                {
                    switch (Towards)
                    {
                        case "LEFT":
                            StartingDirection = "SOUTH";
                            break;
                        case "RIGHT":
                            StartingDirection = "NORTH";
                            break;
                    }
                }
            }
            static bool IsValidDirection(string direction)
            {
                return direction == "NORTH" || direction == "SOUTH" || direction == "EAST" || direction == "WEST";
            }

            static bool IsValidPosition(int x, int y)
            {
                return x >= 0 && x < TableLength && y >= 0 && y < TableLength;
            }
        }
    }
}