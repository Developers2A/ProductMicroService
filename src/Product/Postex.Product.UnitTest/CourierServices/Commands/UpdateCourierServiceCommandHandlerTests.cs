using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierServices.Commands.UpdateCourierService;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierServices.Commands
{
    public class UpdateCourierServiceCommandHandlerTests
    {
        private readonly UpdateCourierServiceCommandHandler _commandHandler;

        public UpdateCourierServiceCommandHandlerTests()
        {
            MockMapper(out var mapper);
            MockWriteRepository(out var mockWriteRepository);
            MockReadRepository(out var mockReadRepository);
            _commandHandler = new UpdateCourierServiceCommandHandler(mockWriteRepository.Object, mockReadRepository.Object, mapper);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierServiceCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }

        private static void MockMapper(out IMapper mapper)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourierService, UpdateCourierServiceCommand>().ReverseMap();
            });
            mapper = mockMapper.CreateMapper();
        }

        private static void MockWriteRepository(out Mock<IWriteRepository<CourierService>> repository)
        {
            var mockRepository = new Mock<IWriteRepository<CourierService>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierService>(), CancellationToken.None)).Returns(Task.FromResult(new CourierService())).Verifiable();
            repository = mockRepository;
        }

        private static void MockReadRepository(out Mock<IReadRepository<CourierService>> repository)
        {
            var mockRepository = new Mock<IReadRepository<CourierService>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new CourierService())).Verifiable();
            repository = mockRepository;
        }
    }
}
