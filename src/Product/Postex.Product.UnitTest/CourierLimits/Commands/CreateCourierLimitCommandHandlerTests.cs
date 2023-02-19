using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.CourierLimits.Commands.CreateCourierLimit;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimits.Commands
{
    public class CreateCourierLimitCommandHandlerTests : BaseHandlerTest<CourierLimit>
    {
        private readonly CreateCourierLimitCommandHandler _commandHandler;

        public CreateCourierLimitCommandHandlerTests()
        {
            _commandHandler = new CreateCourierLimitCommandHandler(_writeRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new CreateCourierLimitCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<CourierLimit>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierLimitCommand() { Name = "test" }, new CancellationToken());

            result.Should().Be(MediatR.Unit.Value);
        }
    }
}
