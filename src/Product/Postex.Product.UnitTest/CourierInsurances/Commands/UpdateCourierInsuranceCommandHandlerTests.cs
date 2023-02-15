using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierInsurances.Commands.UpdateCourierInsurance;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierInsurances.Commands
{
    public class UpdateCourierInsuranceCommandHandlerTests : BaseHandlerTest<CourierInsurance>
    {
        private readonly UpdateCourierInsuranceCommandHandler _commandHandler;

        public UpdateCourierInsuranceCommandHandlerTests()
        {
            _commandHandler = new UpdateCourierInsuranceCommandHandler(_writeRepository.Object, _readRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new UpdateCourierInsuranceCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<CourierInsurance>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierInsuranceCommand(), new CancellationToken());

            result.Should().Be(Unit.Value);
        }
    }
}
