using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class PropertyInjector : MonoBehaviour
    {
        public object Data { get; private set; }

        public void Inject(object data) {
            if (data == null) {
                return;
            }
            foreach (Text text in this.GetComponentsInChildren<Text>(true)) {
                this.InjectText(data, text);
            }
            foreach (Image image in this.GetComponentsInChildren<Image>(true)) {
                this.InjectImage(data, image);
            }
            this.InjectText(data, this.GetComponent<Text>());
            this.InjectImage(data, this.GetComponent<Image>());
            this.Data = data;
        }

        private void InjectText(object data, Text text) {
            if (text == null) {
                return;
            }
            object value = this.GetValue(data, text.name);
            if (value == null) {
                return;
            }
            text.text = value.ToString();
        }

        private void InjectImage(object data, Image image) {
            if (image == null) {
                return;
            }
            object value = this.GetValue(data, image.name);
            if (value == null) {
                return;
            }
            Sprite sprite = Resources.Load<Sprite>(value.ToString());
            if (sprite == null) {
                return;
            }
            image.sprite = sprite;
        }

        private object GetValue(object data, string name) {
            string[] names = name.Split('.');
            if (names.Length != 2) {
                return null;
            }
            var type = data.GetType();
            if (names[0] != type.Name) {
                return null;
            }
            var prop = type.GetProperty(names[1]);
            if (prop == null) {
                return null;
            }
            return prop.GetValue(data);
        }

        //TODO リアルタイム変更
    }
}
