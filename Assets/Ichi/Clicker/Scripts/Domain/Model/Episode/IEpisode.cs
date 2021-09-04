using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IEpisode
    {
        IEnumerable<ISentence> Sentences { get; }
        bool IsRead { get; }
        bool IsLock { get; }
        event Action AlterHandler;
    }
}
