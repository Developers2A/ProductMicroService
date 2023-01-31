using Postex.Product.Application.Features.CourierInsurances.Commands.UpdateCourierInsurance;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierInsurances.Commands
{
    public class UpdateCourierInsuranceCommandValidatorTests
    {
        private readonly UpdateCourierInsuranceCommandValidator _commandValidator;
        public UpdateCourierInsuranceCommandValidatorTests()
        {
            _commandValidator = new UpdateCourierInsuranceCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            UpdateCourierInsuranceCommand command = new()
            {
                Name = name
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Name));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ValidateAsync_IdIsDefault_ValidationFailed(int id)
        {
            UpdateCourierInsuranceCommand command = new()
            {
                Name = "test",
                Id = id
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Id));
        }
    }
}
