using System.Linq;
using CAFU.Core.Presentation.View;
using CAFU.Pager.Presentation.Presenter;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Example.CAFU.Pager.Presentation.View
{
    public class TextsRenderer : MonoBehaviour, IView
    {
        public Text[] Cells;

        private readonly string[] Data = Enumerable.Range(1, 29).Select(it => it.ToString()).ToArray();

        public void Start()
        {
            this.GetPresenter<IPagerPresenter>()
                .GetPagerOffsetAsObservable()
                .Subscribe(this.Render)
                .AddTo(this);
        }

        private void Render(int offset)
        {
            for (int i = 0; i < this.Cells.Length; i++)
            {
                if (i + offset >= this.Data.Length - 1)
                {
                    this.Cells[i].enabled = false;
                }
                else
                {
                    this.Cells[i].enabled = true;
                    this.Cells[i].text = this.Data[offset + i];
                }
            }
        }
    }
}