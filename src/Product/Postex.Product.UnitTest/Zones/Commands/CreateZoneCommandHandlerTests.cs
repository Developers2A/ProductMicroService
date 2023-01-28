using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.Zones.Commands.CreateZone;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Zones.Commands
{
    public class CreateZoneCommandHandlerTests
    {
        private readonly CreateZoneCommandHandler _commandHandler;

        public CreateZoneCommandHandlerTests()
        {
            MockRepository(out var mockRepository);
            _commandHandler = new CreateZoneCommandHandler(mockRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateZoneCommand() { Name = "test" }, new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }

        private static void MockRepository(out Mock<IWriteRepository<Zone>> mockRepository)
        {
            var mockClassRoomRepository = new Mock<IWriteRepository<Zone>>();
            mockClassRoomRepository.Setup(x => x.AddAsync(It.IsAny<Zone>(), CancellationToken.None)).Returns(Task.FromResult(new Zone())).Verifiable();
            mockClassRoomRepository.Setup(x => x.UpdateAsync(It.IsAny<Zone>(), CancellationToken.None)).Returns(Task.FromResult(new Zone())).Verifiable();
            mockRepository = mockClassRoomRepository;
        }
    }
}
