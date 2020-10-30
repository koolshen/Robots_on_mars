using Services.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robots_on_mars.Services.Interfaces
{
    public interface IInputService
    {
        InputDataResponse GetInputData(string[] args);
    }
}
