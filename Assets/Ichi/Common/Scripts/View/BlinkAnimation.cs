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

        void Start() {
            this.group.DOFade(0f, 1f).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
