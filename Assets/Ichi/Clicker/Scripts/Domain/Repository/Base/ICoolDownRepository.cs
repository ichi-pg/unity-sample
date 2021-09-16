using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UniRx;

namespace Ichi.Clicker
{
    public interface ICoolDownRepository
    {
        TimeSpan CoolTime { get; }
        void CoolDown();
        IObservable<int> OnAlter { get; }
    }
}
