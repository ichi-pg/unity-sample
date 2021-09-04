using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class EpisodeRepository : IEpisodeRepository
    {
        public IEnumerable<IEpisode> Episodes { get => SaveData.Instance.Episodes; }

        public void Read(IEpisode episode) {
            (episode as Episode).Read();
        }
    }
}
