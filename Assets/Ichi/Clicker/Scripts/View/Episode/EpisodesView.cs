using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class EpisodesView : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;

        void Start() {
            Common.Hierarchy.DestroyChildren(this.transform);
            Common.Hierarchy.InstantiateChildren<EpisodeView, IEpisode>(
                this.transform,
                this.prefab,
                DIContainer.EpisodeRepository.Episodes
            );
        }
    }
}
