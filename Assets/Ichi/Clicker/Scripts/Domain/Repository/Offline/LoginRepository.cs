using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker.Offline
{
    public class LoginRepository : ILoginRepository
    {
        public BigInteger Quanity { get => 0; }
        public float Percentage { get => 0; }

        public void Produce() {
            //TODO
        }

        public void Collect(bool bonus) {
            //TODO
            //TODO 広告で2倍
        }
    }
}
