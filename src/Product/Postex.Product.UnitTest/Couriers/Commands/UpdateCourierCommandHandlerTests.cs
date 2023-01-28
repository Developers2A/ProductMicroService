using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.Couriers.Commands.UpdateCourier;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Couriers.Commands
{
    public class UpdateCourierCommandHandlerTests
    {
        private readonly UpdateCourierCommandHandler _commandHandler;

        public UpdateCourierCommandHandlerTests()
        {
            MockMapper(out var mapper);
            MockWriteRepository(out var mockWriteRepository);
            MockReadRepository(out var mockReadRepository);
            _commandHandler = new UpdateCourierCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }

        private static void MockMapper(out IMapper mapper)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Courier, UpdateCourierCommand>().ReverseMap();
            });
            mapper = mockMapper.CreateMapper();
        }

        private static void MockWriteRepository(out Mock<IWriteRepository<Courier>> repository)
        {
            var mockRepository = new Mock<IWriteRepository<Courier>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Courier>(), CancellationToken.None)).Returns(Task.FromResult(new Courier())).Verifiable();
            repository = mockRepository;
        }

        private static void MockReadRepository(out Mock<IReadRepository<Courier>> repository)
        {
            var mockRepository = new Mock<IReadRepository<Courier>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new Courier())).Verifiable();
            repository = mockRepository;
        }
    }
}
