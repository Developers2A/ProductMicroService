using Postex.Product.Application.Features.CourierLimits.Commands.CreateCourierLimit;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimits.Commands
{
    public class CreateCourierLimitCommandValidatorTests
    {
        private readonly CreateCourierLimitCommandValidator _commandValidator;

        public CreateCourierLimitCommandValidatorTests()
        {
            _commandValidator = new CreateCourierLimitCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            CreateCourierLimitCommand command = new()
            {
                Name = name
            };

            var result = await _commandValidator.ValidateAsync(command);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Name));
        }
    }
}
