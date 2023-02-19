using Postex.Product.Application.Features.CourierStatusMappings.Commands.CreateCourierStatusMapping;

using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierStatusMappings.Commands
{
    public class CreateCourierStatusMappingsCommandValidatorTests
    {
        private readonly CreateCourierStatusMappingCommandValidator _commandValidator;

        public CreateCourierStatusMappingsCommandValidatorTests()
        {
            _commandValidator = new CreateCourierStatusMappingCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string code)
        {
            CreateCourierStatusMappingCommand command = new()
            {
                Code = code
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Code));
        }
    }
}
