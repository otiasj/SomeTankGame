using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour {

    public GameObject eyeLevelText;
    public string currentLevel;
    public string nextLevel;

	public void showGameOver()
    {
        eyeLevelText.SetActive(true);
        eyeLevelText.GetComponent<GUIText>().text = "Your Castle Has Been Destroyed...";
        Invoke("loadCurrentLevel", 3);
    }

    public void showCongratulations()
    {
        eyeLevelText.SetActive(true);
        string winText = "Congratulations! you win!";
        if (nextLevel != null)
        {
            Invoke("loadNextLevel", 3);
            winText = winText + "\n Loading Next Level";
        }

        eyeLevelText.GetComponent<GUIText>().text = winText;
    }

    private void loadCurrentLevel()
    {
        eyeLevelText.SetActive(false);
        SteamVR_LoadLevel.Begin(currentLevel);
    }

    private void loadNextLevel()
    {
        eyeLevelText.SetActive(false);
        SteamVR_LoadLevel.Begin(nextLevel);
    }
}
