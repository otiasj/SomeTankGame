using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour {

    public GameObject eyeLevelText;
    public GameObject text;
    public string currentLevel;
    public string nextLevel;
    private LevelLoader levelLoader = new LevelLoader();

	public void showGameOver()
    {
        eyeLevelText.SetActive(true);
        text.GetComponent<Text>().text = "Your Castle Has Been Destroyed...";
        Invoke("loadCurrentLevel", 5);
    }

    public void showCongratulations()
    {
        eyeLevelText.SetActive(true);
        string winText = "Congratulations! you win!";
        if (nextLevel != null)
        {
            Invoke("loadNextLevel", 5);
            winText = winText + "\n Loading Next Level";
        }

        text.GetComponent<Text>().text = winText;
    }

    private void loadCurrentLevel()
    {
        eyeLevelText.SetActive(false);
        levelLoader.load(currentLevel);
    }

    private void loadNextLevel()
    {
        eyeLevelText.SetActive(false);
        levelLoader.load(nextLevel);
    }
}
