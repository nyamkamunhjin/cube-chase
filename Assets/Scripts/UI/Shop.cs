using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public TextMeshProUGUI skinName;
    public TextMeshProUGUI price;

    public Button buyButton;
    public Button leftButton;
    public Button rightButton;
    public Button backButton;

    private void Start() {
        buyButton.onClick.AddListener(Buy);
        leftButton.onClick.AddListener(Left);
        rightButton.onClick.AddListener(Right);
        backButton.onClick.AddListener(Back);
    }
    
    void Buy() {

    }

    void Left() {

    }

    void Right() {

    }

    void Back() {
        FindObjectOfType<ShopCamera>().reverse = true;
        Buttons.ClearUI();
    }
}