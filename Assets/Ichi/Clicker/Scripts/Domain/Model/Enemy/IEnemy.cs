using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    public interface IEnemy
    {
        int Rank { get; }
        bool IsAlive { get; }
        BigInteger Damage { get; }
        BigIntegerStatus HP { get; }
    }
}
