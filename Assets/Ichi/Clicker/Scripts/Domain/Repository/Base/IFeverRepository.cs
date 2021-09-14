using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UniRx;

namespace Ichi.Clicker
{
    public interface IFeverRepository
    {
        TimeSpan CoolTime { get; }
        TimeSpan AdsCoolTime { get; }
        float DurationRate { get; }
        bool IsAdsCoolTime { get; }
        bool IsCoolTime { get; }
        bool IsFever { get; }
        int Rate { get; }
        void Fever(CancellationToken token);
        void CoolDown();
        void CheatMode(bool enable);
        IObservable<int> OnAlter { get; }
    }
}
