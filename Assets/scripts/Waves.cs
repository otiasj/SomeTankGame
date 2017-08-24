using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    public Castle castle;
    public LevelLoader level;

    private WinLose winLose;

    private int score = -1;
    private PointsIndicator pointsIndicator;

    private int enemyCount = -1;
    public int maxSpawnCount = 0;

    //caching
    private int newScore = -1;
    private int enemyLeft = 0;

    private void Start()
    {
        this.winLose = GetComponent<WinLose>();
        this.pointsIndicator = GetComponent<PointsIndicator>();

        pointsIndicator.setTitle(level.currentLevel);

        updateEnemyCount();
    }

    private void Update()
    {
        updateScore();
        updateEnemyCount();
    }

    private void updateEnemyCount()
    {
        enemyLeft = maxSpawnCount - (castle.getEnemyDestroyedCount() + castle.getEnemyKilled());
        if (enemyLeft != enemyCount)
        {
            pointsIndicator.setColumn2("Enemy Left: " + enemyLeft);
            enemyCount = enemyLeft;

            if ((enemyLeft == 0) && (castle.castleHealthPoints > 0))
            {
                //WON!
                //Debug.Log("WON1! "+ ScenePersistant.Instance.totalScore + " " + newScore);
                ScenePersistant.Instance.totalScore = (ScenePersistant.Instance.totalScore + newScore);
                pointsIndicator.setColumn3("Score: " + ScenePersistant.Instance.totalScore);
                winLose.showCongratulations();
                //Debug.Log("WON2! " + ScenePersistant.Instance.totalScore + " " + newScore);
            }
        }
    }

    private void updateScore()
    {
        newScore = castle.getEnemyHit() * 100 + castle.getEnemyKilled() * 1000;
        if (newScore != score)
        {
            score = newScore;
            newScore = (ScenePersistant.Instance.totalScore + newScore);
            //pointsIndicator.setColumn3("\nTotal score: " + );
            pointsIndicator.setColumn3("Score: " + newScore);
        }
    }

}
