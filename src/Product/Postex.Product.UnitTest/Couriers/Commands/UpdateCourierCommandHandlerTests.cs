using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.Couriers.Commands.UpdateCourier;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Couriers.Commands
{
    public class UpdateCourierCommandHandlerTests : BaseHandlerTest<Courier>
    {
        private readonly UpdateCourierCommandHandler _commandHandler;

        public UpdateCourierCommandHandlerTests()
        {
            MockMapper(out var mapper);
            _commandHandler = new UpdateCourierCommandHandler(_writeRepository.Object, _readRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new UpdateCourierCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<Courier>(), CancellationToken.None), Times.Once);
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
    }
}
