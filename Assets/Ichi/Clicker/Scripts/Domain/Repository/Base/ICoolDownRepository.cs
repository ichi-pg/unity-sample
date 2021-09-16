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
        bool IsCoolTime { get; }
        void CoolDown();
    }
}
