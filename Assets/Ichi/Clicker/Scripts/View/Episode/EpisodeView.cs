using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class EpisodeView : MonoBehaviour
    {
        [SerializeField]
        private Common.ModalOpener modalOpener;
        [SerializeField]
        private Button button;
        private IEpisode episode;

        public void Initialize(IEpisode episode) {
            this.episode = episode;
            this.button.OnClickAsObservable().Subscribe(_ => this.OpenModal().Forget()).AddTo(this);
        }

        public async UniTask OpenModal() {
            await this.modalOpener.OpenWith<Common.NovelView>().Play(this.episode.Novels);
        }
    }
}
