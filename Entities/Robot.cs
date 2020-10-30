using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Entities
{
    public class Robot
    {

        public Robot(Position position, Orientation orientation)
        {
            Orientation = orientation;
            Position = position;
        }

        public int Id { get; set; }
        public Orientation Orientation { get; set; }
        public Position Position { get; set; }
        public Queue<Instruction> WayPoints { get; set; } = new Queue<Instruction>();
        public Position PositionScent { get; set; }
        public Orientation OrientationScent { get; set; }

        public bool IsLost { get; set; }

        public void ExecuteInstruction(Instruction instruction, IEnumerable<Robot> robots)
        {
            CalculateOrientationAndPosition(instruction, robots);
        }

        private void CalculateOrientationAndPosition(Instruction instruction, IEnumerable<Robot> robots)
        {
            OrientationScent = Orientation;
            PositionScent = new Position(Position.X, Position.Y);
            CalculateProperOrientation(instruction, robots);
        }

        private void CalculateProperOrientation(Instruction instruction, IEnumerable<Robot> robots)
        {
            switch (instruction)
            {
                case Instruction.R:
                    if (Orientation == Orientation.W)
                    {
                        Orientation = Orientation.N;
                    } 
                    else
                    {
                        Orientation++;
                    }
                    break;
                case Instruction.L:
                    if (Orientation == Orientation.N)
                    {
                        Orientation = Orientation.W;
                    } 
                    else
                    {
                        Orientation--;
                    }
                    break;
                case Instruction.F:

                    if(robots.Any(x => x.IsLost && x.Orientation == Orientation && x.PositionScent.X == Position.X && x.PositionScent.Y == Position.Y))
                    {
                        break;
                    }

                    if (Orientation == Orientation.N)
                    {
                        Position.Y++;
                    }
                    else if (Orientation == Orientation.E)
                    {
                        Position.X++;
                    }
                    else if (Orientation == Orientation.S)
                    {
                        Position.Y--;
                    }
                    else if (Orientation == Orientation.W)
                    {
                        Position.X--;
                    }

                    break;
            }

         

        }

        public bool IsValid()
        {
            return Position.IsValid();
        }

        public override string ToString()
        {
            return IsLost ? $"{PositionScent.X} {PositionScent.Y} {Orientation} LOST" : $"{Position.X} {Position.Y} {Orientation}";
        }
    }
}
