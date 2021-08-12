using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public interface IFactoryRepository
    {
        List<Factory> ListUnlocked();
        List<Factory> ListLocked();
        void LevelUp(Factory factory);
        void Produce(Factory factory);
        void Buy(Factory factory);
    }
}
