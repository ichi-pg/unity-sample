using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class EpisodeRepository : IEpisodeRepository
    {
        public IEnumerable<IEpisode> Episodes { get => this.saveDataRepository.SaveData.episodes; }
        private ISaveDataRepository saveDataRepository;

        public EpisodeRepository(ISaveDataRepository saveDataRepository) {
            this.saveDataRepository = saveDataRepository;
        }

        public void Read(IEpisode episode) {
            (episode as Episode).Read();
        }
    }
}
