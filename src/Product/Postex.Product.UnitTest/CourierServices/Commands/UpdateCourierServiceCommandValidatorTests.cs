using Postex.Product.Application.Features.CourierServices.Commands.UpdateCourierService;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierServices.Commands
{
    public class UpdateCourierServiceCommandValidatorTests
    {
        private readonly UpdateCourierServiceCommandValidator _commandValidator;
        public UpdateCourierServiceCommandValidatorTests()
        {
            _commandValidator = new UpdateCourierServiceCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            UpdateCourierServiceCommand updateCourierServiceCommand = new()
            {
                Name = name
            };

            var result = await _commandValidator.ValidateAsync(updateCourierServiceCommand);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(updateCourierServiceCommand.Name));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_IdIsDefault_ValidationFailed(int id)
        {
            UpdateCourierServiceCommand command = new()
            {
                Name = "test",
                Id = id
            };

            var result = await _commandValidator.ValidateAsync(command);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Id));
        }
    }
}
