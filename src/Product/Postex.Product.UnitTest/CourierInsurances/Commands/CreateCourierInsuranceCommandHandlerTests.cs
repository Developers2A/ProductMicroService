using AutoMapper;
using FluentAssertions;
using Postex.Product.Application.Features.CourierInsurances.Commands.CreateCourierInsurance;
using Postex.Product.Domain.Couriers;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierInsurances.Commands
{
    public class CreateCourierInsuranceCommandHandlerTests : BaseHandlerTest<CourierInsurance>
    {
        private readonly CreateCourierInsuranceCommandHandler _commandHandler;

        public CreateCourierInsuranceCommandHandlerTests()
        {
            MockMapper(out var mapper);
            _commandHandler = new CreateCourierInsuranceCommandHandler(_writeRepository.Object, mapper);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(new CreateCourierInsuranceCommand(), new CancellationToken());

            result.Should().Be(MediatR.Unit.Value);
        }

        private static void MockMapper(out IMapper mapper)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourierInsurance, CreateCourierInsuranceCommand>().ReverseMap();
            });
            mapper = mockMapper.CreateMapper();
        }
    }
}
