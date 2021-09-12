using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace Ichi.Clicker
{
    [Serializable]
    public class Enemy : IEnemy, IStore
    {
        public int rank;
        public Common.BigNumber damage;
        public int Rank { get => this.rank; }
        public BigInteger Damage { get => this.damage; }
        public BigIntegerStatus HP { get; set; }
        public bool IsAlive { get => this.Damage < this.HP; }
        public event Action AlterHandler;

        public void Calculate() {
            this.HP.Calculate(rank : this.rank);
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
            //TODO 弱点
            //TODO 倒した時
            this.AlterHandler?.Invoke();
        }
    }
}
