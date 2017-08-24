using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersistant : MonoBehaviour
{
    public int totalScore = 0;
    private static object syncRoot = new Object();

    private static volatile ScenePersistant instance;

    public static ScenePersistant Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        GameObject scenePersistant = new GameObject("[ScenePersistant]");
                        instance = scenePersistant.AddComponent<ScenePersistant>();
                        DontDestroyOnLoad(scenePersistant);
                    }
                }
            }
            return instance;
        }
    }
}
