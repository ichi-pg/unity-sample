using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface IProductRepository
    {
        IItem Product { get; }
        void Collect();
    }
}
