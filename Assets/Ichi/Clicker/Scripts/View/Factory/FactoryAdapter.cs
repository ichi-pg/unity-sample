using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ichi.Clicker.View
{
    public class FactoryAdapter
    {
        [Inject]
        private Common.ITextLocalizer textLocalizer;
        [Inject]
        private IFactoryRepositories factoryRepositories;
        private IFactory factory;

        public string Name { get => this.textLocalizer.Localize(this.factory.GetType().Name + this.factory.Rank); }
        public int Rank { get => this.factory.Rank; }
        public int Level { get => this.factory.Level; }
        public string Cost { get => Common.BigIntegerText.ToString(this.factory.Cost); }
        public string Power { get => Common.BigIntegerText.ToString(this.factory.Power); }
        public string NextPower { get => Common.BigIntegerText.ToString(this.factory.Power.NextValue); }
        public bool CanLevelUp { get => this.factoryRepositories.Get(this.factory.Category).CanLevelUp(this.factory); }
        public string Unit { get => this.textLocalizer.Localize(this.factory.Unit); }

        public FactoryAdapter(IFactory factory) {
            this.factory = factory;
        }
    }
}
