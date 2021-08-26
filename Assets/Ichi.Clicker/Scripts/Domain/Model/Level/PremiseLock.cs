using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Ichi.Clicker
{
    public class PremiseLock : ILock
    {
        private ICost self;
        private ICost premise;

        public bool IsLock {
            get => this.premise != null && this.premise.Cost < this.self.Cost;
        }

        public PremiseLock(ICost self, ICost premise) {
            this.self = self;
            this.premise = premise;
        }
    }
}
