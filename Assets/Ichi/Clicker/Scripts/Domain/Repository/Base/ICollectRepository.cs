using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface ICollectRepository : IItemRepository
    {
        void Collect();
    }
}
