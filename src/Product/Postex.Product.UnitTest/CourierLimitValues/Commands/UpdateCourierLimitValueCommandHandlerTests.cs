using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierLimitValues.Commands.UpdateCourierLimitValue;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimitValues.Commands
{
    public class UpdateCourierLimitValueCommandHandlerTests
    {
        private readonly UpdateCourierLimitValueCommandHandler _commandHandler;

        public UpdateCourierLimitValueCommandHandlerTests()
        {
            MockWriteRepository(out var mockWriteRepository);
            MockReadRepository(out var mockReadRepository);
            _commandHandler = new UpdateCourierLimitValueCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierLimitValueCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }

        private static void MockWriteRepository(out Mock<IWriteRepository<CourierLimitValue>> repository)
        {
            var mockRepository = new Mock<IWriteRepository<CourierLimitValue>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierLimitValue>(), CancellationToken.None)).Returns(Task.FromResult(new CourierLimitValue())).Verifiable();
            repository = mockRepository;
        }

        private static void MockReadRepository(out Mock<IReadRepository<CourierLimitValue>> repository)
        {
            var mockRepository = new Mock<IReadRepository<CourierLimitValue>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new CourierLimitValue())).Verifiable();
            repository = mockRepository;
        }
    }
}
