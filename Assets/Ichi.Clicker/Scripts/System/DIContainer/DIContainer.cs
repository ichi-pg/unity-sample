using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public static class DIContainer
    {
        public static IFactoryRepository FactoryRepository { get; private set; } = new FactoryRepository();
        public static IItemRepository ItemRepository { get; private set; } = new ItemRepository();
        public static ISaveRepository SaveRepository { get; private set; } = new SaveRepository();
        public static Ichi.Common.ITextLocalizer TextLocalizer { get; private set; } = new Ichi.Common.TextLocalizer("Ichi.Clicker");
        public static Ichi.Common.IResourceLoader ResourceLoader { get; private set; } = new Ichi.Common.ResourceLoader();

        //TODO Extenject or VContainer ?
    }
}
