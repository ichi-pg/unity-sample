using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ichi.Clicker.Offline
{
    public class SkillRepository : ISkillRepository
    {
        private ISaveDataRepository saveDataRepository;

        public SkillRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }

        public Skill GetSkill(SkillCategory category) {
            return this.saveDataRepository.SaveData.skills.FirstOrDefault(skill => skill.category == category);
        }
    }
}
