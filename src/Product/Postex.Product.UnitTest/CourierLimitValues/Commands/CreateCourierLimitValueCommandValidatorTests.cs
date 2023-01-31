using Postex.Product.Application.Features.CourierLimitValues.Commands.CreateCourierLimitValue;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimitValues.Commands
{
    public class CreateCourierLimitValueCommandValidatorTests
    {
        private readonly CreateCourierLimitValueCommandValidator _commandValidator;

        public CreateCourierLimitValueCommandValidatorTests()
        {
            _commandValidator = new CreateCourierLimitValueCommandValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(int courierId)
        {
            CreateCourierLimitValueCommand command = new()
            {
                CourierId = courierId
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.CourierId));
        }
    }
}
