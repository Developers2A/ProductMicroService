using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierServices.Commands.UpdateCourierService;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierServices.Commands
{
    public class UpdateCourierServiceCommandHandlerTests : BaseHandlerTest<CourierService>
    {
        private readonly UpdateCourierServiceCommandHandler _commandHandler;

        public UpdateCourierServiceCommandHandlerTests()
        {
            MockMapper(out var mapper);
            _commandHandler = new UpdateCourierServiceCommandHandler(_writeRepository.Object, _readRepository.Object, mapper);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new UpdateCourierServiceCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<CourierService>(), CancellationToken.None), Times.Once);
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
    }
}
