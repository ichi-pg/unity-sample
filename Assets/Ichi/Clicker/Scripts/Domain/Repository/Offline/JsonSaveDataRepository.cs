using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class JsonSaveDataRepository : ISaveDataRepository
    {
        public SaveData SaveData { get; private set; }
        public bool Exists { get => Common.JsonSaveData.Exist<SaveData>(); }

        public JsonSaveDataRepository() {
            this.Load();
        }

        public void Save() {
            Common.JsonSaveData.Save<SaveData>(this.SaveData);
            //TODO クラウドセーブ
            //TODO バイナリ
        }

        public void Load() {
            if (this.Exists) {
                this.SaveData = Common.JsonSaveData.Load<SaveData>();
            } else {
                this.SaveData = new SaveData();
            }
            this.SaveData.Initialize();
        }

        public void Delete() {
            Common.JsonSaveData.Delete<SaveData>();
            this.Load();
        }
    }
}
