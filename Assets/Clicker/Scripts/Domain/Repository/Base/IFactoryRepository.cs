using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public interface IFactoryRepository
    {
        IEnumerable<Factory> List();
        Factory GetBuyable();
        void LevelUp(Factory factory);
        void Produce(Factory factory);
        void Buy(Factory factory);
    }
}
