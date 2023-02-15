using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.Zones.Commands.UpdateZone;
using Postex.Product.Domain.Locations;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Zones.Commands
{
    public class UpdateZoneCommandHandlerTests : BaseHandlerTest<Zone>
    {
        private readonly UpdateZoneCommandHandler _commandHandler;

        public UpdateZoneCommandHandlerTests()
        {
            _commandHandler = new UpdateZoneCommandHandler(_writeRepository.Object, _readRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new UpdateZoneCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<Zone>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateZoneCommand(), new CancellationToken());

            result.Should().Be(Unit.Value);
        }
    }
}
