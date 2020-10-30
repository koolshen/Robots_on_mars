using Entities;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robots_on_mars.Services.Interfaces
{
    public interface IValidationService
    {
        bool IsRobotLost(Robot robot, Position upperRightPosition);
    }
}
