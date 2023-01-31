using Postex.Product.Application.Features.Couriers.Commands.CreateCourier;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Couriers.Commands
{
    public class CreateCourierCommandValidatorTests
    {
        private readonly CreateCourierCommandValidator _commandValidator;

        public CreateCourierCommandValidatorTests()
        {
            _commandValidator = new CreateCourierCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            CreateCourierCommand command = new()
            {
                Name = name
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Name));
        }
    }
}
