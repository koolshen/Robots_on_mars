using Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Responses
{
    public class InputDataResponse
    {

        public bool IsValid { get; set; }
        public Position upperRightCoordinates { get; set; } = new Position();
        public List<Robot> Robots { get; set; } = new List<Robot>();
    }
}
