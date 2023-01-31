using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.CourierStatusMappings.Commands.CreateCourierStatusMapping;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierStatusMappings.Commands
{
    public class CreateCourierStatusMappingCommandHandlerTests
    {
        private readonly CreateCourierStatusMappingCommandHandler _commandHandler;

        public CreateCourierStatusMappingCommandHandlerTests()
        {
            MockRepository(out var mockRepository);
            _commandHandler = new CreateCourierStatusMappingCommandHandler(mockRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierStatusMappingCommand(), new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }

        private static void MockRepository(out Mock<IWriteRepository<CourierStatusMapping>> mockRepository)
        {
            var mockClassRoomRepository = new Mock<IWriteRepository<CourierStatusMapping>>();
            mockClassRoomRepository.Setup(x => x.AddAsync(It.IsAny<CourierStatusMapping>(), CancellationToken.None)).Returns(Task.FromResult(new CourierStatusMapping())).Verifiable();
            mockClassRoomRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierStatusMapping>(), CancellationToken.None)).Returns(Task.FromResult(new CourierStatusMapping())).Verifiable();
            mockRepository = mockClassRoomRepository;
        }
    }
}
