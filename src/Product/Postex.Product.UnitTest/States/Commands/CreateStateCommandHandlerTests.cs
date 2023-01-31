using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.States.Commands.CreateState;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.States.Commands
{
    public class CreateStateCommandHandlerTests
    {
        private readonly CreateStateCommandHandler _commandHandler;

        public CreateStateCommandHandlerTests()
        {
            MockRepository(out var mockRepository);
            _commandHandler = new CreateStateCommandHandler(mockRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateStateCommand() { Name = "test", Code = "123", EnglishName = "test" }, new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }

        private static void MockRepository(out Mock<IWriteRepository<State>> mockRepository)
        {
            var mockClassRoomRepository = new Mock<IWriteRepository<State>>();
            mockClassRoomRepository.Setup(x => x.AddAsync(It.IsAny<State>(), CancellationToken.None)).Returns(Task.FromResult(new State())).Verifiable();
            mockClassRoomRepository.Setup(x => x.UpdateAsync(It.IsAny<State>(), CancellationToken.None)).Returns(Task.FromResult(new State())).Verifiable();
            mockRepository = mockClassRoomRepository;
        }
    }
}
