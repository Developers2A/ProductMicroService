using Postex.Product.Application.Features.States.Commands.CreateState;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.States.Commands
{
    public class CreateStateCommandValidatorTests
    {
        private readonly CreateStateCommandValidator _commandValidator;

        public CreateStateCommandValidatorTests()
        {
            _commandValidator = new CreateStateCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            CreateStateCommand command = new()
            {
                Name = name
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Name));
        }
    }
}
