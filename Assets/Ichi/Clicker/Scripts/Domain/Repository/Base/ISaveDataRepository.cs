using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface ISaveDataRepository
    {
        SaveData SaveData { get; }
        void Save();
    }
}
