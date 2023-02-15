using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Features.Cities.Commands.UpdateCity;
using Postex.Product.Domain.Locations;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Cities.Commands
{
    public class UpdateCityCommandHandlerTests : BaseHandlerTest<City>
    {
        private readonly UpdateCityCommandHandler _commandHandler;
        private IMapper _mapper;

        public UpdateCityCommandHandlerTests()
        {
            MockMapper();
            _commandHandler = new UpdateCityCommandHandler(_writeRepository.Object, _readRepository.Object, _mapper);
        }

        private UpdateCityCommand CreateValidCommand()
        {
            return new UpdateCityCommand()
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

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<City>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCityCommand(), new CancellationToken());

            result.Should().Be(Unit.Value);
        }

        private void MockMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<City, CityDto>().ReverseMap();
                cfg.CreateMap<City, UpdateCityCommand>().ReverseMap();
            });
            _mapper = mockMapper.CreateMapper();
        }
    }
}
