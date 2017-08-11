using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    public WaypointManager waypointManager;
    public AgentSpawner agentSpawner;

    private WinLose winLose;
    private PointsIndicator pointsIndicator;

    private int enemyCount = -1;

    private void Start()
    {
        this.winLose = GetComponent<WinLose>();
        this.pointsIndicator = GetComponent<PointsIndicator>();

        
        pointsIndicator.setTitle("Level 1");

        updateEnemyCount();
    }

    private void Update()
    {
        updateEnemyCount();
    }

    private void updateEnemyCount()
    {
        if (enemyCount != waypointManager.AgentQuantity)
        {
            int count = waypointManager.AgentQuantity;
            pointsIndicator.setColumn2("Enemy Left: " + (agentSpawner.m_amountToSpawn - count));
            enemyCount = count;
        }
    }

}
