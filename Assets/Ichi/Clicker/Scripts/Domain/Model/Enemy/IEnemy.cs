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
        BigInteger Damage { get; }
        BigIntegerStatus HP { get; }
        IObservable<BigInteger> OnDamage { get; }
    }
}
