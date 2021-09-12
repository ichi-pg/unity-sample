using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.Offline
{
    public class ClickerRepository : IClickerRepository
    {
        public IEnumerable<IClicker> Clickers { get => SaveData.Instance.clickers; }
        public event Action AlterHandler;
        private int cheatBonus = 1;

        public void LevelUp(IClicker clicker) {
            (clicker as Clicker).LevelUp(SaveData.Instance.Coin);
            if (CalculatorUtility.IsInflation(clicker.Level)) {
                SaveData.Instance.Save();
            }
            this.AlterHandler?.Invoke();
        }

        public void Produce(IEnemy enemy) {
            foreach (var clicker in SaveData.Instance.clickers) {
                if (clicker.IsBought) {
                    clicker.Produce(enemy as IStore, this.cheatBonus);
                }
            }
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }
    }
}
