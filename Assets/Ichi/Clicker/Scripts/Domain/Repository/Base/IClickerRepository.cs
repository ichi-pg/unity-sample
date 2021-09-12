using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IClickerRepository
    {
        IEnumerable<IClicker> Clickers { get; }
        event Action AlterHandler;
        void LevelUp(IClicker clicker);
        void Produce(IEnemy enemy);
        void CheatMode(bool enable);
        //TODO EnemyからUnLock
    }
}
