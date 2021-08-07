using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;

public class RepositoryInjector : MonoBehaviour
{
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
        Repositories repos = Repositories.Instance;
        Type reposType = repos.GetType();
        PropertyInfo repoProp = reposType.GetProperty(this.repositoryName);
        if (repoProp == null) {
            return null;
        }
        object repo = repoProp.GetValue(repos);
        if (repo == null) {
            return null;
        }
        Type repoType = repo.GetType();
        MethodInfo method = repoType.GetMethod(this.methodName);
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
