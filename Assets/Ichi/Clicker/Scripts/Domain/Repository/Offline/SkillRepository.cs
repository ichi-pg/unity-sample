using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker.Offline
{
    public class SkillRepository : IGadgetRepository
    {
        public IEnumerable<IGadget> Gadgets { get => this.saveDataRepository.SaveData.skills; }
        private ISaveDataRepository saveDataRepository;

        public SkillRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }

        public bool CanLevelUp(IGadget gadget) {
            return this.saveDataRepository.SaveData.Gem.Quantity >= gadget.Cost;
        }

        public void LevelUp(IGadget gadget) {
            (gadget as ILevelUpper).LevelUp(this.saveDataRepository.SaveData.Gem);
            this.saveDataRepository.Save();
        }
    }
}
