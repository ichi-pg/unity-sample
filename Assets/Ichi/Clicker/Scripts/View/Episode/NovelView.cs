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
            await this.GetComponent<Common.NovelView>().Play(episode.Novels);
            DIContainer.EpisodeRepository.Read(episode);
            //NOTE トリガー遷移かNewラベル
            //NOTE リストUI
            //NOTE 外で破壊
        }
    }
}
