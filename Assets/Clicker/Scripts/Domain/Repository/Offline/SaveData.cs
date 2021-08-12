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
                        instance.Factories = new List<Factory>();
                        instance.Player = new Player();
                        instance.Player.AddCoin(new Factory(1).BuyCost);
                        //TODO ドメインに置きたいかな？
                    }
                }
                return instance;
            }
        }

        public Player Player { get; private set; }
        public List<Factory> Factories { get; private set; }

        private SaveData() {
        }

        public void Save() {
            Common.SaveDataUtility.Save<SaveData>(this);
        }

        //TODO スレッドセーフ
    }
}
