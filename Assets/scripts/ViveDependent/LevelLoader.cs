using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour, OnClickListener
{
    public string currentLevel;
    public string nextLevel;
  
    public void loadCurrentLevel()
    {
        load(currentLevel);
    }

    public void loadNextLevel()
    {
        load(nextLevel);
    }

    public void load(string nextLevel)
    {
        SteamVR_LoadLevel.Begin(nextLevel);
    }

    public void onClick()
    {
        load(nextLevel);
    }
}
