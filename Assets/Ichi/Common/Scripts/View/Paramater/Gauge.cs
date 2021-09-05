using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Common
{
    public static class Gauge
    {
        public static void ResizeX(Image image, Image parent, float rate) {
            var size = image.rectTransform.sizeDelta;
            size.x = parent.rectTransform.sizeDelta.x * rate;
            image.rectTransform.sizeDelta = size;
        }

        public static void ResizeY(Image image, Image parent, float rate) {
            var size = image.rectTransform.sizeDelta;
            size.y = parent.rectTransform.sizeDelta.y * rate;
            image.rectTransform.sizeDelta = size;
        }
    }
}
