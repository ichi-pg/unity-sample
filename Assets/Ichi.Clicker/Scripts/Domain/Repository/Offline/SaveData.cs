using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    [System.Serializable]
    public class SaveData
    {
        private static SaveData instance = null;
        public static SaveData Instance {
            get {
                if (instance == null) {
                    if (Ichi.Common.JsonSaveData.Exist<SaveData>()) {
                        instance = Ichi.Common.JsonSaveData.Load<SaveData>();
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
            Ichi.Common.JsonSaveData.Save<SaveData>(this);
        }
    }
}
