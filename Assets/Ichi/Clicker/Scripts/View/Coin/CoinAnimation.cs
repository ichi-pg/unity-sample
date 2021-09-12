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
            var pos = this.rect.localPosition;
            this.rect.DOLocalRotate(Vector3.up * 360 * 8, 2, RotateMode.FastBeyond360);
            pos.y += this.rect.rect.height*2;
            this.rect.DOLocalMove(pos, 0.2f).OnComplete(() => {
                pos.y -= this.rect.rect.height*2;
                this.rect.DOLocalMove(pos, 0.8f).SetEase(Ease.OutBounce);
            });
            this.image.DOFade(0, 2).OnComplete(() => {
                Destroy(this.gameObject);
            });
            //TODO SE
        }

        public void SetSprite(int index) {
            image.sprite = this.sprites[index];
        }
    }
}
