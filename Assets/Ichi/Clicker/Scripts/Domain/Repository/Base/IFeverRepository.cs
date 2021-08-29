using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IFeverRepository
    {
        TimeSpan CoolTime { get; }
        TimeSpan AdsCoolTime { get; }
        TimeSpan Interval { get; }
        bool IsAdsCoolTime { get; }
        bool IsCoolTime { get; }
        bool IsFever { get; }
        int Rate { get; }
        void Produce();
        void CoolDown();
        void CheatMode(bool enable);
        event Action AlterHandler;
    }
}
