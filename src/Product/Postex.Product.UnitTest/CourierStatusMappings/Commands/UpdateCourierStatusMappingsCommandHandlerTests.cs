using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierStatusMappings.Commands.UpdateCourierStatusMapping;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierStatusMappings.Commands
{
    public class UpdateCourierStatusMappingsCommandHandlerTests : BaseHandlerTest<CourierStatusMapping>
    {
        private readonly UpdateCourierStatusMappingCommandHandler _commandHandler;

        public UpdateCourierStatusMappingsCommandHandlerTests()
        {
            _commandHandler = new UpdateCourierStatusMappingCommandHandler(_writeRepository.Object, _readRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new UpdateCourierStatusMappingCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<CourierStatusMapping>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierStatusMappingCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }
    }
}
