using Postex.Product.Application.Features.Cities.Commands.UpdateCity;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Cities.Commands
{
    public class UpdateCityCommandValidatorTests
    {
        private readonly UpdateCityCommandValidator _commandValidator;

        public UpdateCityCommandValidatorTests()
        {
            _commandValidator = new UpdateCityCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            UpdateCityCommand command = new()
            {
                Name = name
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Name));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_IdIsDefault_ValidationFailed(int id)
        {
            UpdateCityCommand command = new()
            {
                Id = id
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Id));
        }
    }
}
