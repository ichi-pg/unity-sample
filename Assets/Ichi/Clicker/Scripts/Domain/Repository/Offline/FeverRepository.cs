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
        private Subject<int> onAlter = new Subject<int>();
        public IObservable<int> OnAlter { get => this.onAlter; }
        private Subject<BigInteger> onProduce = new Subject<BigInteger>();
        public IObservable<BigInteger> OnProduce { get => this.onProduce; }
        private int cheatBonus = 1;
        private ITimeRepository timeRepository;
        private ISaveDataRepository saveDataRepository;

        public FeverRepository(ITimeRepository timeRepository, ISaveDataRepository saveDataRepository) {
            this.timeRepository = timeRepository;
            this.saveDataRepository = saveDataRepository;
            this.CoolTimeTask().Forget();
        }

        private async UniTask CoolTimeTask() {
            var now = this.timeRepository.Now;
            var fever = this.saveDataRepository.SaveData.Fever;
            await UniTask.Delay(fever.CoolTime(now));
            this.onAlter.OnNext(0);
        }

        public void Fever() {
            var now = this.timeRepository.Now;
            var fever = this.saveDataRepository.SaveData.Fever;
            if (fever.TimeLeft(now) > TimeSpan.Zero) {
                throw new Exception("Invalid time left.");
            }
            if (fever.CoolTime(now) > TimeSpan.Zero) {
                throw new Exception("Invalid cool time.");
            }
            fever.FinishAt = now + fever.MaxTimeLeft;
            fever.coolDownAt = now + fever.MaxCoolTime;
            this.saveDataRepository.Save();
            this.onAlter.OnNext(0);
            this.Produce().Forget();
        }

        private async UniTask Produce() {
            var fever = this.saveDataRepository.SaveData.Fever;
            while (fever.TimeLeft(this.timeRepository.Now) > TimeSpan.Zero) {
                var enemy = this.saveDataRepository.SaveData.Enemy;
                if (enemy != null && enemy.IsAlive) {
                    var power = this.saveDataRepository.SaveData.clickers.Produce(enemy, this.cheatBonus * fever.Power);
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
    }
}
