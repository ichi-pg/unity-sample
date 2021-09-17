using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public interface ISaveRepository
    {
        bool Exists { get; }
        void Save();
        void Delete();
    }
}
