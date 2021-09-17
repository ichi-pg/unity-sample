using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ichi.Common.Extensions;

namespace Ichi.Clicker.View
{
    public class EpisodeListView : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Transform parent;

        void Start() {
            this.parent.DestroyChildren();
            this.parent.InstantiateChildren<EpisodeView, IEpisode>(
                this.prefab,
                DIContainer.EpisodeRepository.Episodes,
                (view, episode) => view.Initialize(episode)
            );
        }
    }
}