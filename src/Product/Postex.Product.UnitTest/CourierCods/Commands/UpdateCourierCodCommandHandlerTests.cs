using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierCods.Commands.UpdateCourierCod;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierCods.Commands
{
    public class UpdateCourierCodCommandHandlerTests : BaseHandlerTest<CourierCod>
    {
        private readonly UpdateCourierCodCommandHandler _commandHandler;

        public UpdateCourierCodCommandHandlerTests()
        {
            _commandHandler = new UpdateCourierCodCommandHandler(_writeRepository.Object, _readRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new UpdateCourierCodCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<CourierCod>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierCodCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }
    }
}
