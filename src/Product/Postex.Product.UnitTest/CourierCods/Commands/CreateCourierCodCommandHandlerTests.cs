using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.CourierCods.Commands.CreateCourierCod;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierCods.Commands
{
    public class CreateCourierCodCommandHandlerTests : BaseHandlerTest<CourierCod>
    {
        private readonly CreateCourierCodCommandHandler _commandHandler;

        public CreateCourierCodCommandHandlerTests()
        {
            MockMapper(out var mapper);
            _commandHandler = new CreateCourierCodCommandHandler(_writeRepository.Object, mapper);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new CreateCourierCodCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<CourierCod>(), CancellationToken.None), Times.Once);
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
    }
}
