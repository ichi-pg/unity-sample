using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class EpisodeView : MonoBehaviour, Common.IChildView<IEpisode>
    {
        [SerializeField]
        private GameObject read;
        private IEpisode episode;

        public void Initialize(IEpisode episode) {
            this.episode = episode;
        }

        public async void Read() {
            //NOTE リスト消す、共通モダルコントロール
            //NOTE どこ親
            var obj = Instantiate(this.read, this.GetComponentInParent<Canvas>().transform);
            await obj.GetComponent<NovelView>().Play(this.episode);
            Destroy(obj);
        }
    }
}
