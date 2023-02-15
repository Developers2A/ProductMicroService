using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.CourierLimitValues.Commands.CreateCourierLimitValue;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierLimitValues.Commands
{
    public class CreateCourierLimitValueCommandHandlerTests : BaseHandlerTest<CourierLimitValue>
    {
        private readonly CreateCourierLimitValueCommandHandler _commandHandler;

        public CreateCourierLimitValueCommandHandlerTests()
        {
            MockMapper(out var mapper);
            _commandHandler = new CreateCourierLimitValueCommandHandler(_writeRepository.Object, mapper);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(new CreateCourierLimitValueCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<CourierLimitValue>(), CancellationToken.None), Times.Once);
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
    }
}
