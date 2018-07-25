using System;
using CAFU.Core.Presentation.Presenter;
using CAFU.Pager.Domain.UseCase;

namespace CAFU.Pager.Presentation.Presenter
{
    public interface IPagerPresenter : IPresenter
    {
        IPagerUseCase PagerUseCase { get; }
    }

    public static class IPagerPresenterExtension
    {
        public static bool HasNextPage(this IPagerPresenter presenter)
        {
            return presenter.PagerUseCase.HasNext;
        }

        public static bool HasPreviousPage(this IPagerPresenter presenter)
        {
            return presenter.PagerUseCase.HasPrevious;
        }

        public static IObservable<bool> HasNextPageAsObservable(this IPagerPresenter presenter)
        {
            return presenter.PagerUseCase.HasNextAsObservable;
        }

        public static IObservable<bool> HasPreviousPageAsObservable(this IPagerPresenter presenter)
        {
            return presenter.PagerUseCase.HasPreviousAsObservable;
        }

        public static bool GoToNextPage(this IPagerPresenter presenter)
        {
            return presenter.PagerUseCase.GoToNext();
        }

        public static bool GoToPreviousPage(this IPagerPresenter presenter)
        {
            return presenter.PagerUseCase.GoToPrevious();
        }

        public static IObservable<int> GetPagerOffsetAsObservable(this IPagerPresenter presenter)
        {
            return presenter.PagerUseCase.OffsetAsObservable;
        }
    }
}