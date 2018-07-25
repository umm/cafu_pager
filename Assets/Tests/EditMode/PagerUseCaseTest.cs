using CAFU.Pager.Domain.UseCase;
using NUnit.Framework;

namespace EditModeTest.CAFU.Pager.Domain.UseCase
{
    public class PagerUseCaseTest
    {
        [Test]
        public void GoTest()
        {
            var usecase = new PagerUseCase.Factory().Create(0, 5, 30);

            Assert.IsTrue(usecase.HasNext);
            Assert.IsFalse(usecase.HasPrevious);

            usecase.GoToNext();
            Assert.IsTrue(usecase.HasNext);
            Assert.IsTrue(usecase.HasPrevious);

            usecase.GoToNext();
            usecase.GoToNext();
            usecase.GoToNext();
            usecase.GoToNext();

            Assert.IsFalse(usecase.HasNext);
            Assert.IsTrue(usecase.HasPrevious);

            usecase.GoToPrevious();
            Assert.IsTrue(usecase.HasNext);
            Assert.IsTrue(usecase.HasPrevious);

            usecase.GoToPrevious();
            usecase.GoToPrevious();
            usecase.GoToPrevious();
            usecase.GoToPrevious();
            usecase.GoToPrevious();

            Assert.IsTrue(usecase.HasNext);
            Assert.IsFalse(usecase.HasPrevious);
        }
    }
}