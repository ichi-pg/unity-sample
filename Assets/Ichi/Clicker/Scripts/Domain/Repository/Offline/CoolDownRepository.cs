using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Ichi.Clicker.Offline
{
    public class CoolDownRepository : ICoolDownRepository
    {
        public TimeSpan CoolTime { get => Common.Time.Max(this.saveDataRepository.SaveData.nextFeverAdsAt - this.timeRepository.Now, TimeSpan.Zero); }
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;
        private IFeverRepository feverRepository;
        private Subject<int> onAlter = new Subject<int>();
        public IObservable<int> OnAlter { get; }

        public CoolDownRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository, IFeverRepository feverRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
            this.feverRepository = feverRepository;
            this.CoolTimeTask().Forget();
        }

        private async UniTask CoolTimeTask() {
            await UniTask.Delay(this.CoolTime);
            this.onAlter.OnNext(0);
        }

        public void CoolDown() {
            if (this.feverRepository.TimeLeft > TimeSpan.Zero) {
                throw new Exception("Invalid time left.");
            }
            if (this.feverRepository.CoolTime <= TimeSpan.Zero) {
                throw new Exception("Invalid cool time.");
            }
            if (this.CoolTime > TimeSpan.Zero) {
                throw new Exception("Invalid cool time.");
            }
            var now = this.timeRepository.Now;
            this.saveDataRepository.SaveData.nextFeverAt = now;
            this.saveDataRepository.SaveData.nextFeverAdsAt = now + TimeSpan.FromMinutes(15);
            this.saveDataRepository.Save();
            this.onAlter.OnNext(0);
        }
    }
}
