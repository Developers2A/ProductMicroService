using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierStatusMappings.Commands.UpdateCourierStatusMapping;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierStatusMappings.Commands
{
    public class UpdateCourierStatusMappingsCommandHandlerTests
    {
        private readonly UpdateCourierStatusMappingCommandHandler _commandHandler;

        public UpdateCourierStatusMappingsCommandHandlerTests()
        {
            MockWriteRepository(out var mockWriteRepository);
            MockReadRepository(out var mockReadRepository);
            _commandHandler = new UpdateCourierStatusMappingCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierStatusMappingCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }

        private static void MockWriteRepository(out Mock<IWriteRepository<CourierStatusMapping>> repository)
        {
            var mockRepository = new Mock<IWriteRepository<CourierStatusMapping>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierStatusMapping>(), CancellationToken.None)).Returns(Task.FromResult(new CourierStatusMapping())).Verifiable();
            repository = mockRepository;
        }

        private static void MockReadRepository(out Mock<IReadRepository<CourierStatusMapping>> repository)
        {
            var mockRepository = new Mock<IReadRepository<CourierStatusMapping>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new CourierStatusMapping())).Verifiable();
            repository = mockRepository;
        }
    }
}
