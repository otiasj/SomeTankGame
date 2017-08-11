using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {
    
    public int castleHealthPoints = 100;
    public GameObject explosion;

    //explosion of the castle
    public int explosionCount = 10;
    public float explosionRadius = 5;

    private WinLose winLose;
    private PointsIndicator pointsIndicator;

    private void Start()
    {
        this.winLose = GetComponent<WinLose>();
        this.pointsIndicator = GetComponent<PointsIndicator>();
        pointsIndicator.setColumn1("Castle HP: " + castleHealthPoints + "HP");
    }

    public void takeHit(int damages)
    {
        //Debug.Log("Take Hit " + damages);
        castleHealthPoints = castleHealthPoints - damages;

        pointsIndicator.setTitle("Ouch! -"+damages+ "HP!");
        if (castleHealthPoints <= 0)
        {
            castleHealthPoints = 0;
            pointsIndicator.setTitle("GAME OVER!");
            Invoke("explode", 0.5f);
        }
        pointsIndicator.setColumn1("Castle HP: " + castleHealthPoints + "HP");
    }

    private void explode()
    {
        for (int i = 0; i < explosionCount; i++)
        {
            GameObject explosionInstance = Instantiate(explosion, Random.insideUnitSphere * explosionRadius + transform.position, Random.rotation);
            Destroy(explosionInstance, 12);//destroy the explosion object after 12seconds
        }
    }

    private void gameOver()
    {
        winLose.showGameOver();
    }

}
