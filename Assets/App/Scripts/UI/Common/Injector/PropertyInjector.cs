using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PropertyInjector : MonoBehaviour
{
    public void Inject(object obj) {
        foreach (Text text in this.GetComponentsInChildren<Text>(true)) {
            this.InjectText(obj, text);
        }
        foreach (Image image in this.GetComponentsInChildren<Image>(true)) {
            this.InjectImage(obj, image);
        }
        this.InjectText(obj, this.GetComponent<Text>());
        this.InjectImage(obj, this.GetComponent<Image>());
    }

    private void InjectText(object obj, Text text) {
        if (text == null) {
            return;
        }
        Type type = obj.GetType();
        PropertyInfo prop = type.GetProperty(text.name);
        if (prop == null) {
            return;
        }
        object value = prop.GetValue(obj);
        text.text = value.ToString();
    }

    private void InjectImage(object obj, Image image) {
        if (image == null) {
            return;
        }
        Type type = obj.GetType();
        PropertyInfo prop = type.GetProperty(image.name);
        if (prop == null) {
            return;
        }
        object value = prop.GetValue(obj);
        Sprite sprite = Resources.Load<Sprite>(value.ToString());
        if (sprite == null) {
            return;
        }
        image.sprite = sprite;
    }
}
