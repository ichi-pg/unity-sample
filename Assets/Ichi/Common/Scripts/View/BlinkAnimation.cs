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
        private Text text;

        void Start() {
            this.text.DOFade(0f, 1f).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
