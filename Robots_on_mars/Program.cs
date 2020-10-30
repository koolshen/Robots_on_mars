using IoC;
using Robots_on_mars.Services.Interfaces;
using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.Loader;
using System.Text;

namespace Robots_on_mars
{
    class Program
    {
        private static IInputService _inputService;
        private static IInstructionService _instructionService;

        static void Main(string[] args)
        {
            InitApplication();
            var parsedInputResult = _inputService.GetInputData(args);

            foreach (var robot in parsedInputResult.Robots)
            {
                _instructionService.ExecuteInstructions(robot, parsedInputResult);
            }

        }

        private static void InitApplication()
        {
            DependencyResolver.InitIoC();
            _inputService = DependencyResolver.GetService<IInputService>();
            _instructionService = DependencyResolver.GetService<IInstructionService>();
        }
    }
}
