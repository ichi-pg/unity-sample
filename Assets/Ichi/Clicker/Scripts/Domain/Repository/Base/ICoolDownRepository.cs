using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UniRx;

namespace Ichi.Clicker
{
    public interface ICoolDownRepository
    {
        //TODO Skillから取得できるようになったので消す。
        TimeSpan CoolTime { get; }
        void CoolDown();
        IObservable<int> OnAlter { get; }
    }
}
