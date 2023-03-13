using Postex.Product.Application.Features.Provinces.Commands.UpdateProvince;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.States.Commands
{
    public class UpdateProvinceCommandValidatorTests
    {
        private readonly UpdateProvinceCommandValidator _commandValidator;
        public UpdateProvinceCommandValidatorTests()
        {
            _commandValidator = new UpdateProvinceCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            UpdateProvinceCommand updateStateCommand = new()
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
            UpdateProvinceCommand updateStateCommand = new()
            {
                Name = "test",
                Id = id
            };

            var result = await _commandValidator.ValidateAsync(updateStateCommand);

            Assert.Contains(result.Errors, o => o.PropertyName == nameof(updateStateCommand.Id));
        }
    }
}
