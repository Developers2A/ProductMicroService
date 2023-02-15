using Postex.Product.Application.Features.States.Commands.UpdateState;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.States.Commands
{
    public class UpdateStateCommandValidatorTests
    {
        private readonly UpdateStateCommandValidator _commandValidator;
        public UpdateStateCommandValidatorTests()
        {
            _commandValidator = new UpdateStateCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            UpdateStateCommand updateStateCommand = new()
            {
                Name = name
            };

            var result = await _commandValidator.ValidateAsync(updateStateCommand);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(updateStateCommand.Name));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_IdIsDefault_ValidationFailed(int id)
        {
            UpdateStateCommand updateStateCommand = new()
            {
                Name = "test",
                Id = id
            };

            var result = await _commandValidator.ValidateAsync(updateStateCommand);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(updateStateCommand.Id));
        }
    }
}
