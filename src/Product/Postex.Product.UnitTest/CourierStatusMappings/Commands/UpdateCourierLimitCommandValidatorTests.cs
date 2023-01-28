using Postex.Product.Application.Features.CourierStatusMappings.Commands.UpdateCourierStatusMapping;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierStatusMappings.Commands
{
    public class UpdateCourierStatusMappingsCommandValidatorTests
    {
        private readonly UpdateCourierStatusMappingCommandValidator _commandValidator;
        public UpdateCourierStatusMappingsCommandValidatorTests()
        {
            _commandValidator = new UpdateCourierStatusMappingCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string code)
        {
            UpdateCourierStatusMappingCommand command = new()
            {
                Code = code
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Code));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_IdIsDefault_ValidationFailed(int id)
        {
            UpdateCourierStatusMappingCommand command = new()
            {
                Code = "test",
                Id = id
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Id));
        }
    }
}
