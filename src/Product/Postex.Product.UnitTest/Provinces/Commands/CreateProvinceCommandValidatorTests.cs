using Postex.Product.Application.Features.Provinces.Commands.CreateProvince;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Provinces.Commands
{
    public class CreateProvinceCommandValidatorTests
    {
        private readonly CreateProvinceCommandValidator _commandValidator;

        public CreateProvinceCommandValidatorTests()
        {
            _commandValidator = new CreateProvinceCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            CreateProvinceCommand command = new()
            {
                Name = name
            };

            var result = await _commandValidator.ValidateAsync(command);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Name));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(null)]
        public async Task ValidateAsync_CodeIsNullOrEmpty_ValidationFailed(int code)
        {
            CreateProvinceCommand command = new()
            {
                Code = code
            };

            var result = await _commandValidator.ValidateAsync(command);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Code));
        }
    }
}
