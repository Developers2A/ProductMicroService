using AutoMapper;
using FluentAssertions;
using Moq;
using Postex.Product.Application.Features.CourierInsurances.Commands.CreateCourierInsurance;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Postex.Product.UnitTest.CourierInsurances.Commands
{
    public class CreateCourierInsuranceCommandHandlerTests
    {
        private readonly CreateCourierInsuranceCommandHandler _commandHandler;

        public CreateCourierInsuranceCommandHandlerTests()
        {
            MockMapper(out var mapper);
            MockRepository(out var mockRepository);
            _commandHandler = new CreateCourierInsuranceCommandHandler(mockRepository.Object, mapper);
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

        private static void MockRepository(out Mock<IWriteRepository<CourierInsurance>> mockRepository)
        {
            var mockCourierInsuranceRepository = new Mock<IWriteRepository<CourierInsurance>>();
            mockCourierInsuranceRepository.Setup(x => x.AddAsync(It.IsAny<CourierInsurance>(), CancellationToken.None)).Returns(Task.FromResult(new CourierInsurance())).Verifiable();
            mockCourierInsuranceRepository.Setup(x => x.UpdateAsync(It.IsAny<CourierInsurance>(), CancellationToken.None)).Returns(Task.FromResult(new CourierInsurance())).Verifiable();
            mockRepository = mockCourierInsuranceRepository;
        }
    }
}
