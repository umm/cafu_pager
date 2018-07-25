using CAFU.Core.Presentation.View;
using CAFU.Pager.Presentation.Presenter;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Example.CAFU.Pager.Presentation.View
{
    public class ButtonNext : MonoBehaviour, IView
    {
        void Start()
        {
            this.GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => this.GetPresenter<IPagerPresenter>().GoToNextPage())
                .AddTo(this)
                ;
        }
    }
}