using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class JsonSaveDataRepository : ISaveDataRepository
    {
        public SaveData SaveData { get; private set; }

        public JsonSaveDataRepository(ITimeRepository timeRepository) {
            if (Common.JsonSaveData.Exist<SaveData>()) {
                this.SaveData = Common.JsonSaveData.Load<SaveData>();
            } else {
                this.SaveData = new SaveData();
            }
            this.SaveData.Initialize(timeRepository.Now);
        }

        public void Save() {
            Common.JsonSaveData.Save<SaveData>(this.SaveData);
            //NOTE クラウドセーブ
            //NOTE バイナリ
        }
    }
}
