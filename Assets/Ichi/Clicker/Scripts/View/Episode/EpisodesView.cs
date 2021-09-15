using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ichi.Clicker.View
{
    public class EpisodesView : MonoBehaviour
    {
        [Inject]
        private IEpisodeRepository episodeRepository;
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private Transform parent;

        void Start() {
            Common.Hierarchy.DestroyChildren(this.parent);
            Common.Hierarchy.InstantiateChildren<EpisodeView, IEpisode>(
                this.parent,
                this.prefab,
                this.episodeRepository.Episodes
            );
        }
    }
}
