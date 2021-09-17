using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Ichi.Clicker.Offline
{
    public class FeverRepository : IFeverRepository
    {
        public TimeSpan Duration { get => TimeSpan.FromSeconds(300); }
        public TimeSpan TimeLeft { get => Common.Time.Max(this.finishAt - this.timeRepository.Now, TimeSpan.Zero); }
        public TimeSpan CoolTime { get => Common.Time.Max(this.saveDataRepository.SaveData.nextFeverAt - this.timeRepository.Now, TimeSpan.Zero); }
        private int Rate { get => this.saveDataRepository.SaveData.factories.Count(factory => factory.IsBought) * 3; }
        private Subject<int> onAlter = new Subject<int>();
        public IObservable<int> OnAlter { get => this.onAlter; }
        private Subject<BigInteger> onProduce = new Subject<BigInteger>();
        public IObservable<BigInteger> OnProduce { get => this.onProduce; }
        private DateTime finishAt = DateTime.MinValue;
        private int cheatBonus = 1;
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;

        public FeverRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
            this.CoolTimeTask().Forget();
        }

        private async UniTask CoolTimeTask() {
            await UniTask.Delay(this.CoolTime);
            this.onAlter.OnNext(0);
        }

        public void Fever() {
            if (this.TimeLeft > TimeSpan.Zero) {
                throw new Exception("Invalid time left.");
            }
            if (this.CoolTime > TimeSpan.Zero) {
                throw new Exception("Invalid cool time.");
            }
            var now = this.timeRepository.Now;
            this.finishAt = now + this.Duration;
            this.saveDataRepository.SaveData.nextFeverAt = now + TimeSpan.FromMinutes(30);
            this.onAlter.OnNext(0);
            this.Produce().Forget();
        }

        private async UniTask Produce() {
            while (this.TimeLeft > TimeSpan.Zero)
            {
                var enemy = this.saveDataRepository.SaveData.enemy;
                if (enemy.IsAlive) {
                    var power = this.saveDataRepository.SaveData.clickers.Produce(enemy, this.cheatBonus * this.Rate);
                    this.onProduce.OnNext(power);
                }
                await UniTask.Delay(TimeSpan.FromMilliseconds(100));
            }
            this.saveDataRepository.Save();
            this.onAlter.OnNext(0);
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }

        //TODO 単純にFeverモデルに
        //TODO レートはSkillモデルに
    }
}
