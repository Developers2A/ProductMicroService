using Postex.Product.Application.Features.CourierInsurances.Commands.CreateCourierInsurance;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierInsurances.Commands
{
    public class CreateCourierInsuranceCommandValidatorTests
    {
        private readonly CreateCourierInsuranceCommandValidator _commandValidator;

        public CreateCourierInsuranceCommandValidatorTests()
        {
            _commandValidator = new CreateCourierInsuranceCommandValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidateAsync_NameIsNullOrEmpty_ValidationFailed(string name)
        {
            CreateCourierInsuranceCommand command = new()
            {
                Name = name
            };
            var result = await _commandValidator.ValidateAsync(command);
            Assert.Contains(result.Errors, o => o.PropertyName == nameof(command.Name));
        }
    }
}
