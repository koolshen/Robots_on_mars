using Entities;
using Entities.Enums;
using Robots_on_mars.Services.Interfaces;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Robots_on_mars.Services
{
    public class ParsingService : IParsingService
    {
        public string ParseInputData()
        {
            var inputLines = new StringBuilder();
            string inputLine;
            while (!string.IsNullOrWhiteSpace(inputLine = Console.ReadLine().Trim()))
            {
                inputLines.AppendLine(inputLine);
            }

            return inputLines.ToString().Trim();
        }

        public string ParseInputDataFromParameters(string[] args)
        {
            var inputLines = new StringBuilder();

            foreach (var line in args)
            {
                var sanitizedLine = Regex.Replace(line, @"\s+", "");

                if (string.IsNullOrEmpty(sanitizedLine))
                {
                    break;
                }

                int.TryParse(sanitizedLine[0].ToString(), out var x);
                int.TryParse(sanitizedLine[1].ToString(), out var y);

                if (sanitizedLine.Length == 2)
                {
                    inputLines.AppendLine($"{x} {y}");
                }
                else if (sanitizedLine.Length == 3)
                {
                    Enum.TryParse(sanitizedLine[2].ToString(), true, out Orientation orientation);
                    inputLines.AppendLine($"{x} {y} {orientation}");
                }
                if (sanitizedLine.All(x => char.IsLetter(x)))
                {
                    foreach (var orientationChar in sanitizedLine)
                    {
                        Enum.TryParse(orientationChar.ToString(), true, out Instruction instruction);
                        inputLines.Append($"{instruction}");
                    }
                    inputLines.Append(Environment.NewLine);
                }

            }

            return inputLines.ToString().Trim();
        }

        public InputDataResponse GetEntitiesFromString(string entitiesString)
        {
            var response = new InputDataResponse();
            var index = 0;

            foreach (var line in entitiesString.Split(Environment.NewLine))
            {
                var sanitizedLine = Regex.Replace(line, @"\s+", "");

                if (string.IsNullOrEmpty(sanitizedLine))
                {
                    break;
                }

                int.TryParse(sanitizedLine[0].ToString(), out var x);
                int.TryParse(sanitizedLine[1].ToString(), out var y);

                if (sanitizedLine.Length == 2)
                {
                    response.upperRightCoordinates.X = x;
                    response.upperRightCoordinates.Y = y;
                }
                else if (sanitizedLine.Length == 3)
                {
                    Enum.TryParse(sanitizedLine[2].ToString(), true, out Orientation orientation);
                    response.Robots.Add(new Robot(new Position(x, y), orientation) { Id = ++index });
                }
                if (sanitizedLine.All(x => Char.IsLetter(x)))
                {
                    var lastRobot = response.Robots.LastOrDefault();

                    if (lastRobot != null)
                    {
                        foreach (var orientationChar in sanitizedLine)
                        {
                            Enum.TryParse(orientationChar.ToString(), true, out Instruction instruction);
                            lastRobot.WayPoints.Enqueue(instruction);
                        }
                    }
                }

            }

            return ValidateResponse(response);
        }


        private InputDataResponse ValidateResponse(InputDataResponse response)
        {
            response.IsValid =
                response.upperRightCoordinates.IsValid()
                && response.Robots.Any()
                && response.Robots.All(x => x.IsValid())
                && response.Robots.All(x => x.WayPoints.All(y => y != Instruction.None)
                );

            return response;
        }


    }
}
