using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IEpisode
    {
        IEnumerable<Common.INovel> Novels { get; }
        bool IsRead { get; }
        bool IsLock { get; }
    }
}
