using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public class Episode : IEpisode
    {
        private List<Sentence> sentences;
        private ILocker locker;
        public IEnumerable<ISentence> Sentences { get => this.sentences; }
        public bool IsLock { get => this.locker.IsLock; }
        public event Action AlterHandler;

        //TODO 既読管理
    }
}
