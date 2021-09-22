using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace Ichi.Clicker.View
{
    public class DamageAnimation : MonoBehaviour
    {
        [SerializeField]
        private Common.Poolable poolable;
        [SerializeField]
        private Text text;
        [SerializeField]
        private CanvasGroup group;

        public void Play(System.Numerics.BigInteger damage) {
            this.text.text = damage.ToString();
            //ボヨンボヨン
            this.transform.localScale = Vector3.zero;
            this.transform.DOScale(Vector3.one * Random.Range(0.5f, 2f), 1f).SetEase(Ease.OutElastic);
            //フェードアウト
            this.group.alpha = 1f;
            this.group.DOFade(0f, 2f).OnComplete(() => {
                this.poolable.Return();
            });
            //TODO SE
            //TODO きらきら
        }
    }
}
