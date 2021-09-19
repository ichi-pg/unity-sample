using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Ichi.Clicker.View
{
    public class DamageAnimation : MonoBehaviour
    {
        [SerializeField]
        private Common.Poolable poolable;
        [SerializeField]
        private Text text;
        [SerializeField]
        private Image image;

        public void Play(System.Numerics.BigInteger damage) {
            this.text.text = damage.ToString();
            //ボヨンボヨン
            this.transform.localScale = Vector3.zero;
            this.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic);
            //フェードアウト
            var color = this.text.color;
            this.image.DOFade(0f, 2f);
            this.text.DOFade(0f, 2f).OnComplete(() => {
                this.poolable.Return();
                this.image.color = Color.white;
                this.text.color = color;
            });
            //TODO SE
            //TODO ランダムは数字だけにしてハートはぽよぽよさせた方が良いかも？
            //TODO お菓子食べてる感じ出したい
        }
    }
}
