using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    public WaypointManager waypointManager;
    public AgentSpawner agentSpawner;
    public Castle castle;

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
        int enemyLeft = agentSpawner.m_amountToSpawn - castle.getEnemyDestroyedCount();
        if (enemyLeft != enemyCount)
        {
            Debug.Log("getSpawnedCount! " + agentSpawner.getSpawnedCount() + " m_amountToSpawn " + agentSpawner.m_amountToSpawn + " AgentQuantity " + castle.getEnemyDestroyedCount());
            
            pointsIndicator.setColumn2("Enemy Left: " + enemyLeft);
            enemyCount = enemyLeft;

            if (enemyLeft == 0)
            {
                //WON!
                Debug.Log("WON! ");
                winLose.showCongratulations();
            }
        }
    }

}
