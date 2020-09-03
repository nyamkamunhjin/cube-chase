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

    private void OnEnable() {
        buyButton.onClick.AddListener(Buy);
        leftButton.onClick.AddListener(Left);
        rightButton.onClick.AddListener(Right);
        backButton.onClick.AddListener(Back);

        loadSkin(index);
        PlayerData.addToCoins(100);
    }

    void loadSkin(int index) {
        Skin skin = cosmetics[index];
        updateUI(skin);
        swapSkin(skin);
    }

    void updateUI(Skin skin) {
        playerStash = PlayerData.loadUserSkins();
        skinName.text = skin.name;
        price.text = skin.price.ToString();
        coin.text = PlayerData.getCoins().ToString();

        
        if (checkBuyable()) {
            buyButton.GetComponent<Image>().color = Color.green;
        } else {
            buyButton.GetComponent<Image>().color = Color.red;
        }

        if (playerStash != null && playerStash.skins.Contains(skin.name)) {
            print("has this skin");
            buyButton.GetComponent<Image>().color = Color.cyan;
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "use";
        } else {
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "buy";
        }

        if(PlayerData.getCurrentSkin() == skin.name) {
            buyButton.GetComponent<Image>().color = Color.grey;
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "using";
        }
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
        // GameSession.player.GetComponent<ParticleSystemRenderer>().material = skin.skin.GetComponent<MeshRenderer>().sharedMaterial;
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
            }
        }
        updateUI(cosmetics[index]);

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