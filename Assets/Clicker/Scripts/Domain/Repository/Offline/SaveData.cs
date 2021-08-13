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
                        Player player;
                        List<Factory> factories;
                        Player.Initialize(
                            out player,
                            out factories
                        );
                        instance = new SaveData();
                        instance.Player = player;
                        instance.Factories = factories;
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
    }
}
