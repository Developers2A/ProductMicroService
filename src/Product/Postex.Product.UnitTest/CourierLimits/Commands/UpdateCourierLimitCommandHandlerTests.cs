using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierLimits.Commands.UpdateCourierLimit;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimits.Commands
{
    public class UpdateCourierLimitCommandHandlerTests
    {
        private readonly UpdateCourierLimitCommandHandler _commandHandler;

        public UpdateCourierLimitCommandHandlerTests()
        {
            MockWriteRepository(out var mockWriteRepository);
            MockReadRepository(out var mockReadRepository);
            _commandHandler = new UpdateCourierLimitCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierLimitCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }

        private static void MockWriteRepository(out Mock<IWriteRepository<CourierLimit>> repository)
        {
            var mockRepository = new Mock<IWriteRepository<CourierLimit>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierLimit>(), CancellationToken.None)).Returns(Task.FromResult(new CourierLimit())).Verifiable();
            repository = mockRepository;
        }

        private static void MockReadRepository(out Mock<IReadRepository<CourierLimit>> repository)
        {
            var mockRepository = new Mock<IReadRepository<CourierLimit>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new CourierLimit())).Verifiable();
            repository = mockRepository;
        }
    }
}
