using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class EXPRepository : IItemRepository
    {
        public IItem Item { get => this.saveDataRepository.SaveData.EXP; }
        private ISaveDataRepository saveDataRepository;

        public EXPRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }
    }
}
