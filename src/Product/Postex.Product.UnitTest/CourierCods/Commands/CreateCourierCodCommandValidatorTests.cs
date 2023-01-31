using Postex.Product.Application.Features.CourierCods.Commands.CreateCourierCod;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierCods.Commands
{
    public class CreateCourierCodCommandValidatorTests
    {
        private readonly CreateCourierCodCommandValidator _commandValidator;

        public CreateCourierCodCommandValidatorTests()
        {
            _commandValidator = new CreateCourierCodCommandValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(int courierId)
        {
            CreateCourierCodCommand command = new()
            {
                CourierId = courierId
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.CourierId));
        }
    }
}
