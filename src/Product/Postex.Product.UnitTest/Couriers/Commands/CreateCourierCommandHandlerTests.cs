using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.Couriers.Commands.CreateCourier;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Couriers.Commands
{
    public class CreateCourierCommandHandlerTests : BaseHandlerTest<Courier>
    {
        private readonly CreateCourierCommandHandler _commandHandler;

        public CreateCourierCommandHandlerTests()
        {
            MockMapper(out var mapper);
            _commandHandler = new CreateCourierCommandHandler(_writeRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new CreateCourierCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<Courier>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierCommand(), new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
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
    }
}
