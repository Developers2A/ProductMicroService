using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.CourierServices.Commands.CreateCourierService;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierServices.Commands
{
    public class CreateCourierServiceCommandHandlerTests
    {
        private readonly CreateCourierServiceCommandHandler _commandHandler;

        public CreateCourierServiceCommandHandlerTests()
        {
            MockMapper(out var mapper);
            MockRepository(out var mockRepository);
            _commandHandler = new CreateCourierServiceCommandHandler(mockRepository.Object, mapper);
        }

        private static void MockMapper(out IMapper mapper)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourierService, CourierServiceDto>().ReverseMap();
                cfg.CreateMap<CourierService, CreateCourierServiceCommand>().ReverseMap();
            });
            mapper = mockMapper.CreateMapper();
        }

        private static void MockRepository(out Mock<IWriteRepository<CourierService>> mockRepository)
        {
            var mockClassRoomRepository = new Mock<IWriteRepository<CourierService>>();
            mockClassRoomRepository.Setup(x => x.AddAsync(It.IsAny<CourierService>(), CancellationToken.None)).Returns(Task.FromResult(new CourierService())).Verifiable();
            mockClassRoomRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierService>(), CancellationToken.None)).Returns(Task.FromResult(new CourierService())).Verifiable();
            mockRepository = mockClassRoomRepository;
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierServiceCommand(), new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }
    }
}
