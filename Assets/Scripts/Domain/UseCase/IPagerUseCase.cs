using System;
using CAFU.Core.Domain.UseCase;

namespace CAFU.Pager.Domain.UseCase
{
    public interface IPagerUseCase : IUseCase
    {
        IObservable<int> OffsetAsObservable { get; }

        bool HasNext { get; }
        bool HasPrevious { get; }

        IObservable<bool> HasNextAsObservable { get; }
        IObservable<bool> HasPreviousAsObservable { get; }

        bool GoToNext();
        bool GoToPrevious();
    }
}