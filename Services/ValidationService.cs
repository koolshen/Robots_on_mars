using Entities;
using Robots_on_mars.Services.Interfaces;
using Services.Responses;

namespace Robots_on_mars.Services
{
    public class ValidationService : IValidationService
    {
        public bool IsRobotLost(Robot robot, Position upperRightPosition)
        {
            return robot.Position.X > upperRightPosition.X 
                || robot.Position.Y > upperRightPosition.Y 
                || robot.Position.X < 0
                || robot.Position.Y < 0; 
        }
    }
}
