using UnityEngine;
using Zenject;

namespace Ichi.Clicker.View
{
    public class ClickerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var timeRepository = new Offline.TimeRepository();
            var saveDataRepository = new Offline.JsonSaveDataRepository(timeRepository);
            var enemyRepository = new Offline.EnemyRepository(saveDataRepository, timeRepository);
            var clickerRepository = new Offline.ClickerRepository(saveDataRepository, enemyRepository);
            var factoryRepository = new Offline.FactoryRepository(timeRepository, saveDataRepository);
            var feverRepository = new Offline.FeverRepository(timeRepository, saveDataRepository, clickerRepository);
            var loginRepository = new Offline.LoginRepository(timeRepository, saveDataRepository);
            var coinRepository = new Offline.CoinRepository(saveDataRepository);
            var commodityRepository = new Offline.CommodityRepository(saveDataRepository);
            var expRepository = new Offline.EXPRepository(saveDataRepository);
            var episodeRepository = new Offline.EpisodeRepository(saveDataRepository);
            var textLocalizer = new Common.TextLocalizer("Ichi.Clicker");
            var resourceLoader = new Common.ResourceLoader();
            var adsCreator = new Common.GoogleAdsCreator();
            var factoryRepositories = new FactoryRepositories(factoryRepository, clickerRepository);
            var itemRepositories = new ItemRepositories(coinRepository, commodityRepository, loginRepository, expRepository);

            Container.Bind<IFactoryRepositories>().To<FactoryRepositories>().FromInstance(factoryRepositories).AsTransient();
            Container.Bind<IClickerRepository>().To<Offline.ClickerRepository>().FromInstance(clickerRepository).AsTransient();
            Container.Bind<IFactoryRepository>().To<Offline.FactoryRepository>().FromInstance(factoryRepository).AsTransient();
            Container.Bind<IItemRepositories>().To<ItemRepositories>().FromInstance(itemRepositories).AsTransient();
            Container.Bind<ICoinRepository>().To<Offline.CoinRepository>().FromInstance(coinRepository).AsTransient();
            Container.Bind<ICommodityRepository>().To<Offline.CommodityRepository>().FromInstance(commodityRepository).AsTransient();
            Container.Bind<ILoginRepository>().To<Offline.LoginRepository>().FromInstance(loginRepository).AsTransient();
            Container.Bind<IEXPRepository>().To<Offline.EXPRepository>().FromInstance(expRepository).AsTransient();
            Container.Bind<ITimeRepository>().To<Offline.TimeRepository>().FromInstance(timeRepository).AsTransient();
            Container.Bind<ISaveDataRepository>().To<Offline.JsonSaveDataRepository>().FromInstance(saveDataRepository).AsTransient();
            Container.Bind<IEnemyRepository>().To<Offline.EnemyRepository>().FromInstance(enemyRepository).AsTransient();
            Container.Bind<IFeverRepository>().To<Offline.FeverRepository>().FromInstance(feverRepository).AsTransient();
            Container.Bind<IEpisodeRepository>().To<Offline.EpisodeRepository>().FromInstance(episodeRepository).AsTransient();
            Container.Bind<Common.ITextLocalizer>().To<Common.TextLocalizer>().FromInstance(textLocalizer).AsTransient();
            Container.Bind<Common.IResourceLoader>().To<Common.ResourceLoader>().FromInstance(resourceLoader).AsTransient();
            Container.Bind<Common.IAdsCreator>().To<Common.GoogleAdsCreator>().FromInstance(adsCreator).AsTransient();
        }
    }
}
