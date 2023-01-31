using Postex.Product.Application.Features.CourierLimits.Commands.UpdateCourierLimit;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimits.Commands
{
    public class UpdateCourierLimitCommandValidatorTests
    {
        private readonly UpdateCourierLimitCommandValidator _commandValidator;
        public UpdateCourierLimitCommandValidatorTests()
        {
            _commandValidator = new UpdateCourierLimitCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            UpdateCourierLimitCommand command = new()
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
            UpdateCourierLimitCommand command = new()
            {
                Name = "test",
                Id = id
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Id));
        }
    }
}
