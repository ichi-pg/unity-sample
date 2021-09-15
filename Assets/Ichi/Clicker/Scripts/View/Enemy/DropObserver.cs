using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
using Zenject;

namespace Ichi.Clicker.View
{
    public class DropObserver : MonoBehaviour
    {
        [Inject]
        private IEnemyRepository enemyRepository;
        [SerializeField]
        private Common.ModalOpener modalOpener;

        void Start() {
            this.enemyRepository.OnDrop.Subscribe(this.OnDrop).AddTo(this);
        }

        private void OnDrop(IFactory factory) {
            this.modalOpener.Open();
            //TODO 引数として渡す
        }
    }
}
