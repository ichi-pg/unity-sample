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
        float TimeLeftRate { get; }
        bool IsCoolTime { get; }
        bool IsFever { get; }
        void Fever(CancellationToken token);
        void CheatMode(bool enable);
        IObservable<int> OnAlter { get; }
    }
}
