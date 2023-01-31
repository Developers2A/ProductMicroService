using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.CourierLimitValues.Commands.CreateCourierLimitValue;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimitValues.Commands
{
    public class CreateCourierLimitValueCommandHandlerTests
    {
        private readonly CreateCourierLimitValueCommandHandler _commandHandler;

        public CreateCourierLimitValueCommandHandlerTests()
        {
            MockMapper(out var mapper);
            MockRepository(out var mockRepository);
            _commandHandler = new CreateCourierLimitValueCommandHandler(mockRepository.Object, mapper);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierLimitValueCommand(), new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }

        private static void MockMapper(out IMapper mapper)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourierLimitValue, CreateCourierLimitValueCommand>().ReverseMap();
            });
            mapper = mockMapper.CreateMapper();
        }

        private static void MockRepository(out Mock<IWriteRepository<CourierLimitValue>> mockRepository)
        {
            var mockClassRoomRepository = new Mock<IWriteRepository<CourierLimitValue>>();
            mockClassRoomRepository.Setup(x => x.AddAsync(It.IsAny<CourierLimitValue>(), CancellationToken.None)).Returns(Task.FromResult(new CourierLimitValue())).Verifiable();
            mockClassRoomRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierLimitValue>(), CancellationToken.None)).Returns(Task.FromResult(new CourierLimitValue())).Verifiable();
            mockRepository = mockClassRoomRepository;
        }
    }
}
