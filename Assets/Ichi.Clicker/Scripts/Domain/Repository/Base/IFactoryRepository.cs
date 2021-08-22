using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface IFactoryRepository
    {
        IEnumerable<Factory> Factories { get; }
        IEnumerable<Factory> ClickFactories { get; }
        IEnumerable<Factory> AutoFactories { get; }
        void LevelUp(Factory factory);
        void Produce(Factory factory);
        void Collect(Factory factory);
    }
}
