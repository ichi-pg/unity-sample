using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class LevelLocker : ILocker
    {
        private ILevel target;
        private int level;

        public bool IsLock {
            get => this.target.Level >= this.level;
        }

        public LevelLocker(ILevel target, int level) {
            this.target = target;
            this.level = level;
        }
    }
}
