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
                    if (Common.JsonSaveData.Exist<SaveData>()) {
                        instance = Common.JsonSaveData.Load<SaveData>();
                        Initializer.Load(instance.Factories);
                    } else {
                        Wallet wallet;
                        List<Factory> factories;
                        Initializer.Initialize(
                            out wallet,
                            out factories
                        );
                        instance = new SaveData();
                        instance.Wallet = wallet;
                        instance.Factories = factories;
                    }
                }
                return instance;
            }
        }

        public Wallet Wallet;
        public List<Factory> Factories;

        private SaveData() {
        }

        public void Save() {
            Common.JsonSaveData.Save<SaveData>(this);
        }
    }
}
