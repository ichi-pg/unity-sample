using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ichi.Clicker.View
{
    public class NovelView : MonoBehaviour
    {
        [Inject]
        private IEpisodeRepository episodeRepository;
        [SerializeField]
        private Common.NovelView novelView;
        [SerializeField]
        private Text text;

        public async UniTask Play(IEpisode episode) {
            await this.novelView.Play(episode.Novels);
            this.episodeRepository.Read(episode);
            //NOTE トリガー遷移かNewラベル
            //NOTE リストUI
            //NOTE 外で破壊
        }
    }
}
