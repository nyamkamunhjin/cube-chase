using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour {
    public GameObject MenuUI;
    public GameObject GameplayUI;
    public GameObject GameOverUI;
    public GameObject shopUI;

    public static Buttons UIs;

    private void Start() {
        UIs = this;    
    }

    public void SetMenuUIState(bool value) {
        MenuUI.SetActive(value);
    }

    public void SetGameplayUIState(bool value) {
        GameplayUI.SetActive(value);
    }

    public void SetGameOverUIState(bool value) {
        GameOverUI.SetActive(value);
    }

    public void SetShopUIState(bool value) {
        shopUI.SetActive(value);
    }

    public static void GotoGameOver() {
        FindObjectOfType<InfiniteMode>().enabled = false;
        
        UIs.SetMenuUIState(false);
        UIs.SetGameplayUIState(false);
        UIs.SetGameOverUIState(true);
        UIs.SetShopUIState(false);
    }

    public static void GotoMenu() {
        GameSession.player.GetComponent<MeshRenderer>().enabled = true;
        UIs.SetMenuUIState(true);
        UIs.SetGameplayUIState(false);
        UIs.SetGameOverUIState(false);
        UIs.SetShopUIState(false);

    }

    public static void GotoShop() {
        FindObjectOfType<CameraControl>().enabled = false;
        FindObjectOfType<ShopCamera>().enabled = true;
        
        UIs.SetMenuUIState(false);
        UIs.SetGameplayUIState(false);
        UIs.SetGameOverUIState(false);
        UIs.SetShopUIState(true);
    }

    public static void ClearUI() {
        UIs.SetMenuUIState(false);
        UIs.SetGameplayUIState(false);
        UIs.SetGameOverUIState(false);
        UIs.SetShopUIState(false);
    }
}