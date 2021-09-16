using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker.Offline
{
    public class JsonSaveDataRepository : ISaveDataRepository
    {
        public SaveData SaveData { get; private set; }
        public bool Exists { get => Common.JsonSaveData.Exist<SaveData>(); }
        private ITimeRepository timeRepository;

        public JsonSaveDataRepository(ITimeRepository timeRepository) {
            this.timeRepository = timeRepository;
            this.Load();
        }

        public void Save() {
            Common.JsonSaveData.Save<SaveData>(this.SaveData);
            //NOTE クラウドセーブ
            //NOTE バイナリ
        }

        private void Load() {
            if (this.Exists) {
                this.SaveData = Common.JsonSaveData.Load<SaveData>();
            } else {
                this.SaveData = new SaveData();
            }
            this.SaveData.Initialize(timeRepository.Now);
        }

        public void Delete() {
            Common.JsonSaveData.Delete<SaveData>();
            this.Load();
        }
    }
}
