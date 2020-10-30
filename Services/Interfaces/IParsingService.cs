using Services.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robots_on_mars.Services.Interfaces
{
    public interface IParsingService
    {
        string ParseInputDataFromParameters(string[] args);
        string ParseInputData();
        InputDataResponse GetEntitiesFromString(string entitiesString);
    }
}
