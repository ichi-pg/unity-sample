using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class RepositoryInjector : MonoBehaviour
    {
        [SerializeField]
        private string _namespace;
        [SerializeField]
        private string repositoryName;
        [SerializeField]
        private string methodName;
        [SerializeField]
        private string prefabName;

        void Start() {
            object obj = this.InvokeRepository();
            if (obj is IEnumerable) {
                this.InjectEnumerable(obj as IEnumerable);
            } else {
                this.InjectProperty(obj);
            }
        }

        private object InvokeRepository() {
            var reposType = System.Type.GetType(this._namespace+".Repositories");
            if (reposType == null) {
                Debug.Log("reposType == null");
                return null;
            }
            var reposProp = reposType.GetProperty("Instance");
            if (reposProp == null) {
                Debug.Log("reposProp == null");
                return null;
            }
            var repos = reposProp.GetValue(null);
            if (repos == null) {
                Debug.Log("repos == null");
                return null;
            }
            var repoProp = reposType.GetProperty(this.repositoryName+"Repository");
            if (repoProp == null) {
                Debug.Log("repoProp == null");
                return null;
            }
            var repo = repoProp.GetValue(repos);
            if (repo == null) {
                Debug.Log("repo == null");
                return null;
            }
            var method = repo.GetType().GetMethod(this.methodName);
            if (method == null) {
                Debug.Log("method == null");
                return null;
            }
            return method.Invoke(repo, null);
        }

        private void InjectEnumerable(IEnumerable enumerable) {
            EnumerableInjector injector = this.GetComponent<EnumerableInjector>();
            if (injector == null) {
                Debug.Log("injector == null");
                return;
            }
            injector.Clear();
            injector.Inject(enumerable, this.prefabName);
        }

        private void InjectProperty(object obj) {
            var injector = this.GetComponent<PropertyInjector>();
            if (injector == null) {
                Debug.Log("injector == null");
                return;
            }
            injector.Inject(obj);
        }
    }
}
