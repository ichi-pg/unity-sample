
using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.View
{
    public class FactoryRepositories : IFactoryRepositories
    {
        private IFactoryRepository factoryRepository;
        private IClickerRepository clickerRepository;

        public FactoryRepositories(IFactoryRepository factoryRepository, IClickerRepository clickerRepository) {
            this.factoryRepository = factoryRepository;
            this.clickerRepository = clickerRepository;
        }

        public IFactoryRepository Get(FactoryCategory category) {
            switch (category) {
                case FactoryCategory.Factory:
                    return this.factoryRepository;
                case FactoryCategory.Clicker:
                    return this.clickerRepository;
            }
            throw new Exception("Invalid category.");
        }
    }
}
