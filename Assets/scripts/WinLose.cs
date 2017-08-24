using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour {

    public GameObject eyeLevelText;
    public GameObject text;
    public LevelLoader levelLoader;
    public AudioSource victorySound;
    public AudioSource ambiantSound;

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
        if (levelLoader.nextLevel != null && levelLoader.nextLevel.Length > 0)
        {
            Invoke("loadNextLevel", 5);
            winText = winText + "\n Loading Next Level";
        } else
        {
            winText = winText + "\n You have beat the game with a\nscore of "+ ScenePersistant.Instance.totalScore;
            Invoke("Reset", 15);
        }

        text.GetComponent<Text>().text = winText;
        ambiantSound.Stop();
        victorySound.Play();
    }

    private void loadCurrentLevel()
    {
        eyeLevelText.SetActive(false);
        levelLoader.loadCurrentLevel();
    }

    private void loadNextLevel()
    {
        eyeLevelText.SetActive(false);
        levelLoader.loadNextLevel();
    }

    private void Reset()
    {
        ScenePersistant.Instance.totalScore = 0;
        levelLoader.nextLevel = "intro";
        loadNextLevel();
    }
}
