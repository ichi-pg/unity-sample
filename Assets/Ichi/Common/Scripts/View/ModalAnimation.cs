using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Ichi.Common
{
    public class ModalAnimation : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup group;

        void Start() {
            this.transform.localScale = Vector3.zero;
            this.transform.DOScale(1f, 0.1f);
            this.group.DOFade(0f, 0.1f).From();
        }

        public void Close(Action onComplete) {
            this.group.DOFade(0f, 0.1f).OnComplete(() => {
                onComplete();
            });
        }
    }
}
