using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierCods.Commands.UpdateCourierCod;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierCods.Commands
{
    public class UpdateCourierCodCommandHandlerTests
    {
        private readonly UpdateCourierCodCommandHandler _commandHandler;

        public UpdateCourierCodCommandHandlerTests()
        {
            MockWriteRepository(out var mockWriteRepository);
            MockReadRepository(out var mockReadRepository);
            _commandHandler = new UpdateCourierCodCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierCodCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }

        private static void MockWriteRepository(out Mock<IWriteRepository<CourierCod>> repository)
        {
            var mockRepository = new Mock<IWriteRepository<CourierCod>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierCod>(), CancellationToken.None)).Returns(Task.FromResult(new CourierCod())).Verifiable();
            repository = mockRepository;
        }

        private static void MockReadRepository(out Mock<IReadRepository<CourierCod>> repository)
        {
            var mockRepository = new Mock<IReadRepository<CourierCod>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new CourierCod())).Verifiable();
            repository = mockRepository;
        }
    }
}
