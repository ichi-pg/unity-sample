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
        private Sprite[] sprites;
        [SerializeField]
        private Image image;
        [SerializeField]
        private RectTransform rect;

        void Start() {
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
            this.image.DOFade(0f, 2f).OnComplete(() => {
                Destroy(this.gameObject);
            });
            //TODO SE
        }

        public void SetSprite(int index) {
            image.sprite = this.sprites[index];
        }
    }
}
