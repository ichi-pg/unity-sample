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
        TimeSpan TimeLeft { get; }
        TimeSpan Duration { get; }
        void Fever();
        void CheatMode(bool enable);
        IObservable<int> OnAlter { get; }
    }
}
