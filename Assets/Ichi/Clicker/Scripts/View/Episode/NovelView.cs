using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    [RequireComponent(typeof(Common.NovelView))]
    public class NovelView : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public async UniTask Play(IEpisode episode) {
            await this.GetComponent<Common.NovelView>().Play(episode.Sentences);
            DIContainer.EpisodeRepository.Read(episode);
            //TODO トリガー遷移かNewラベル
            //TODO リストUI
            //TODO 外で破壊
        }
    }
}
