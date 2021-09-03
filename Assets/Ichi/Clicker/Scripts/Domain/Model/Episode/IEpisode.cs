using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface IEpisode
    {
        IEnumerable<ISentence> Sentences { get; }
        bool IsLock { get; }
    }
}
