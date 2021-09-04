using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public class Episode : IEpisode
    {
        public ILocker Locker { private get; set; }
        public IEnumerable<ISentence> Sentences { get; set; }
        public bool IsLock { get => this.Locker.IsLock; }
        public event Action AlterHandler;

        //TODO 既読管理
    }
}
