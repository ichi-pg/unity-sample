using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Common
{
    public class Gauge : MonoBehaviour
    {
        public enum Axis {
            Horizontal,
            Vertical,
        }

        [SerializeField]
        private RectTransform gauge;
        [SerializeField]
        private RectTransform frame;
        [SerializeField]
        private Axis axis;

        public void Resize(float rate) {
            var size = this.gauge.sizeDelta;
            switch (this.axis) {
                case Axis.Horizontal:
                    size.x = this.frame.rect.width * rate;
                    break;
                case Axis.Vertical:
                    size.y = this.frame.rect.height * rate;
                    break;
            }
            this.gauge.sizeDelta = size;
        }
    }
}
