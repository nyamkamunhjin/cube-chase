using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour {
    private static FileInfo file = new FileInfo(Application.persistentDataPath + "/PlayerData/data.json");

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

    public static void setCurrentSkin(Skin skin) {
        SkinStash skinStash = loadUserSkins();
        skinStash.currentSkin = skin.name;

        string dataAsJson = JsonUtility.ToJson(skinStash, true);
        print(dataAsJson);
        file.Directory.Create();
        File.WriteAllText(file.FullName, dataAsJson);
    }

    public static string getCurrentSkin() {
        return loadUserSkins().currentSkin;
    }

    public static SkinStash loadUserSkins() {
        if (File.Exists(file.FullName)) {
            string dataAsJson = File.ReadAllText(file.FullName);
            // Debug.Log(dataAsJson);
            print(file.FullName);
            SkinStash gameData = JsonUtility.FromJson<SkinStash>(dataAsJson);
            return gameData;
        } else {
            return new SkinStash {
                currentSkin = "Pinky",
                    skins = new List<string>()
            };
        }
    }

    public static void saveUserSkins(Skin data) {
        SkinStash skinStash = loadUserSkins();

        if (!skinStash.skins.Contains(data.name)) {
            skinStash.skins.Add(data.name);
        }

        string dataAsJson = JsonUtility.ToJson(skinStash, true);
        print(dataAsJson);
        file.Directory.Create();
        File.WriteAllText(file.FullName, dataAsJson);
    }

}

[Serializable]
public class SkinStash {
    public string currentSkin;
    public List<string> skins;
}