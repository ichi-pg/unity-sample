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
        private readonly static TimeSpan Duration = TimeSpan.FromSeconds(300);

        public bool IsFever { get => this.timeRepository.Now < this.finishAt; }
        public bool IsCoolTime { get => this.CoolTime > TimeSpan.Zero; }
        public bool IsAdsCoolTime { get => this.AdsCoolTime > TimeSpan.Zero; }
        public TimeSpan CoolTime { get => Common.Time.Max(this.saveDataRepository.SaveData.nextFeverAt - this.timeRepository.Now, TimeSpan.Zero); }
        public TimeSpan AdsCoolTime { get => Common.Time.Max(this.saveDataRepository.SaveData.nextFeverAdsAt - this.timeRepository.Now, TimeSpan.Zero); }
        private Subject<int> onAlter = new Subject<int>();
        public IObservable<int> OnAlter { get; }
        private DateTime finishAt = DateTime.MinValue;
        private int cheatBonus = 1;
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;
        private IProduceRepository factoryRepository;

        public int Rate {
            get {
                //全ての施設の性能は等価 -> オートの総生産 = クリックの施設数倍
                //1日4回ログインで2回ずつフィーバー -> 300s / 0.1s * 8回/日 * n = 86400回/日
                return this.saveDataRepository.SaveData.factories.Count(factory => factory.IsBought) * 3;
            }
        }

        public float DurationRate {
            get {
                var timeLeft = Common.Time.Max(this.finishAt - this.timeRepository.Now, TimeSpan.Zero);
                return (float)timeLeft.Ticks / Duration.Ticks;
            }
        }

        public FeverRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository, IProduceRepository factoryRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
            this.factoryRepository = factoryRepository;
        }

        public void Fever(CancellationToken token) {
            if (this.IsFever) {
                throw new Exception("Invalid fever.");
            }
            if (this.IsCoolTime) {
                throw new Exception("Invalid cool time.");
            }
            var now = this.timeRepository.Now;
            this.finishAt = now + Duration;
            this.saveDataRepository.SaveData.nextFeverAt = now + TimeSpan.FromMinutes(30);
            this.onAlter.OnNext(0);
            this.Produce(token).Forget();
        }

        private async UniTask Produce(CancellationToken token) {
            while (this.IsFever)
            {
                this.factoryRepository.Produce();
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
            this.saveDataRepository.Save();
            this.onAlter.OnNext(0);
        }

        public void CoolDown() {
            if (this.IsFever) {
                throw new Exception("Invalid fever.");
            }
            if (!this.IsCoolTime) {
                throw new Exception("Invalid cool time.");
            }
            if (this.IsAdsCoolTime) {
                throw new Exception("Invalid ads cool time.");
            }
            var now = this.timeRepository.Now;
            this.saveDataRepository.SaveData.nextFeverAt = now;
            this.saveDataRepository.SaveData.nextFeverAdsAt = now + TimeSpan.FromMinutes(15);
            this.saveDataRepository.Save();
            this.onAlter.OnNext(0);
        }

        public void CheatMode(bool enable) {
            this.cheatBonus = enable ? 100 : 1;
        }

        //NOTE 単純にFeverモデルに
        //NOTE レートはSkillモデルに
    }
}
