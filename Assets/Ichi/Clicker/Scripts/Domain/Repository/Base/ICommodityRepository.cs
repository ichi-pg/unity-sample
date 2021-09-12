using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface ICommodityRepository
    {
        IItem Commodity { get; }
        void Collect();
    }
}
