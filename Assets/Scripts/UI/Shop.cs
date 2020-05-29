using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public Skin[] cosmetics;
    public SkinStash playerStash;

    public int index;
    public TextMeshProUGUI skinName;
    public TextMeshProUGUI price;
    public TextMeshProUGUI coin;

    public Button buyButton;
    public Button leftButton;
    public Button rightButton;
    public Button backButton;

    private void Start() {
        buyButton.onClick.AddListener(Buy);
        leftButton.onClick.AddListener(Left);
        rightButton.onClick.AddListener(Right);
        backButton.onClick.AddListener(Back);

        playerStash = PlayerData.loadUserSkins();
        loadSkin(0);

    }

    void loadSkin(int index) {
        Skin skin = cosmetics[index];
        playerStash = PlayerData.loadUserSkins();

        skinName.text = skin.name;
        price.text = skin.price.ToString();
        coin.text = PlayerData.getCoins().ToString();

        if (!checkBuyable()) {
            buyButton.GetComponent<Image>().color = Color.red;
        } else {
            buyButton.GetComponent<Image>().color = Color.green;
        }

        if (playerStash != null && playerStash.skins.Contains(skin.name)) {
            print("has this skin");
            buyButton.GetComponent<Image>().color = Color.cyan;
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "use";
        } else {
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "buy";
        }

        swapSkin(skin);
    }

    public static void loadCurrentSkin() {
        Skin skin = Resources.Load<Skin>("Cosmetics/" + PlayerData.getCurrentSkin());
        print("Prefabs/Cosmetics/" + PlayerData.getCurrentSkin());
        // print(skin.name);
        if (skin == null) {
            skin = Resources.Load<Skin>("Cosmetics/Pinky");
        }

        swapSkin(skin);
    }

    public static void swapSkin(Skin skin) {
        GameSession.player.GetComponent<MeshFilter>().mesh = skin.skin.GetComponent<MeshFilter>().sharedMesh;
        GameSession.player.GetComponent<MeshRenderer>().material = skin.skin.GetComponent<MeshRenderer>().sharedMaterial;
        GameSession.player.GetComponent<ParticleSystemRenderer>().material = skin.skin.GetComponent<MeshRenderer>().sharedMaterial;
    }

    bool checkBuyable() {
        return PlayerData.getCoins() >= cosmetics[index].price;
    }

    void Buy() {
        // red if player can't afford it
        // green if player can afford it
        // if it's bought skin change text to use
        // if bought save it somehow
        if (buyButton.GetComponentInChildren<TextMeshProUGUI>().text == "use") {
            PlayerData.setCurrentSkin(cosmetics[index]);
        } else {
            if (checkBuyable()) {
                PlayerData.saveUserSkins(cosmetics[index]);
                PlayerData.addToCoins(-cosmetics[index].price);
                loadSkin(index);
            }

        }

    }

    void Left() {
        index--;
        if (index < 0) {
            index = cosmetics.Length - 1;
        }

        loadSkin(index);
    }

    void Right() {
        index++;
        if (index >= cosmetics.Length) {
            index = 0;
        }

        loadSkin(index);
    }

    void Back() {
        index = 0;
        loadCurrentSkin();

        FindObjectOfType<ShopCamera>().reverse = true;
        Buttons.ClearUI();
    }
}