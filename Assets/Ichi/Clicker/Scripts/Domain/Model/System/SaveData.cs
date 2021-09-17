using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System;
using UniRx;

namespace Ichi.Clicker
{
    [Serializable]
    public class SaveData : Common.IPreSave
    {
        public List<Clicker> clickers;
        public List<Factory> factories;
        public List<Item> items;
        public List<Episode> episodes;
        public List<Skill> skills;
        public Enemy enemy;
        public List<IGadget> Gadgets { get; private set; }
        public Skill Fever { get; private set; }
        public Skill CoolDown { get; private set; }
        public Item Coin { get; private set; }
        public Item Commodity { get; private set; }
        public Item Login { get; private set; }
        public Item EXP { get; private set; }
        public Item Gem { get; private set; }

        public void PreSave() {
            this.factories.ForEach(factory => factory.PreSave());
            this.items.ForEach(item => item.PreSave());
            this.skills.ForEach(skill => skill.PreSave());
            this.enemy.PreSave();
        }

        public void Initialize() {
            this.Gadgets = new List<IGadget>();
            this.InitializeEnemy();
            this.InitializeClickers();
            this.InitializeFactories();
            this.InitializeItems();
            this.InitializeEpisodes();
            this.InitializeSkills();
        }

        private void InitializeEnemy() {
            if (this.enemy == null) {
                this.enemy = new Enemy(1);
            } else {
                this.enemy.PostLoad();
            }
        }

        private void InitializeClickers() {
            if (this.clickers == null) {
                this.clickers = new List<Clicker>();
            } else {
                this.clickers.ForEach(clicker => clicker.PostLoad());
            }
            for (var rank = 1; rank <= 10; ++rank) {
                if (this.clickers.FirstOrDefault(clicker => clicker.rank == rank) == null) {
                    this.clickers.Add(new Clicker(rank));
                }
            }
            this.Gadgets.AddRange(this.clickers);
        }

        private void InitializeFactories() {
            if (this.factories == null) {
                this.factories = new List<Factory>();
            } else {
                this.factories.ForEach(factory => factory.PostLoad());
            }
            for (var rank = 1; rank <= 10; ++rank) {
                if (this.factories.FirstOrDefault(factory => factory.rank == rank) == null) {
                    this.factories.Add(new Factory(rank));
                }
            }
            this.Gadgets.AddRange(this.factories);
        }

        private void InitializeItems() {
            if (this.items == null) {
                this.items = new List<Item>();
            } else {
                this.items.ForEach(item => item.PostLoad());
            }
            foreach (ItemCategory category in Enum.GetValues(typeof(ItemCategory))) {
                if (this.items.FirstOrDefault(item => item.category == category) == null) {
                    this.items.Add(new Item(category));
                }
            }
            this.Coin = this.items.FirstOrDefault(item => item.category == ItemCategory.Coin);
            this.Commodity = this.items.FirstOrDefault(item => item.category == ItemCategory.Commodity);
            this.Login = this.items.FirstOrDefault(item => item.category == ItemCategory.Login);
            this.EXP = this.items.FirstOrDefault(item => item.category == ItemCategory.EXP);
            this.Gem = this.items.FirstOrDefault(item => item.category == ItemCategory.Gem);
        }

        private void InitializeEpisodes() {
            this.episodes = this.episodes ?? new List<Episode>();
            foreach (var factory in this.factories) {
                for (var level = 100; level <= 500; level += 100) {
                    var episode = this.episodes.FirstOrDefault(episode => episode.rank == factory.Rank && episode.level == level);
                    if (episode == null) {
                        episode = new Episode() {
                            rank = factory.Rank,
                            level = level,
                        };
                        this.episodes.Add(episode);
                    }
                    episode.Locker = new LevelLocker(factory, level);
                    episode.Novels = new List<Novel>() {
                        new Novel() {
                            Text = "aaaa",
                        },
                    };
                    //NOTE シナリオマスターデータ（そもそもローカライズあるからここで初期化できない）
                }
            }
        }

        private void InitializeSkills() {
            if (this.skills == null) {
                this.skills = new List<Skill>();
            } else {
                this.skills.ForEach(skill => skill.PostLoad());
            }
            foreach (SkillCategory category in Enum.GetValues(typeof(SkillCategory))) {
                if (this.skills.FirstOrDefault(skill => skill.category == category) == null) {
                    this.skills.Add(new Skill(category));
                }
            }
            this.Gadgets.AddRange(this.skills);
            this.Fever = this.skills.FirstOrDefault(skill => skill.category == SkillCategory.Fever);
            this.CoolDown = this.skills.FirstOrDefault(skill => skill.category == SkillCategory.CoolDown);
        }
    }
}
