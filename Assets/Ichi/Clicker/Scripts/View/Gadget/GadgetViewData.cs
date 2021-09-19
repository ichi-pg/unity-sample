using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GadgetViewData", order = 1)]
    public class GadgetViewData : ScriptableObject
    {
        [SerializeField]
        private Sprite descSprite;
        [SerializeField]
        private Sprite costSprite;
        [SerializeField]
        private Sprite[] gadgetSprites;

        public Sprite CostSprite { get => this.costSprite; }
        public Sprite DescSprite { get => this.descSprite; }

        public Sprite GadgetSprite(IGadget gadget) {
            return this.gadgetSprites[gadget.Rank - 1];
        }
    }
}
