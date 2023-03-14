using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.Provinces.Commands.CreateProvince;
using Postex.Product.Domain.Locations;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.Provinces.Commands
{
    public class CreateProvinceCommandHandlerTests : BaseHandlerTest<Province>
    {
        private readonly CreateProvinceCommandHandler _commandHandler;

        public CreateProvinceCommandHandlerTests()
        {
            _commandHandler = new CreateProvinceCommandHandler(_writeRepository.Object);
        }

        private CreateProvinceCommand CreateValidCommand()
        {
            return new CreateProvinceCommand()
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

            _writeRepository.Verify(e => e.AddAsync(It.IsAny<Province>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsCreated()
        {
            var result = await _commandHandler.Handle(CreateValidCommand(), new CancellationToken());

            result.Should().Be(MediatR.Unit.Value);
        }
    }
}
