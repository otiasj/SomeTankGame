using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour, OnClickListener
{
    public string levelToLoad;

    public void load()
    {
        load(levelToLoad);
    }

    public void load(string nextLevel)
    {
        SteamVR_LoadLevel.Begin(nextLevel);
    }

    public void onClick()
    {
        load();
    }
}
