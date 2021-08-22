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
                    } else {
                        instance = new SaveData() {
                            Factories = new List<Factory>(),
                            Items = new List<Item>(),
                        };
                    }
                    Initializer.Initialize(
                        instance.Factories,
                        instance.Items
                    );
                }
                return instance;
            }
        }

        public List<Factory> Factories;
        public List<Item> Items;

        private SaveData() {
        }

        public void Save() {
            Ichi.Common.JsonSaveData.Save<SaveData>(this);
        }
    }
}
