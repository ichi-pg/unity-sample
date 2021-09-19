using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Ichi.Clicker.View
{
    public class DropObserver : MonoBehaviour
    {
        [SerializeField]
        private Common.ModalOpener modalOpener;
        [SerializeField]
        private GadgetViewData viewData;

        void Start() {
            DIContainer.EnemyRepository.OnDrop.Subscribe(this.OnDrop).AddTo(this);
        }

        private void OnDrop(IGadget gadget) {
            this.modalOpener.OpenWith<DropModal>().Initialize(gadget, this.viewData);
        }
    }
}
