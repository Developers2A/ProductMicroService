using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierLimits.Commands.UpdateCourierLimit;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimits.Commands
{
    public class UpdateCourierLimitCommandHandlerTests : BaseHandlerTest<CourierLimit>
    {
        private readonly UpdateCourierLimitCommandHandler _commandHandler;

        public UpdateCourierLimitCommandHandlerTests()
        {
            _commandHandler = new UpdateCourierLimitCommandHandler(_writeRepository.Object, _readRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new UpdateCourierLimitCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<CourierLimit>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierLimitCommand(), new CancellationToken());

            result.Should().Be(Unit.Value);
        }
    }
}
