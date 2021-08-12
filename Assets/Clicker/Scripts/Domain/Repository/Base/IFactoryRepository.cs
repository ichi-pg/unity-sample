using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public interface IFactoryRepository
    {
        List<Factory> List();
        Factory GetBuyable();
        void LevelUp(Factory factory);
        void Produce(Factory factory);
        void Buy(Factory factory);
    }
}
