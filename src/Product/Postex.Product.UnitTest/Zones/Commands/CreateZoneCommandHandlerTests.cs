using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.Zones.Commands.CreateZone;
using Postex.Product.Domain.Locations;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Zones.Commands
{
    public class CreateZoneCommandHandlerTests : BaseHandlerTest<Zone>
    {
        private readonly CreateZoneCommandHandler _commandHandler;

        public CreateZoneCommandHandlerTests()
        {
            _commandHandler = new CreateZoneCommandHandler(_writeRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new CreateZoneCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<Zone>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateZoneCommand() { Name = "test" }, new CancellationToken());

            result.Should().Be(MediatR.Unit.Value);
        }
    }
}
