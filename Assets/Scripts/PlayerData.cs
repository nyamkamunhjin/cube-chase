using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public static void addToCoins(int coins) {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + coins);
    }

    public static int getCoins() {
        return PlayerPrefs.GetInt("coins", 0);
    }


    public static int getHighScore() {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    public static void setHighScore(int highScore) {
        PlayerPrefs.SetInt("highscore", highScore);
    }
}