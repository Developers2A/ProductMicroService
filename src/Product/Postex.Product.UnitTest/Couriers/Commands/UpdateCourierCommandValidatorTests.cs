using Postex.Product.Application.Features.Couriers.Commands.UpdateCourier;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Couriers.Commands
{
    public class UpdateCourierCommandValidatorTests
    {
        private readonly UpdateCourierCommandValidator _commandValidator;
        public UpdateCourierCommandValidatorTests()
        {
            _commandValidator = new UpdateCourierCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            UpdateCourierCommand updateCourierCommand = new()
            {
                Name = name
            };
            var result = await _commandValidator.ValidateAsync(updateCourierCommand);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(updateCourierCommand.Name));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_IdIsDefault_ValidationFailed(int id)
        {
            UpdateCourierCommand command = new()
            {
                Name = "test",
                Id = id
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Id));
        }
    }
}
