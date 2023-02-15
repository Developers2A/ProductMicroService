using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.States.Commands.UpdateState;
using Postex.Product.Domain.Locations;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.States.Commands
{
    public class UpdateStateCommandHandlerTests : BaseHandlerTest<State>
    {
        private readonly UpdateStateCommandHandler _commandHandler;

        public UpdateStateCommandHandlerTests()
        {
            _commandHandler = new UpdateStateCommandHandler(_writeRepository.Object, _readRepository.Object);
        }

        private UpdateStateCommand CreateValidCommand()
        {
            return new UpdateStateCommand()
            {
                Name = "تهران",
                Code = "123",
                EnglishName = "Tehran"
            };
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(CreateValidCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<State>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(CreateValidCommand(), new CancellationToken());

            result.Should().Be(Unit.Value);
        }
    }
}
