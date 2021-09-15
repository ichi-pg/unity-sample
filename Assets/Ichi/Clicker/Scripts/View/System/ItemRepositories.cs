
using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.View
{
    public class ItemRepositories : IItemRepositories
    {
        private ICoinRepository coinRepository;
        private ICommodityRepository commodityRepository;
        private ILoginRepository loginRepository;
        private IEXPRepository expRepository;

        public ItemRepositories(ICoinRepository coinRepository, ICommodityRepository commodityRepository, ILoginRepository loginRepository, IEXPRepository expRepository) {
            this.coinRepository = coinRepository;
            this.commodityRepository = commodityRepository;
            this.loginRepository = loginRepository;
            this.expRepository = expRepository;
        }

        public IItemRepository Get(ItemCategory category) {
            switch (category) {
                case ItemCategory.Coin:
                    return this.coinRepository;
                case ItemCategory.Commodity:
                    return this.commodityRepository;
                case ItemCategory.Login:
                    return this.loginRepository;
                case ItemCategory.EXP:
                    return this.expRepository;
            }
            throw new Exception("Invalid category.");
        }
    }
}
