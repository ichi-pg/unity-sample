using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker.Offline
{
    public class ItemRepository : IItemRepository
    {
        private ISaveDataRepository saveDataRepository;

        public ItemRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }

        public IItem GetItem(ItemCategory category) {
            return this.saveDataRepository.SaveData.items.FirstOrDefault(item => item.category == category);
        }
    }
}
