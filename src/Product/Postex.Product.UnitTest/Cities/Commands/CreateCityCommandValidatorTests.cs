using Postex.Product.Application.Features.Cities.Commands.CreateCity;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Cities.Commands
{
    public class CreateCityCommandValidatorTests
    {
        private readonly CreateCityCommandValidator _commandValidator;

        public CreateCityCommandValidatorTests()
        {
            _commandValidator = new CreateCityCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            CreateCityCommand command = new()
            {
                Name = name
            };

            var result = await _commandValidator.ValidateAsync(command);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Name));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_StateIsNullOrEmpty_ValidationFailed(int stateId)
        {
            CreateCityCommand command = new()
            {
                StateId = stateId
            };

            var result = await _commandValidator.ValidateAsync(command);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.StateId));
        }
    }
}
