using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.CourierLimits.Commands.CreateCourierLimit;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimits.Commands
{
    public class CreateCourierLimitCommandHandlerTests
    {
        private readonly CreateCourierLimitCommandHandler _commandHandler;

        public CreateCourierLimitCommandHandlerTests()
        {
            MockRepository(out var mockRepository);
            _commandHandler = new CreateCourierLimitCommandHandler(mockRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierLimitCommand() { Name = "test" }, new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }

        private static void MockRepository(out Mock<IWriteRepository<CourierLimit>> mockRepository)
        {
            var mockClassRoomRepository = new Mock<IWriteRepository<CourierLimit>>();
            mockClassRoomRepository.Setup(x => x.AddAsync(It.IsAny<CourierLimit>(), CancellationToken.None)).Returns(Task.FromResult(new CourierLimit())).Verifiable();
            mockClassRoomRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierLimit>(), CancellationToken.None)).Returns(Task.FromResult(new CourierLimit())).Verifiable();
            mockRepository = mockClassRoomRepository;
        }
    }
}
