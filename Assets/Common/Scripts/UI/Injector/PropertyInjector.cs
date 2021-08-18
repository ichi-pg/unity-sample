using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Common
{
    public class PropertyInjector : MonoBehaviour
    {
        public static event System.Action ModifyHander;
        public object Data { get; private set; }
        private Dictionary<string, UnityAction> actions = new Dictionary<string, UnityAction>();

        void Start() {
            ModifyHander += this.OnModify;
        }

        void OnDestroy() {
            ModifyHander -= this.OnModify;
        }

        private void OnModify() {
            this.Inject(this.Data);//TODO 変化したパラメーターだけ更新したい
        }

        public static void Modify() {
            ModifyHander?.Invoke();//TODO 変化したオブジェクトだけ更新したい
        }

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
            foreach (Button button in this.GetComponentsInChildren<Button>(true)) {
                this.InjectButton(data, button);
            }
            this.InjectText(data, this.GetComponent<Text>());
            this.InjectImage(data, this.GetComponent<Image>());
            this.InjectButton(data, this.GetComponent<Button>());
            this.Data = data;
        }

        private void InjectText(object data, Text text) {
            if (text == null) {
                return;
            }
            var value = this.GetValue(data, text.name);
            if (value == null) {
                return;
            }
            text.text = value.ToString();
        }

        private void InjectImage(object data, Image image) {
            if (image == null) {
                return;
            }
            var imageName = this.GetValue(data, image.name);
            if (imageName != null) {
                var sprite = Resources.Load<Sprite>(imageName.ToString());
                if (sprite != null) {
                    image.sprite = sprite;
                }
            }
            var disable = this.GetValue(data, image.name+"Disable");
            if (disable != null && disable is bool) {
                image.color = (bool)disable ? Color.gray : Color.white;
            }
        }

        private void InjectButton(object data, Button button) {
            if (button == null) {
                return;
            }
            var disable = this.GetValue(data, button.name+"Disable");
            if (disable != null && disable is bool) {
                button.interactable = !(bool)disable;
            }
            var hidden = this.GetValue(data, button.name+"Hidden");
            if (hidden != null && hidden is bool) {
                button.gameObject.SetActive(!(bool)hidden);
            }
            var action = this.GetAction(data, button.name);
            if (action != null) {
                button.onClick.RemoveListener(action);
                button.onClick.AddListener(action);
            }
        }

        private object GetValue(object data, string name) {
            var names = name.Split('.');
            var type = this.GetType(data, names);
            if (type == null) {
                return null;
            }
            var prop = type.GetProperty(names[1]);
            if (prop == null) {
                return null;
            }
            return prop.GetValue(data);
        }

        private UnityAction GetAction(object data, string name) {
            if (this.actions.ContainsKey(name)) {
                return this.actions[name];
            }
            var names = name.Split('.');
            var type = this.GetType(data, names);
            if (type == null) {
                return null;
            }
            var method = type.GetMethod(names[1]);
            if (method == null) {
                return null;
            }
            this.actions.Add(name, () => method.Invoke(data, null));
            return this.actions[name];
        }

        private System.Type GetType(object data, string[] names) {
            if (names.Length != 2) {
                return null;
            }
            var type = data.GetType();
            if (!type.Name.Contains(names[0])) {
                return null;
            }
            return type;
        }
    }
}
