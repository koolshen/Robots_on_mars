using IoC;
using NUnit.Framework;
using Robots_on_mars.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class TestBase
    {
        internal IInputService inputService;
        internal IInstructionService instructionService;
        internal IValidationService validationService;

        [SetUp]
        public void Setup()
        {
            DependencyResolver.InitIoC();
            inputService = DependencyResolver.GetService<IInputService>();
            instructionService = DependencyResolver.GetService<IInstructionService>();
            validationService = DependencyResolver.GetService<IValidationService>();
        }
    }
}
