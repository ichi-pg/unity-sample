using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface ISaveDataRepository
    {
        SaveData SaveData { get; }
        bool Exists { get; }
        void Save();
        void Delete();
    }
}
