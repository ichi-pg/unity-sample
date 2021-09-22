using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UniRx;

namespace Ichi.Clicker
{
    public interface ICoolDownRepository
    {
        void CoolDown();
        IObservable<int> OnAlter { get; }
    }
}
