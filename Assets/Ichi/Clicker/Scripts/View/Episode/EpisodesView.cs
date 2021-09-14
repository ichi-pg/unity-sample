using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class EpisodesView : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Transform parent;

        void Start() {
            Common.Hierarchy.DestroyChildren(this.parent);
            Common.Hierarchy.InstantiateChildren<EpisodeView, IEpisode>(
                this.parent,
                this.prefab,
                DIContainer.EpisodeRepository.Episodes
            );
        }
    }
}
