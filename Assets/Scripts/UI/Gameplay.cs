using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Gameplay : MonoBehaviour {
    public TextMeshProUGUI kills;
    public TextMeshProUGUI coins;

    public Button skill1;
    public Button skill2;
    public Button skill3;
    
    
    private void OnEnable() {
        kills.text = GameSession.kills.ToString();
        coins.text = GameSession.coins.ToString();

        GameSession.enemyDeathEvent += OnEnemyDeath;
        GameSession.coinPickUpEvent += onCoinPickUp;
    }

    public void OnEnemyDeath() {
        // print("OnEnemyDeath event called");
        kills.text = GameSession.kills.ToString();
    }

    public void onCoinPickUp() {
        coins.text = GameSession.coins.ToString();
    }

    private void OnDisable() {
        GameSession.enemyDeathEvent -= OnEnemyDeath;
        GameSession.coinPickUpEvent -= onCoinPickUp;
    }
}