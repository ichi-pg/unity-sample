using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    [Serializable]
    public class Enemy : IEnemy, IStore
    {
        public int level;
        public int rank;
        public Common.BigNumber damage;
        public int Rank { get => this.rank; }
        public BigInteger Damage { get => this.damage; }
        public BigIntegerStatus HP { get; set; }
        public bool IsAlive { get => this.Damage < this.HP; }
        public Subject<BigInteger> onDamage;
        public IObservable<BigInteger> OnDamage { get => this.onDamage; }

        public void Calculate() {
            this.HP.Calculate(this.level, this.rank);
        }

        public void Store(BigInteger i) {
            if (i < 0) {
                throw new Exception("Invalid store.");
            }
            if (!this.IsAlive) {
                throw new Exception("Invalid alive.");
            }
            this.damage += i;
            if (this.damage > this.HP) {
                this.damage = this.HP;
            }
            this.onDamage.OnNext(i);
        }
    }
}
