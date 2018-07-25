using CAFU.Core.Presentation.Presenter;
using CAFU.Pager.Domain.UseCase;
using CAFU.Pager.Presentation.Presenter;

namespace Example.CAFU.Pager.Presentation.Presenter
{
    public class SamplePresenter : IPagerPresenter
    {
        public class Factory : DefaultPresenterFactory<SamplePresenter>
        {
            protected override void Initialize(SamplePresenter instance)
            {
                base.Initialize(instance);
                instance.PagerUseCase = new PagerUseCase.Factory().Create(0, 5, 30);
            }
        }

        public IPagerUseCase PagerUseCase { get; private set; }
    }
}