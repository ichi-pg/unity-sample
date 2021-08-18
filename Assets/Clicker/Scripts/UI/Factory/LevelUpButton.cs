using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class LevelUpButton : MonoBehaviour
    {
        public void LevelUp() {
            var repository = Repositories.Instance.FactoryRepository;
            var wallet = Repositories.Instance.WalletRepository.Get();
            var factories = repository.List()
                .Where(t => wallet.Coin >= t.Cost)
                .OrderBy(t => t.LevelUpEfficiency);
            foreach (var factory in factories) {
                repository.LevelUp(factory);
                Common.PropertyInjector.Modify();
                break;
            }
        }

        //TODO ボタンのテキスト変更、Disable
    }
}
