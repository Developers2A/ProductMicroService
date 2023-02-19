using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Features.Cities.Commands.CreateCity;
using Postex.Product.Domain.Locations;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Cities.Commands
{
    public class CreateCityCommandHandlerTests : BaseHandlerTest<City>
    {
        private readonly CreateCityCommandHandler _commandHandler;
        private IMapper _mapper;

        public CreateCityCommandHandlerTests()
        {
            _mapper = MockMapper();
            _commandHandler = new CreateCityCommandHandler(_writeRepository.Object, _mapper);
        }

        private CreateCityCommand CreateValidCommand()
        {
            return new CreateCityCommand()
            {
                Name = "تهران",
                Code = 1,
                EnglishName = "Tehran"
            };
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_AddAsyncIsCalled()
        {
            var result = await _commandHandler.Handle(CreateValidCommand(), new CancellationToken());

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<City>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(CreateValidCommand(), new CancellationToken());
            result.Should().Be(MediatR.Unit.Value);
        }


        private static IMapper MockMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<City, CityDto>().ReverseMap();
                cfg.CreateMap<City, CreateCityCommand>().ReverseMap();
            });
            return mockMapper.CreateMapper();
        }
    }
}
