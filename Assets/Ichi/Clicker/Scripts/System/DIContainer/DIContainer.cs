using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public static class DIContainer
    {
        public static IFactoryRepository FactoryRepository { get; private set; } = new Offline.FactoryRepository();
        public static IFeverRepository FeverRepository { get; private set; } = new Offline.FeverRepository();
        public static ILoginRepository LoginRepository { get; private set; } = new Offline.LoginRepository();
        public static ICoinRepository CoinRepository { get; private set; } = new Offline.CoinRepository();
        public static IProductRepository ProductRepository { get; private set; } = new Offline.ProductRepository();
        public static ISaveRepository SaveRepository { get; private set; } = new Offline.SaveRepository();
        public static Common.ITextLocalizer TextLocalizer { get; private set; } = new Common.TextLocalizer("Ichi.Clicker");
        public static Common.IResourceLoader ResourceLoader { get; private set; } = new Common.ResourceLoader();

        //TODO Extenject or VContainer ?
    }
}
