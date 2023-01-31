using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.Couriers.Commands.CreateCourier;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Couriers.Commands
{
    public class CreateCourierCommandHandlerTests
    {
        private readonly CreateCourierCommandHandler _commandHandler;

        public CreateCourierCommandHandlerTests()
        {
            MockMapper(out var mapper);
            MockRepository(out var mockRepository);
            _commandHandler = new CreateCourierCommandHandler(mockRepository.Object);
        }

        private static void MockMapper(out IMapper mapper)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Courier, CourierDto>().ReverseMap();
                cfg.CreateMap<Courier, CreateCourierCommand>().ReverseMap();
            });
            mapper = mockMapper.CreateMapper();
        }

        private static void MockRepository(out Mock<IWriteRepository<Courier>> mockRepository)
        {
            var mockClassRoomRepository = new Mock<IWriteRepository<Courier>>();
            mockClassRoomRepository.Setup(x => x.AddAsync(It.IsAny<Courier>(), CancellationToken.None)).Returns(Task.FromResult(new Courier())).Verifiable();
            mockClassRoomRepository.Setup(x => x.UpdateAsync(It.IsAny<Courier>(), CancellationToken.None)).Returns(Task.FromResult(new Courier())).Verifiable();
            mockRepository = mockClassRoomRepository;
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierCommand(), new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }
    }
}
