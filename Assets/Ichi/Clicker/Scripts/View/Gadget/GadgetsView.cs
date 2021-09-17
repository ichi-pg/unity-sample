using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ichi.Common.Extensions;

namespace Ichi.Clicker.View
{
    public class GadgetsView : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Transform parent;
        [SerializeField]
        private GadgetCategory category;
        [SerializeField]
        private Sprite costSprite;
        [SerializeField]
        private Sprite[] gadgetSprites;

        void Start() {
            this.parent.DestroyChildren();
            this.parent.InstantiateChildren<GadgetView, IGadget>(
                this.prefab,
                DIContainer.FromGadgetCategory(this.category).Gadgets,
                (view, gadget) => view.Initialize(gadget, gadgetSprites, costSprite)
            );
        }
    }
}
