using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface IFactoryRepository
    {
        IEnumerable<Factory> List();
        IEnumerable<Factory> List(FactoryCategory category, bool isLocked = false);
        void LevelUp(Factory factory);
        void Produce(Factory factory);
        void Collect(Factory factory);
    }
}
