using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    public class CoinAnimation : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] sprites;

        async void Start() {
            var rect = this.GetComponent<RectTransform>();
            var image = this.GetComponent<Image>();
            var pos = rect.localPosition;
            rect.DOLocalRotate(Vector3.up * 360 * 8, 2, RotateMode.FastBeyond360);
            pos.y += rect.rect.height*2;
            rect.DOLocalMove(pos, 0.2f).OnComplete(() => {
                pos.y -= rect.rect.height*2;
                rect.DOLocalMove(pos, 0.8f).SetEase(Ease.OutBounce);
            });
            image.DOFade(0, 2).OnComplete(() => {
                Destroy(this.gameObject);
            });
        }

        public void SetSprite(int index) {
            var image = this.GetComponent<Image>();
            image.sprite = this.sprites[index];
        }
    }
}
