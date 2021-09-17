using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IAliveStore : IStore
    {
        bool IsAlive { get; }
    }
}
