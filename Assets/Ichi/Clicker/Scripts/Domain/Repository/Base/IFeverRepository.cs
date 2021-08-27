using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IFeverRepository
    {
        DateTime NextFeverAt { get; }
        TimeSpan FeverSpan { get; }
        TimeSpan FeverInterval { get; }
        int FeverRate { get; }
        void Produce();
        void CheatMode(bool enable);
    }
}
