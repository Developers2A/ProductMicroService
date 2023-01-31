using Postex.Product.Application.Features.CourierServices.Commands.CreateCourierService;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierServices.Commands
{
    public class CreateCourierServiceCommandValidatorTests
    {
        private readonly CreateCourierServiceCommandValidator _commandValidator;

        public CreateCourierServiceCommandValidatorTests()
        {
            _commandValidator = new CreateCourierServiceCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            CreateCourierServiceCommand command = new()
            {
                Name = name
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Name));
        }
    }
}
