using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierLimitValues.Commands.UpdateCourierLimitValue;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimitValues.Commands
{
    public class UpdateCourierLimitValueCommandHandlerTests : BaseHandlerTest<CourierLimitValue>
    {
        private readonly UpdateCourierLimitValueCommandHandler _commandHandler;

        public UpdateCourierLimitValueCommandHandlerTests()
        {
            _commandHandler = new UpdateCourierLimitValueCommandHandler(_writeRepository.Object, _readRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new UpdateCourierLimitValueCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<CourierLimitValue>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierLimitValueCommand(), new CancellationToken());

            result.Should().Be(Unit.Value);
        }
    }
}
