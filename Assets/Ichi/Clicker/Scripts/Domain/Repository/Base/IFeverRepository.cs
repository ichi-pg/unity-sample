using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

namespace Ichi.Clicker
{
    public interface IFeverRepository
    {
        TimeSpan CoolTime { get; }
        TimeSpan AdsCoolTime { get; }
        TimeSpan TimeLeft { get; }
        bool IsAdsCoolTime { get; }
        bool IsCoolTime { get; }
        bool IsFever { get; }
        int Rate { get; }
        void Fever(CancellationToken token);
        void CoolDown();
        void CheatMode(bool enable);
        event Action AlterHandler;
    }
}
