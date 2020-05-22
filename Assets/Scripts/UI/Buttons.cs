using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour {
    public GameObject MenuUI;
    public GameObject GameplayUI;
    public GameObject GameOverUI;

    public void SetMenuUIState(bool value) {
        MenuUI.SetActive(value);
    }

    public void SetGameplayUIState(bool value) {
        GameplayUI.SetActive(value);
    }

    public void SetGameOverUIState(bool value) {
        GameOverUI.SetActive(value);
    }
}