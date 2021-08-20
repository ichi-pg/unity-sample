using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public static class Dependency
    {
        public static IFactoryRepository FactoryRepository { get; private set; } = new FactoryRepository();
        public static IWalletRepository WalletRepository { get; private set; } = new WalletRepository();
        public static ISaveRepository SaveRepository { get; private set; } = new SaveRepository();
        public static Ichi.Common.ILocalizationText LocalizationText { get; private set; } = new Ichi.Common.LocalizationText("Ichi.Clicker");
        public static Ichi.Common.IResourceLoader ResourceLoader { get; private set; } = new Ichi.Common.ResourceLoader();
    }
}
