using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IClickerRepository
    {
        IEnumerable<IFactory> Factories { get; }
        event Action AlterHandler;
        void LevelUp(IFactory factory);
        void Produce();
        void CheatMode(bool enable);
        //TODO IClickerとIFactoryが敬意的にごちゃってるのでリネーム
    }
}
