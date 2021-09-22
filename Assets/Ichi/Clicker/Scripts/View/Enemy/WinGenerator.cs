using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Ichi.Clicker.View
{
    public class WinGenerator : MonoBehaviour
    {
        [SerializeField]
        private Common.PointGenerator generater;

        void Start() {
            DIContainer.EnemyRepository.OnWin.Subscribe(this.OnWin).AddTo(this);
        }

        private void OnWin(IEnemy enemy) {
            this.generater.Generate<Common.PoolableReturner>();
        }
    }
}
