using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Ichi.Common
{
    public class PoolableReturner : MonoBehaviour
    {
        [SerializeField]
        private Common.Poolable poolable;

        void OnEnable() {
            DOVirtual.DelayedCall(0.5f, () => {
                this.poolable.Return();
            });
        }
    }
}
