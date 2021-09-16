using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private Subject<int> onAlter = new Subject<int>();
        public IObservable<int> OnAlter { get; }
        private DateTime finishAt = DateTime.MinValue;
        private int cheatBonus = 1;
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;
        private IProduceRepository factoryRepository;

        public FeverRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository, IProduceRepository factoryRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
            this.factoryRepository = factoryRepository;
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
            this.Produce().Forget();
        }

        private async UniTask Produce() {
            while (this.TimeLeft > TimeSpan.Zero)
            {
                this.factoryRepository.Produce();
                this.onAlter.OnNext(0);
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
