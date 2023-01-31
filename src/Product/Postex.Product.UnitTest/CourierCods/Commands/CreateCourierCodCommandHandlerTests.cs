using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.CourierCods.Commands.CreateCourierCod;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierCods.Commands
{
    public class CreateCourierCodCommandHandlerTests
    {
        private readonly CreateCourierCodCommandHandler _commandHandler;

        public CreateCourierCodCommandHandlerTests()
        {
            MockMapper(out var mapper);
            MockRepository(out var mockRepository);
            _commandHandler = new CreateCourierCodCommandHandler(mockRepository.Object, mapper);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierCodCommand(), new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }

        private static void MockMapper(out IMapper mapper)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourierCod, CreateCourierCodCommand>().ReverseMap();
            });
            mapper = mockMapper.CreateMapper();
        }

        private static void MockRepository(out Mock<IWriteRepository<CourierCod>> mockRepository)
        {
            var mockClassRoomRepository = new Mock<IWriteRepository<CourierCod>>();
            mockClassRoomRepository.Setup(x => x.AddAsync(It.IsAny<CourierCod>(), CancellationToken.None)).Returns(Task.FromResult(new CourierCod())).Verifiable();
            mockClassRoomRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierCod>(), CancellationToken.None)).Returns(Task.FromResult(new CourierCod())).Verifiable();
            mockRepository = mockClassRoomRepository;
        }
    }
}
