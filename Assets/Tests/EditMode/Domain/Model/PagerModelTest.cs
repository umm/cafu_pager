using CAFU.Pager.Domain.Model;
using ExtraUniRx;
using NUnit.Framework;

namespace EditModeTest.CAFU.Pager.Domain.UseCase
{
    public class PagerModelTest
    {
        [Test]
        public void HasNextTest()
        {
            {
                var model = new PagerModel(0, 5, 30);
                var observer = new TestObserver<bool>();
                model.HasNextAsObservable.Subscribe(observer);

                Assert.IsTrue(model.HasNext);
                Assert.IsTrue(observer.OnNextLastValue);
                model.Page.Value += 4;
                Assert.IsTrue(model.HasNext);
                Assert.IsTrue(observer.OnNextLastValue);
                model.Page.Value += 1;
                Assert.IsFalse(model.HasNext);
                Assert.IsFalse(observer.OnNextLastValue);
            }

            {
                var model = new PagerModel(0, 1, 1);
                var observer = new TestObserver<bool>();
                model.HasNextAsObservable.Subscribe(observer);

                Assert.IsFalse(model.HasNext);
                Assert.IsFalse(observer.OnNextLastValue);

                model.Page.Value = 1;
                Assert.IsFalse(model.HasNext);
                Assert.IsFalse(observer.OnNextLastValue);
            }
        }

        [Test]
        public void HasPreviousTest()
        {
            {
                var model = new PagerModel(0, 5, 30);
                var observer = new TestObserver<bool>();
                model.HasPreviousAsObservable.Subscribe(observer);

                Assert.IsFalse(model.HasPrevious);
                Assert.IsFalse(observer.OnNextLastValue);
                model.Page.Value += 1;
                Assert.IsTrue(model.HasPrevious);
                Assert.IsTrue(observer.OnNextLastValue);
            }

            {
                var model = new PagerModel(0, 1, 1);
                var observer = new TestObserver<bool>();
                model.HasPreviousAsObservable.Subscribe(observer);

                Assert.IsFalse(model.HasPrevious);
                Assert.IsFalse(observer.OnNextLastValue);
            }
        }

        [Test]
        public void PageOffsetTest()
        {
            {
                var model = new PagerModel(0, 5, 30);
                var observer = new TestObserver<int>();
                model.OffsetAsObservable.Subscribe(observer);

                Assert.AreEqual(0, observer.OnNextLastValue);
                model.Page.Value += 1;
                Assert.AreEqual(5, observer.OnNextLastValue);
            }

            {
                var model = new PagerModel(0, 1, 1);
                var observer = new TestObserver<int>();
                model.OffsetAsObservable.Subscribe(observer);

                Assert.AreEqual(0, observer.OnNextLastValue);
            }
        }
    }
}