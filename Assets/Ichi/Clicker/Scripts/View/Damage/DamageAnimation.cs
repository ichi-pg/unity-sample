using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Ichi.Clicker.View
{
    public class DamageAnimation : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        void Start() {
            //フェードアウト
            this.text.DOFade(0f, 2f).OnComplete(() => {
                Destroy(this.gameObject);
            });
            //TODO SE
        }

        public void SetDamage(BigInteger damage) {
            this.text.text = damage.ToString();
        }
    }
}
