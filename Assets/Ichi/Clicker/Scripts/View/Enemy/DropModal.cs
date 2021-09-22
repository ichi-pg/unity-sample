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
        [SerializeField]
        private GadgetViewDataList dataList;

        public void Initialize(IGadget gadget) {
            var data = this.dataList.GetViewData(gadget.GadgetCategory);
            this.gadgetImage.sprite = data.GadgetSprite(gadget);
            this.rarity.text = gadget.Rarity().ToString();
            //TODO モンスターアイコン素材（ドット絵だと楽しそう）
            //NOTE エフェクト（きらきら、ぱんぱかぱーんなど）必要性
        }

        void OnDestroy() {
            if (DIContainer.EnemyRepository.Enemy != null && DIContainer.EnemyRepository.Enemy.IsAlive) {
                return;
            }
            DIContainer.EnemyRepository.Encount();
        }
    }
}
