using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IEpisodeRepository
    {
        IEnumerable<IEpisode> Episodes { get; }
    }
}
