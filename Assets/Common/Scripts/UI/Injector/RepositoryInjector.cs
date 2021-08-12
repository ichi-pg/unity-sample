using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Common
{
    public class RepositoryInjector : MonoBehaviour
    {
        [SerializeField]
        private string injectorName;
        [SerializeField]
        private string repositoryName;
        [SerializeField]
        private string methodName;

        void Start() {
            object obj = this.InvokeRepository();
            if (obj is IEnumerable) {
                this.InjectEnumerable(obj as IEnumerable);
            } else {
                this.InjectProperty(obj);
            }
        }

        private object InvokeRepository() {
            var injectorType = System.Type.GetType(this.injectorName);
            if (injectorType == null) {
                return null;
            }
            var injectorProp = injectorType.GetProperty("Instance");
            if (injectorProp == null) {
                return null;
            }
            object injector = injectorProp.GetValue(null);
            if (injector == null) {
                return null;
            }
            var repoProp = injectorType.GetProperty(this.repositoryName);
            if (repoProp == null) {
                return null;
            }
            object repo = repoProp.GetValue(injector);
            if (repo == null) {
                return null;
            }
            var method = repo.GetType().GetMethod(this.methodName);
            if (method == null) {
                return null;
            }
            return method.Invoke(repo, null);
        }

        private void InjectEnumerable(IEnumerable enumerable) {
            EnumerableInjector injector = this.GetComponent<EnumerableInjector>();
            if (injector == null) {
                return;
            }
            injector.Inject(enumerable);
        }

        private void InjectProperty(object obj) {
            PropertyInjector injector = this.GetComponent<PropertyInjector>();
            if (injector == null) {
                return;
            }
            injector.Inject(obj);
        }
    }
}
