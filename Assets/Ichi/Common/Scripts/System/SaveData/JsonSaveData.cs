using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ichi.Common
{
    public static class JsonSaveData
    {
        public static void Save<T>(T obj, bool pretty = true) where T : IPreSave {
            //TODO 難読化
            //TODO バイナリ
            var path = FilePath(obj.GetType());
            SaveTask(obj, pretty, path).Forget();
        }

        private static async UniTask SaveTask<T>(T obj, bool pretty, string path) where T : IPreSave {
            await UniTask.SwitchToThreadPool();
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }
            obj.PreSave();
            var writer = new StreamWriter(path);
            var json = JsonUtility.ToJson(obj, pretty);
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }

        public static bool Exist<T>() {
            var path = FilePath(typeof(T));
            return File.Exists(path);
        }

        public static T Load<T>() where T : IPostLoad {
            var path = FilePath(typeof(T));
            if (!File.Exists(path)) {
                throw new Exception("Not found save data.");
            }
            var reader = new StreamReader(path);
            var json = reader.ReadToEnd();
            reader.Close();
            var obj = JsonUtility.FromJson<T>(json);
            obj.PostLoad();
            return obj;
        }

        private static string FilePath(Type type) {
            return Application.persistentDataPath + "/" + type.Namespace + "/" + type.Name + ".json";
        }
    }
}
