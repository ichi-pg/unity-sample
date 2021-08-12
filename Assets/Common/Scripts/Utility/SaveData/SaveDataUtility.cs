using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Common
{
    public static class SaveDataUtility
    {
        public static void Save<T>(T obj) {
            var path = FilePath(obj.GetType());
            StreamWriter writer = new StreamWriter(path);
            var json = JsonUtility.ToJson(obj);
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }

        public static bool Exist<T>() {
            var path = FilePath(typeof(T));
            return File.Exists(path);
        }

        public static T Load<T>() {
            var path = FilePath(typeof(T));
            if (!File.Exists(path)) {
                throw new System.Exception("Not found save data. ");
            }
            StringReader reader = new StringReader(path);
            var json = reader.ReadToEnd();
            reader.Close();
            return JsonUtility.FromJson<T>(json);
        }

        private static string FilePath(System.Type type) {
            return Application.persistentDataPath + "/" + type.Namespace + "/" + type.Name;
        }

        //TODO 難読化
    }
}
