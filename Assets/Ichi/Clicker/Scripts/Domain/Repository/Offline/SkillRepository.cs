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

        public bool CanLevelUp(IGadget skill) {
            return this.saveDataRepository.SaveData.Coin.Quantity >= skill.Cost;
        }

        public void LevelUp(IGadget skill) {
            //NEXT 専用コストでダイヤとか
            (skill as Skill).LevelUp(this.saveDataRepository.SaveData.Coin);
            this.saveDataRepository.Save();
        }
    }
}
