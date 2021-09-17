using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    [Serializable]
    public class Enemy : IEnemy, IAliveStore
    {
        public int level;
        public int rank;
        public Common.BigNumber damage;
        public int Rank { get => this.rank; }
        public BigInteger Damage { get => this.damage; }
        public BigIntegerStatus HP { get; private set; }
        public bool IsAlive { get => this.Damage < this.HP; }

        public Enemy(int rank) {
            this.level = 1;
            this.rank = rank;
            this.Initialize();
        }

        public void PreSave() {
            this.damage.PreSave();
        }

        public void PostLoad() {
            this.damage.PostLoad();
            this.Initialize();
        }

        private void Initialize() {
            this.HP = new BigIntegerStatus(new HPCalculator());
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
        }
    }
}
