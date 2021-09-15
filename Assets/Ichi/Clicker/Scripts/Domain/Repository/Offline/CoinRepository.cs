using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class CoinRepository : ICoinRepository
    {
        public IItem Item { get => this.saveDataRepository.SaveData.Coin; }
        private ISaveDataRepository saveDataRepository;

        public CoinRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }
    }
}
