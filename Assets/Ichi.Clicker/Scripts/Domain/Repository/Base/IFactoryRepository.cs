using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface IFactoryRepository
    {
        IEnumerable<IFactory> Factories { get; }
        IEnumerable<IFactory> ClickFactories { get; }
        IEnumerable<IFactory> AutoFactories { get; }
        void LevelUp(IFactory factory);
        void Produce(IFactory factory);
    }
}
