using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker.Offline
{
    public class LoginRepository : ILoginRepository
    {
        public BigInteger Quanity { get => 0; }
        public int Percentage { get => 0; }

        public void PreProduce() {
        }

        public void Produce(bool bonus) {
        }
    }
}
