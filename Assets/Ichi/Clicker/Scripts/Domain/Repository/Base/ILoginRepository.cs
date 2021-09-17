using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    public interface ILoginRepository
    {
        float Rate { get; }
        bool Produce();
        void Collect(bool bonus);
    }
}
