using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Ichi.Common
{
    public class BlinkAnimation : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup group;
        private Tween tween;

        void Start() {
            this.tween = this.group.DOFade(0f, 1f).From().SetLoops(-1, LoopType.Yoyo);
        }

        void OnEnable() {
            this.tween.Restart();
        }
    }
}
