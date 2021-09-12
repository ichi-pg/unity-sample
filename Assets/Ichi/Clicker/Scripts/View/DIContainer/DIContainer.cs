using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.View
{
    public static class DIContainer
    {
        public static ITimeRepository TimeRepository { get; private set; } = new Offline.TimeRepository();
        public static ISaveDataRepository SaveDataRepository { get; private set; } = new Offline.JsonSaveDataRepository(TimeRepository);
        public static IClickerRepository ClickerRepository { get; private set; } = new Offline.ClickerRepository(SaveDataRepository);
        public static IFactoryRepository FactoryRepository { get; private set; } = new Offline.FactoryRepository(TimeRepository, SaveDataRepository);
        public static IFeverRepository FeverRepository { get; private set; } = new Offline.FeverRepository(TimeRepository, SaveDataRepository);
        public static ILoginRepository LoginRepository { get; private set; } = new Offline.LoginRepository(TimeRepository, SaveDataRepository);
        public static ICoinRepository CoinRepository { get; private set; } = new Offline.CoinRepository(SaveDataRepository);
        public static ICommodityRepository CommodityRepository { get; private set; } = new Offline.CommodityRepository(SaveDataRepository);
        public static IEpisodeRepository EpisodeRepository { get; private set; } = new Offline.EpisodeRepository(SaveDataRepository);
        public static IEnemyRepository EnemyRepository { get; private set; } = new Offline.EnemyRepository(SaveDataRepository);
        public static Common.ITextLocalizer TextLocalizer { get; private set; } = new Common.TextLocalizer("Ichi.Clicker");
        public static Common.IResourceLoader ResourceLoader { get; private set; } = new Common.ResourceLoader();
        public static Common.IAdsCreator AdsCreator { get; private set; } = new Common.GoogleAdsCreator();

        public static IClickerRepository FromFactoryCategory(FactoryCategory category) {
            switch (category) {
                case FactoryCategory.Factory:
                    return FactoryRepository;
                case FactoryCategory.Clicker:
                    return ClickerRepository;
            }
            throw new Exception("Invalid category.");
        }

        //NOTE Extenject

        //TODO SE
    }
}
