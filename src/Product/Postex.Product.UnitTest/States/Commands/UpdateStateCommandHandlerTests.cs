using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.States.Commands.UpdateState;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.States.Commands
{
    public class UpdateStateCommandHandlerTests
    {
        private readonly UpdateStateCommandHandler _commandHandler;

        public UpdateStateCommandHandlerTests()
        {
            MockWriteRepository(out var mockWriteRepository);
            MockReadRepository(out var mockReadRepository);
            _commandHandler = new UpdateStateCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateStateCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }

        private static void MockWriteRepository(out Mock<IWriteRepository<State>> repository)
        {
            var mockRepository = new Mock<IWriteRepository<State>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<State>(), CancellationToken.None)).Returns(Task.FromResult(new State())).Verifiable();
            repository = mockRepository;
        }

        private static void MockReadRepository(out Mock<IReadRepository<State>> repository)
        {
            var mockRepository = new Mock<IReadRepository<State>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new State())).Verifiable();
            repository = mockRepository;
        }
    }
}
