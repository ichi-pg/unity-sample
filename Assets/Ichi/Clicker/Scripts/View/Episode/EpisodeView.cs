using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Common.WaitTapButton))]
    public class EpisodeView : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public async UniTask Play(IEnumerable<ISentence> sentences) {
            var wait = this.GetComponent<Common.WaitTapButton>();
            var token = this.GetCancellationTokenOnDestroy();
            foreach (var sentence in sentences) {
                this.text.text = sentence.Text;
                await wait.Wait(token);
                //TODO 文字送り
                //TODO ウィンドウ開閉アニメ
            }
        }

        //TODO トリガー遷移
        //TODO 丸ごとCommonにできそう。宴でいいって話はあるけど。
    }
}
