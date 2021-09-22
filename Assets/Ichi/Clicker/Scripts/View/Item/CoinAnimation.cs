using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Ichi.Clicker.View
{
    public class CoinAnimation : MonoBehaviour
    {
        [SerializeField]
        private Common.Poolable poolable;
        [SerializeField]
        private Image image;
        [SerializeField]
        private RectTransform rect;
        [SerializeField]
        private Sprite[] sprites;

        public void Play(int index) {
            image.sprite = this.sprites[index];
            //回転する
            this.rect.DOLocalRotate(Vector3.up * 360f * 8f, 2f, RotateMode.FastBeyond360);
            //跳ねる
            var pos = this.rect.localPosition;
            pos.y += this.rect.rect.height * 2f;
            this.rect.DOLocalMove(pos, 0.2f).OnComplete(() => {
                pos.y -= this.rect.rect.height * 2f;
                this.rect.DOLocalMove(pos, 0.8f).SetEase(Ease.OutBounce);
            });
            //フェードアウト
            this.image.color = Color.white;
            this.image.DOFade(0f, 2f).OnComplete(() => {
                this.poolable.Return();
            });
            //TODO SE
            //NOTE エフェクトのブラッシュアップ（きらきらなど）と引き算
        }
    }
}
