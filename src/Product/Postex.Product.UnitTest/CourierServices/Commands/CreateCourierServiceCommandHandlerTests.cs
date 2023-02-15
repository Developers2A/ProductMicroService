using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.CourierServices.Commands.CreateCourierService;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierServices.Commands
{
    public class CreateCourierServiceCommandHandlerTests : BaseHandlerTest<CourierService>
    {
        private readonly CreateCourierServiceCommandHandler _commandHandler;

        public CreateCourierServiceCommandHandlerTests()
        {
            MockMapper(out var mapper);
            _commandHandler = new CreateCourierServiceCommandHandler(_writeRepository.Object, mapper);
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

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new CreateCourierServiceCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<CourierService>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierServiceCommand(), new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }
    }
}
