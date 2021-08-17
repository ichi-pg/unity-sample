using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    public interface IFactoryRepository
    {
        IEnumerable<Factory> List();
        void LevelUp(Factory factory);
        void Produce(Factory factory);
    }
}
