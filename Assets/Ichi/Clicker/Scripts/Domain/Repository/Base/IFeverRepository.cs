using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IFeverRepository
    {
        TimeSpan CoolTime { get; }
        TimeSpan Duration { get; }
        TimeSpan Interval { get; }
        TimeSpan RemainDuration { get; }
        int Rate { get; }
        void Produce();
        void CoolDown();
        void CheatMode(bool enable);
        event Action AlterHandler;
    }
}
