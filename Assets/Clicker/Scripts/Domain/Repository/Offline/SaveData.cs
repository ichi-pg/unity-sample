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

        public Wallet Wallet { get; private set; }
        public List<Factory> Factories { get; private set; }

        private SaveData() {
        }

        public void Save() {
            Common.SaveDataUtility.Save<SaveData>(this);
        }
    }
}
