using System;
using CAFU.Core.Domain.UseCase;
using CAFU.Pager.Domain.Model;

namespace CAFU.Pager.Domain.UseCase
{
    public class PagerUseCase : IPagerUseCase
    {
        public class Factory : DefaultUseCaseFactory<PagerUseCase>
        {
            private PagerModel PagerModel;

            /// <summary>
            /// Do not use this function.
            /// Please use with arguments `Create(page, perPage, total)`
            /// </summary>
            /// <returns>nothing</returns>
            /// <exception cref="ArgumentException">It always throws exception</exception>
            public override PagerUseCase Create()
            {
                throw new ArgumentException("Please use PagerUseCase.Factory().Create(page, perPage, total)");
            }

            /// <summary>
            /// Create PagerUseCase
            /// </summary>
            /// <param name="page">Number of page to start. It should start from 1</param>
            /// <param name="perPage">Per page count</param>
            /// <param name="total">Total number of elements</param>
            /// <returns></returns>
            public PagerUseCase Create(int page, int perPage, int total)
            {
                this.PagerModel = new PagerModel(page, perPage, total);
                return base.Create();
            }

            protected override void Initialize(PagerUseCase instance)
            {
                base.Initialize(instance);
                instance.Initialize(this.PagerModel);
            }
        }

        public IObservable<int> OffsetAsObservable => this.PagerModel.OffsetAsObservable;
        public bool HasNext => this.PagerModel.HasNext;
        public bool HasPrevious => this.PagerModel.HasPrevious;
        public IObservable<bool> HasNextAsObservable => this.PagerModel.HasNextAsObservable;
        public IObservable<bool> HasPreviousAsObservable  => this.PagerModel.HasPreviousAsObservable;

        private PagerModel PagerModel { get; set; }

        protected void Initialize(PagerModel model)
        {
            this.PagerModel = model;
        }

        public bool GoToNext()
        {
            if (this.HasNext)
            {
                this.PagerModel.Page.Value += 1;
                return true;
            }

            return false;
        }

        public bool GoToPrevious()
        {
            if (this.HasPrevious)
            {
                this.PagerModel.Page.Value -= 1;
                return true;
            }

            return false;
        }
    }
}