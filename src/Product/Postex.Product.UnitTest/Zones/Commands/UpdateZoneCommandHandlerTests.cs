using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.Zones.Commands.UpdateZone;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Zones.Commands
{
    public class UpdateZoneCommandHandlerTests
    {
        private readonly UpdateZoneCommandHandler _commandHandler;
        public UpdateZoneCommandHandlerTests()
        {
            MockWriteRepository(out var mockWriteRepository);
            MockReadRepository(out var mockReadRepository);
            _commandHandler = new UpdateZoneCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateZoneCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }

        private static void MockWriteRepository(out Mock<IWriteRepository<Zone>> repository)
        {
            var mockRepository = new Mock<IWriteRepository<Zone>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Zone>(), CancellationToken.None)).Returns(Task.FromResult(new Zone())).Verifiable();
            repository = mockRepository;
        }

        private static void MockReadRepository(out Mock<IReadRepository<Zone>> repository)
        {
            var mockRepository = new Mock<IReadRepository<Zone>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new Zone())).Verifiable();
            repository = mockRepository;
        }
    }
}
