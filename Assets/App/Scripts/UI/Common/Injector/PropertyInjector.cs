using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

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
        Type type = data.GetType();
        PropertyInfo prop = type.GetProperty(text.name);
        if (prop == null) {
            return;
        }
        object value = prop.GetValue(data);
        text.text = value.ToString();
    }

    private void InjectImage(object data, Image image) {
        if (image == null) {
            return;
        }
        Type type = data.GetType();
        PropertyInfo prop = type.GetProperty(image.name);
        if (prop == null) {
            return;
        }
        object value = prop.GetValue(data);
        Sprite sprite = Resources.Load<Sprite>(value.ToString());
        if (sprite == null) {
            return;
        }
        image.sprite = sprite;
    }
}
