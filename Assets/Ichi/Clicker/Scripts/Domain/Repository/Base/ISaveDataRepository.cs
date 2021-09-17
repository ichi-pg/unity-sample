using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface ISaveDataRepository : ISaveRepository
    {
        SaveData SaveData { get; }
    }
}
