using Robots_on_mars.Services.Interfaces;
using Services.Responses;

namespace Robots_on_mars.Services
{
    public class InputService : IInputService
    {
        private readonly IParsingService _parsingService;

        public InputService(IParsingService parsingService)
        {
            _parsingService = parsingService;
        }

        public InputDataResponse GetInputData(string[] args)
        {
            var inputString = args.Length > 0 ? 
                _parsingService.ParseInputDataFromParameters(args) :
                _parsingService.ParseInputData();

            return _parsingService.GetEntitiesFromString(inputString);
        }
    }
}
