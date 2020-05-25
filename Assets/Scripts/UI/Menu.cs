using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public Button InfiniteModeButton;
    public Button PortalModeButton;
    public Button BossFightModeButton;
    public Button HighscoreButton;
    public Button ShopButton;
    public Button AboutButton;
    public Button ExitButton;

    private void Start() {
#if UNITY_ANDROID
        // Application.targetFrameRate = 60;
#endif

        InfiniteModeButton.onClick.AddListener(InfiniteMode);
        PortalModeButton.onClick.AddListener(PortalMode);
        BossFightModeButton.onClick.AddListener(BossFightMode);
        HighscoreButton.onClick.AddListener(Highscore);
        ShopButton.onClick.AddListener(Shop);
        AboutButton.onClick.AddListener(About);
        ExitButton.onClick.AddListener(Exit);

    }

    void InfiniteMode() {
        print("InfiniteModeButton Pressed.");
        GameSession.startInfiniteMode();

    }

    void PortalMode() {

    }

    void BossFightMode() {

    }

    void Highscore() {

    }

    void Shop() {
        Buttons.GotoShop();
    }

    void About() {

    }

    void Exit() {
        Application.Quit();
    }

}