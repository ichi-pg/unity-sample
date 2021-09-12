using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public static class DIContainer
    {
        public static ITimeRepository TimeRepository { get; private set; } = new Offline.TimeRepository();
        public static IClickerRepository ClickerRepository { get; private set; } = new Offline.ClickerRepository();
        public static IFactoryRepository FactoryRepository { get; private set; } = new Offline.FactoryRepository(TimeRepository);
        public static IFeverRepository FeverRepository { get; private set; } = new Offline.FeverRepository(TimeRepository);
        public static ILoginRepository LoginRepository { get; private set; } = new Offline.LoginRepository(TimeRepository);
        public static ICoinRepository CoinRepository { get; private set; } = new Offline.CoinRepository();
        public static ICommodityRepository CommodityRepository { get; private set; } = new Offline.CommodityRepository();
        public static IEpisodeRepository EpisodeRepository { get; private set; } = new Offline.EpisodeRepository();
        public static ISaveRepository SaveRepository { get; private set; } = new Offline.SaveRepository();
        public static Common.ITextLocalizer TextLocalizer { get; private set; } = new Common.TextLocalizer("Ichi.Clicker");
        public static Common.IResourceLoader ResourceLoader { get; private set; } = new Common.ResourceLoader();
        public static Common.IAdsCreator AdsCreator { get; private set; } = new Common.GoogleAdsCreator();
        //TODO View namespace

        //NOTE Extenject

        //TODO SE
        //TODO BGM
    }
}
