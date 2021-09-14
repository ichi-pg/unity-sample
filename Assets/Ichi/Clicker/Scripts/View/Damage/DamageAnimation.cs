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
        private Transform root;
        [SerializeField]
        private Text text;
        [SerializeField]
        private Image image;

        void Start() {
            //ボヨンボヨン
            this.transform.localScale = Vector3.zero;
            this.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic);
            //フェードアウト
            this.image.DOFade(0f, 2f);
            this.text.DOFade(0f, 2f).OnComplete(() => {
                Destroy(this.gameObject);
            });
            //TODO キャラもアニメしないと物足りない。表情も変えたい。欲を言えばLive2D。
            //TODO SE
        }

        public void SetDamage(System.Numerics.BigInteger damage) {
            this.text.text = damage.ToString();
        }
    }
}
