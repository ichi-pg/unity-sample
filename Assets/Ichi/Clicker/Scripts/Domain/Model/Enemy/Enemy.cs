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
        public Common.BigNumber hp;
        public int Rank { get => this.rank; }
        public BigInteger HP { get => this.hp; }
        public BigInteger MaxHP { get; set; }
        public event Action AlterHandler;

        public void Store(BigInteger i) {
            if (i < 0) {
                throw new Exception("Invalid store.");
            }
            if (this.hp < 0) {
                throw new Exception("Invalid hp.");
            }
            this.hp -= i;
            if (this.hp < 0) {
                this.hp = 0;
            }
            //TODO 弱点
            //TODO 倒した時
            this.AlterHandler?.Invoke();
        }
    }
}
