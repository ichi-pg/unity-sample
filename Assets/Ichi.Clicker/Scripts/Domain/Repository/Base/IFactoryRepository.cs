using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IFactoryRepository
    {
        IEnumerable<IFactory> Factories { get; }
        IEnumerable<IFactory> ClickFactories { get; }
        IEnumerable<IFactory> AutoFactories { get; }
        DateTime NextFeverAt { get; }
        TimeSpan FeverSpan { get; }
        TimeSpan FeverInterval { get; }
        int FeverRate { get; }
        void LevelUp(IFactory factory);
        void Produce(IFactory factory);
        void FeverProduce();
        void CheatMode(bool enable);
    }
}
