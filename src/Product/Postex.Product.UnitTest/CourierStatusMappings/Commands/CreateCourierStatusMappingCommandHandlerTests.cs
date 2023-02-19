using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.CourierStatusMappings.Commands.CreateCourierStatusMapping;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierStatusMappings.Commands
{
    public class CreateCourierStatusMappingCommandHandlerTests : BaseHandlerTest<CourierStatusMapping>
    {
        private readonly CreateCourierStatusMappingCommandHandler _commandHandler;

        public CreateCourierStatusMappingCommandHandlerTests()
        {
            _commandHandler = new CreateCourierStatusMappingCommandHandler(_writeRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new CreateCourierStatusMappingCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<CourierStatusMapping>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierStatusMappingCommand(), new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }
    }
}
