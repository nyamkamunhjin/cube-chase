using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public TextMeshProUGUI score;
    public TextMeshProUGUI coins;

    public Button MenuButton;
    public Button ReplayButton;
    public Button AdButton;

    private void OnEnable() {
        MenuButton.onClick.AddListener(Menu);
        ReplayButton.onClick.AddListener(Replay);
        AdButton.onClick.AddListener(Ad);

        GameSession.playerDeathEvent += onPlayerDeath;

        score.text = GameSession.kills.ToString();
        coins.text = GameSession.coins.ToString();
        
    }

    void onPlayerDeath() {
        print("onPlayerDeath called!");
        PlayerData.addToCoins(GameSession.coins);
        coins.text = "Total coins: " + PlayerData.getCoins();
        score.text = "score: " + GameSession.kills;

        if(GameSession.kills > PlayerData.getHighScore()) {
            PlayerData.setHighScore(GameSession.kills);
        }

    }

    void Menu() {
        GameSession.SessionReset();
        Buttons.GotoMenu();
    }

    void Replay() {
        GameSession.SessionReset();
        GameSession.startInfiniteMode();
    }

    void Ad() {

    }

    private void OnDisable() {
        GameSession.playerDeathEvent -= onPlayerDeath;
    }
}