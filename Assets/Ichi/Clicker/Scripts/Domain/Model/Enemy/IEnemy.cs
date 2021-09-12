using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public interface IEnemy
    {
        int Rank { get; }
        BigInteger Damage { get; }
        BigIntegerStatus HP { get; }
        event Action AlterHandler;
    }
}
