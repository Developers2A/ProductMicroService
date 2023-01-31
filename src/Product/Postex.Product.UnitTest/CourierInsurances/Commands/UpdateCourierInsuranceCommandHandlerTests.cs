using FluentAssertions;
using MediatR;
using Moq;
using Postex.Product.Application.Features.CourierInsurances.Commands.UpdateCourierInsurance;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierInsurances.Commands
{
    public class UpdateCourierInsuranceCommandHandlerTests
    {
        private readonly UpdateCourierInsuranceCommandHandler _commandHandler;

        public UpdateCourierInsuranceCommandHandlerTests()
        {
            MockWriteRepository(out var mockWriteRepository);
            MockReadRepository(out var mockReadRepository);
            _commandHandler = new UpdateCourierInsuranceCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);
        }

        [Fact]
        public async Task HandleAsync_CommandIsValid_EntityIsUpdated()
        {
            var result = await _commandHandler.Handle(new UpdateCourierInsuranceCommand(), new CancellationToken());
            result.Should().Be(Unit.Value);
        }

        private static void MockWriteRepository(out Mock<IWriteRepository<CourierInsurance>> repository)
        {
            var mockRepository = new Mock<IWriteRepository<CourierInsurance>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierInsurance>(), CancellationToken.None)).Returns(Task.FromResult(new CourierInsurance())).Verifiable();
            repository = mockRepository;
        }

        private static void MockReadRepository(out Mock<IReadRepository<CourierInsurance>> repository)
        {
            var mockRepository = new Mock<IReadRepository<CourierInsurance>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new CourierInsurance())).Verifiable();
            repository = mockRepository;
        }
    }
}
