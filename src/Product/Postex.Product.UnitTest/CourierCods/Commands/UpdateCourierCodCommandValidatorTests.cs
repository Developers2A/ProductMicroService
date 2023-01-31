using Postex.Product.Application.Features.CourierCods.Commands.UpdateCourierCod;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierCods.Commands
{
    public class UpdateCourierCodCommandValidatorTests
    {
        private readonly UpdateCourierCodCommandValidator _commandValidator;
        public UpdateCourierCodCommandValidatorTests()
        {
            _commandValidator = new UpdateCourierCodCommandValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(int courierId)
        {
            UpdateCourierCodCommand command = new()
            {
                CourierId = courierId
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.CourierId));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_IdIsDefault_ValidationFailed(int id)
        {
            UpdateCourierCodCommand command = new()
            {
                Id = id
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Id));
        }
    }
}
