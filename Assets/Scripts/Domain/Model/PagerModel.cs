using System;
using UniRx;

namespace CAFU.Pager.Domain.Model
{
    public class PagerModel
    {
        public ReactiveProperty<int> Page { get; private set; }
        public int PerPage { get; private set; }
        public int Total { get; private set; }

        public IObservable<int> OffsetAsObservable => this.Page.Select(page => page * this.PerPage);

        public bool HasNext => this.HasNextInternal(this.Page.Value);
        public bool HasPrevious => this.HasPreviousInternal(this.Page.Value);
        public IObservable<bool> HasNextAsObservable => this.Page.Select(page => this.HasNextInternal(page));
        public IObservable<bool> HasPreviousAsObservable => this.Page.Select(page => this.HasPreviousInternal(page));

        private bool HasNextInternal(int page)
        {
            return (page + 1) * this.PerPage < this.Total;
        }

        private bool HasPreviousInternal(int page)
        {
            return page > 0;
        }

        public PagerModel(int page, int perPage, int total)
        {
            this.Page = new ReactiveProperty<int>(page);
            this.PerPage = perPage;
            this.Total = total;
        }
    }
}