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
        public bool IsCoolTime { get => this.CoolTime > TimeSpan.Zero; }
        public TimeSpan CoolTime { get => Common.Time.Max(this.saveDataRepository.SaveData.nextFeverAdsAt - this.timeRepository.Now, TimeSpan.Zero); }
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;
        private IFeverRepository feverRepository;

        public CoolDownRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository, IFeverRepository feverRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
            this.feverRepository = feverRepository;
        }

        public void CoolDown() {
            if (this.feverRepository.IsFever) {
                throw new Exception("Invalid fever.");
            }
            if (!this.feverRepository.IsCoolTime) {
                throw new Exception("Invalid cool time.");
            }
            if (this.IsCoolTime) {
                throw new Exception("Invalid ads cool time.");
            }
            var now = this.timeRepository.Now;
            this.saveDataRepository.SaveData.nextFeverAt = now;
            this.saveDataRepository.SaveData.nextFeverAdsAt = now + TimeSpan.FromMinutes(15);
            this.saveDataRepository.Save();
            // this.onAlter.OnNext(0);
        }
    }
}
