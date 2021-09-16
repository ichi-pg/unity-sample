using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

namespace Ichi.Common
{
    public static class JsonSaveData
    {
        public static void Save<T>(T obj, bool pretty = true) where T : IPreSave {
            obj.PreSave();
            var json = JsonUtility.ToJson(obj, pretty);
            var path = FilePath(obj.GetType());
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }
            var writer = new StreamWriter(path);
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

        public static void Delete<T>() {
            var path = FilePath(typeof(T));
            if (!File.Exists(path)) {
                throw new Exception("Not found save data.");
            }
            File.Delete(path);
        }

        private static string FilePath(Type type) {
            return Application.persistentDataPath + "/" + type.Namespace + "/" + type.Name + ".json";
        }
    }
}
