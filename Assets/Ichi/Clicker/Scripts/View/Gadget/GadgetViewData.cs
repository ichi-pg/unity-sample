using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GadgetViewData", order = 1)]
    public class GadgetViewData : ScriptableObject
    {
        [SerializeField]
        private GadgetCategory category;
        [SerializeField]
        private Sprite descSprite;
        [SerializeField]
        private Sprite costSprite;
        [SerializeField]
        private Sprite[] gadgetSprites;

        public Sprite[] GadgetSprites { get => this.gadgetSprites; }
        public Sprite CostSprite { get => this.costSprite; }
        public Sprite DescSprite { get => this.descSprite; }

        public string Name(IGadget gadget) {
            var name = (Rarity)(gadget.Rarity - 1) + " " +
                DIContainer.TextLocalizer.Localize(this.category.ToString() + gadget.Rank);
            if (gadget.IsBought) {
                return name + " Lv" + gadget.Level + " ";
            }
            return name;
        }
    }
}
