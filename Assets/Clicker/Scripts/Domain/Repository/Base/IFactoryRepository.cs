using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public interface IFactoryRepository
    {
        IEnumerable<Factory> List();
        IEnumerable<Factory> ListBuyable();
        void LevelUp(Factory factory);
        void Produce(Factory factory);
        void Buy(Factory factory);
    }
}
