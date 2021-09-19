using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class DropModal : MonoBehaviour
    {
        [SerializeField]
        private Image gadgetImage;
        [SerializeField]
        private Text rarity;

        public void Initialize(IGadget gadget, GadgetViewData data) {
            this.gadgetImage.sprite = data.GadgetSprite(gadget);
            this.rarity.text = gadget.Rarity().ToString();
            //TODO モンスターアイコン素材（ドット絵だと楽しそう）
            //NOTE 背景パンパカパーン
        }
    }
}
