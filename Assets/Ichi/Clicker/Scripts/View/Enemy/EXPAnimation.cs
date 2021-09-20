using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Ichi.Clicker.View
{
    public class EXPAnimation : MonoBehaviour
    {
        [SerializeField]
        private Common.Poolable poolable;
        [SerializeField]
        private Image image;

        public void Play(Transform target) {
            //インジケーターに向かう
            this.transform.DOMove(target.position, 0.5f).OnComplete(() => {
                this.poolable.Return();
            });
            //フェードインアウト
            this.image.color = new Color(1f, 1f, 1f, 0f);
            this.image.DOFade(1f, 0.25f).OnComplete(() => {
                // this.image.DOFade(0f, 0.25f).OnComplete();
            });
        }
    }
}
