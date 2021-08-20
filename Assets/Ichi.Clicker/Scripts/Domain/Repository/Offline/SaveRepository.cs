using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public class SaveRepository : ISaveRepository
    {
        public void Save() {
            SaveData.Instance.Save();
        }
    }
}
