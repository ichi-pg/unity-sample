using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.View
{
    public class DIContainer
    {
        public static ITimeRepository TimeRepository { get; private set; } = new Offline.TimeRepository();
        private readonly static ISaveDataRepository saveDataRepository = new Offline.JsonSaveDataRepository();
        public static ISaveRepository SaveRepository { get; private set; } = saveDataRepository;
        public static IEnemyRepository EnemyRepository { get; private set; } = new Offline.EnemyRepository(saveDataRepository, TimeRepository);
        public static IGadgetRepository GadgetRepository { get; private set; } = new Offline.GadgetRepository(saveDataRepository);
        public static IProduceRepository ClickerRepository { get; private set; } = new Offline.ClickerRepository(saveDataRepository);
        public static IProduceRepository FactoryRepository { get; private set; } = new Offline.FactoryRepository(TimeRepository, saveDataRepository);
        public static IFeverRepository FeverRepository { get; private set; } = new Offline.FeverRepository(TimeRepository, saveDataRepository);
        public static ICoolDownRepository CoolDownRepository { get; private set; } = new Offline.CoolDownRepository(TimeRepository, saveDataRepository);
        public static ILoginRepository LoginRepository { get; private set; } = new Offline.LoginRepository(TimeRepository, saveDataRepository);
        public static ICommodityRepository CommodityRepository { get; private set; } = new Offline.CommodityRepository(saveDataRepository);
        public static IItemRepository ItemRepository { get; private set; } = new Offline.ItemRepository(saveDataRepository);
        public static IEpisodeRepository EpisodeRepository { get; private set; } = new Offline.EpisodeRepository(saveDataRepository);
        public static ISkillRepository SkillRepository { get; private set; } = new Offline.SkillRepository(saveDataRepository);
        public static Common.ITextLocalizer TextLocalizer { get; private set; } = new Common.TextLocalizer("Ichi.Clicker");
        public static Common.IResourceLoader ResourceLoader { get; private set; } = new Common.ResourceLoader();
        public static Common.IAdsCreator AdsCreator { get; private set; } = new Common.GoogleAdsCreator();

        //TODO メニュー（データ引き継ぎ、クレジット）
        //TODO 残りのフッターはダンジョンとエピソードでちょうどいいかも
    }
}
