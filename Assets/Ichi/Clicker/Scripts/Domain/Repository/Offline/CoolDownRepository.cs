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
        public TimeSpan CoolTime { get => this.saveDataRepository.SaveData.CoolDown.CoolTime(this.timeRepository.Now); }
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;
        private Subject<int> onAlter = new Subject<int>();
        public IObservable<int> OnAlter { get => this.onAlter; }

        public CoolDownRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
            this.CoolTimeTask().Forget();
        }

        private async UniTask CoolTimeTask() {
            await UniTask.Delay(this.CoolTime);
            this.onAlter.OnNext(0);
        }

        public void CoolDown() {
            var fever = this.saveDataRepository.SaveData.Fever;
            var coolDown = this.saveDataRepository.SaveData.CoolDown;
            var now = this.timeRepository.Now;
            if (fever.TimeLeft(now) > TimeSpan.Zero) {
                throw new Exception("Invalid time left.");
            }
            if (fever.CoolTime(now) <= TimeSpan.Zero) {
                throw new Exception("Invalid cool time.");
            }
            if (coolDown.CoolTime(now) > TimeSpan.Zero) {
                throw new Exception("Invalid cool time.");
            }
            fever.coolDownAt = now;
            coolDown.coolDownAt = now + TimeSpan.FromMinutes(15);
            this.saveDataRepository.Save();
            this.onAlter.OnNext(0);
        }
    }
}
