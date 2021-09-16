using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IGadgetRepository
    {
        IEnumerable<IGadget> Gadgets { get; }
        bool CanLevelUp(IGadget gadget);
        void LevelUp(IGadget gadget);
    }
}
