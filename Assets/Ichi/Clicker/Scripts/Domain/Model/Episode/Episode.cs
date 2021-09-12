using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class Episode : IEpisode
    {
        public int rank;
        public int level;
        public bool isRead;
        public ILocker Locker { private get; set; }
        public IEnumerable<Common.INovel> Novels { get; set; }
        public bool IsRead { get => this.isRead; }
        public bool IsLock { get => this.Locker.IsLock; }
        // public event Action AlterHandler;

        public void Read() {
            this.isRead = true;
        }
    }
}
