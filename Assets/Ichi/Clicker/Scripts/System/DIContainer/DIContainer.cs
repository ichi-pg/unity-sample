using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public static class DIContainer
    {
        public static IFactoryRepository FactoryRepository { get; private set; } = new Offline.FactoryRepository();
        public static IProduceRepository ProduceRepository { get; private set; } = new Offline.ProduceRepository();
        public static IFeverRepository FeverRepository { get; private set; } = new Offline.FeverRepository();
        public static ILoginRepository LoginRepository { get; private set; } = new Offline.LoginRepository();
        public static ICoinRepository CoinRepository { get; private set; } = new Offline.CoinRepository();
        public static ICommodityRepository CommodityRepository { get; private set; } = new Offline.CommodityRepository();
        public static ISaveRepository SaveRepository { get; private set; } = new Offline.SaveRepository();
        public static Common.ITextLocalizer TextLocalizer { get; private set; } = new Common.TextLocalizer("Ichi.Clicker");
        public static Common.IResourceLoader ResourceLoader { get; private set; } = new Common.ResourceLoader();
        public static Common.IAdsCreator AdsCreator { get; private set; } = new Common.GoogleAdsCreator();

        //NOTE Extenject or VContainer

        //TODO! シナリオ
        //TODO! キャラ（3Dならシェーダ・モーション、2DならLive2D）
        //TODO SE
        //TODO BGM
        //TODO 背景
        //TODO! UI素材
        //TODO UIアニメ（DOTween）
        //TODO UIエフェクト（DOTween）
    }
}
