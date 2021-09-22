
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Ichi.Common
{
    public class TapGenerator : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Transform parent;
        [SerializeField]
        private RectTransform target;

        private PoolablePool pool;

        void Start() {
            this.pool = new PoolablePool(this.prefab, this.parent);
        }

        public void OnPointerUp(PointerEventData eventData) {
            var pos = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                this.target,
                eventData.position,
                eventData.pressEventCamera,
                out pos
            );
            this.pool.Rent().transform.localPosition = pos;
        }
    }
}
