using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.States.Commands.CreateState;
using Postex.Product.Domain.Locations;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.States.Commands
{
    public class CreateStateCommandHandlerTests : BaseHandlerTest<State>
    {
        private readonly CreateStateCommandHandler _commandHandler;

        public CreateStateCommandHandlerTests()
        {
            _commandHandler = new CreateStateCommandHandler(_writeRepository.Object);
        }

        private CreateStateCommand CreateValidCommand()
        {
            return new CreateStateCommand()
            {
                Name = "تهران",
                Code = 1,
                EnglishName = "Tehran"
            };
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(CreateValidCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<State>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(CreateValidCommand(), new CancellationToken());

            result.Should().Be(MediatR.Unit.Value);
        }
    }
}
