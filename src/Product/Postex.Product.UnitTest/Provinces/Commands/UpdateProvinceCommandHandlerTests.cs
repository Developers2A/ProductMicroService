using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.Provinces.Commands.UpdateProvince;
using Postex.Product.Domain.Locations;
using Postex.Product.UnitTest.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.States.Commands
{
    public class UpdateProvinceCommandHandlerTests : BaseHandlerTest<Province>
    {
        private readonly UpdateProvinceCommandHandler _commandHandler;

        public UpdateProvinceCommandHandlerTests()
        {
            _commandHandler = new UpdateProvinceCommandHandler(_writeRepository.Object, _readRepository.Object);
        }

        private UpdateProvinceCommand CreateValidCommand()
        {
            return new UpdateProvinceCommand()
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

            _writeRepository.Verify(e => e.UpdateAsync(It.IsAny<Province>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(CreateValidCommand(), new CancellationToken());

            result.Should().Be(Unit.Value);
        }
    }
}
