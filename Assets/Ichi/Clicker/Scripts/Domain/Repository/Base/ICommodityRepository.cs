using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface ICommodityRepository : IItemRepository
    {
        void Collect();
    }
}
