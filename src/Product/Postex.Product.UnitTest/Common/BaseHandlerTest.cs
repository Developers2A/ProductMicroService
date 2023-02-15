using Moq;
using Postex.SharedKernel.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Threading;

namespace Postex.Product.UnitTest.Common
{
    public abstract class BaseHandlerTest<TEntity> where TEntity : BaseEntity<int>
    {
        public Mock<IWriteRepository<TEntity>> _writeRepository;
        public Mock<IReadRepository<TEntity>> _readRepository;

        public BaseHandlerTest()
        {
            MockRepository();
        }

        private void MockRepository()
        {
            var mockReadRepository = new Mock<IReadRepository<TEntity>>();
            var mockWriteRepository = new Mock<IWriteRepository<TEntity>>();
            mockWriteRepository.Setup(x => x.UpdateAsync(It.IsAny<TEntity>(), CancellationToken.None)).ReturnsAsync((TEntity)Activator.CreateInstance(typeof(TEntity))!).Verifiable();
            mockReadRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync((TEntity)Activator.CreateInstance(typeof(TEntity))!).Verifiable();
            _writeRepository = mockWriteRepository;
            _readRepository = mockReadRepository;
        }
    }
}
