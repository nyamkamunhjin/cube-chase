using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Skin", menuName = "CubeRush/Skin", order = 0)]
[Serializable]
public class Skin : ScriptableObject {
    public new string name;
    public int price;
    public GameObject skin;

    public void set(string name, int price, GameObject skin) {
        this.name = name;
        this.price = price;
        this.skin = skin;
    }
}
