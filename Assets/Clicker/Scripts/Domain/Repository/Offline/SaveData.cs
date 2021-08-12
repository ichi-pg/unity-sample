using System.Collections;
using System.Collections.Generic;

namespace Clicker
{
    [System.Serializable]
    public class SaveData
    {
        private static SaveData instance = null;
        public static SaveData Instance {
            get {
                if (instance == null) {
                    if (Common.SaveDataUtility.Exist<SaveData>()) {
                        instance = Common.SaveDataUtility.Load<SaveData>();
                    } else {
                        instance = new SaveData();
                    }
                }
                return instance;
            }
        }

        public Player Player { get; private set; } = new Player();
        public List<Factory> Factories { get; private set; } = new List<Factory>();

        private SaveData() {
        }

        public void Save() {
            Common.SaveDataUtility.Save<SaveData>(this);
        }

        //TODO スレッドセーフ
    }
}
