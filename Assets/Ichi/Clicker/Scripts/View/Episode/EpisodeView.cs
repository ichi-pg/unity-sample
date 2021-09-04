using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
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
            //TODO リスト消す、共通モダルコントロール
            //TODO どこ親
            var obj = Instantiate(this.read, this.GetComponentInParent<Canvas>().transform);
            await obj.GetComponent<ReadEpisodeView>().Play(this.episode);
            Destroy(obj);
        }
    }
}
