using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class CommodityRepository : ICommodityRepository
    {
        public IItem Commodity { get => this.saveDataRepository.SaveData.Commodity; }
        private ISaveDataRepository saveDataRepository;

        public CommodityRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }

        public void Collect() {
            this.saveDataRepository.SaveData.Commodity.Sell(this.saveDataRepository.SaveData.Coin);
        }
    }
}
