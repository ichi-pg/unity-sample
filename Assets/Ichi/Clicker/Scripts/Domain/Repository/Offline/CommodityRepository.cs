using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class CommodityRepository : ICollectRepository
    {
        public IItem Item { get => this.saveDataRepository.SaveData.commodity; }
        private ISaveDataRepository saveDataRepository;

        public CommodityRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }

        public void Collect() {
            this.saveDataRepository.SaveData.commodity.Sell(this.saveDataRepository.SaveData.coin);
        }
    }
}
