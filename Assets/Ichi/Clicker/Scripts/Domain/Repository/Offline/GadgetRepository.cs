using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ichi.Clicker.Offline
{
    public class GadgetRepository : IGadgetRepository
    {
        private ISaveDataRepository saveDataRepository;

        public GadgetRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }

        public IEnumerable<IGadget> GetGadgets(GadgetCategory category) {
            return this.saveDataRepository.SaveData.Gadgets
                .Where(gadget => gadget.Category == category);
        }

        private Item GetCost(IGadget gadget) {
            return this.saveDataRepository.SaveData.items
                .FirstOrDefault(item => item.category == gadget.CostCategory);
        }

        public bool CanLevelUp(IGadget gadget) {
            return !gadget.IsLock && this.GetCost(gadget).Quantity >= gadget.Cost;
        }

        public void LevelUp(IGadget gadget) {
            (gadget as ILevelUpper).LevelUp(this.GetCost(gadget));
            this.saveDataRepository.Save();
        }
    }
}
