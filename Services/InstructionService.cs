using Entities;
using Robots_on_mars.Services.Interfaces;
using Services.Responses;

namespace Robots_on_mars.Services
{
    public class InstructionService : IInstructionService
    {

        private readonly IValidationService _validationService;

        public InstructionService(IValidationService validationService)
        {
            _validationService = validationService;
        }

        public InstructionService()
        {

        }

        public void ExecuteInstructions(Robot robot, InputDataResponse parsedInputResult)
        {
            while (robot.WayPoints.Count > 0)
            {
                var instruction = robot.WayPoints.Dequeue();
                robot.ExecuteInstruction(instruction, parsedInputResult.Robots);

                if (_validationService.IsRobotLost(robot, parsedInputResult.upperRightCoordinates))
                {
                    robot.IsLost = true;
                    break;
                }
            }
        }
    }
}
