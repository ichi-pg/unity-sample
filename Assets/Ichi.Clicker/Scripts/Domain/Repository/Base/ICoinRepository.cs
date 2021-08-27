using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface ICoinRepository
    {
        IItem Coin { get; }
    }
}
