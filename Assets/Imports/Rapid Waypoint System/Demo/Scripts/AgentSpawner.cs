using UnityEngine;
using System.Collections;

public class AgentSpawner : MonoBehaviour {

    public int[] units;
    public GameObject m_agentPrefab;
    public Castle target;
    private int m_amountToSpawn;
    public WaypointManager m_waypointManager;
    public float spawnInterval = 1.25f;
    protected int m_spawned = 0;
    public Transform m_spawnPoint;
    public bool m_infinite = false;

	// Use this for initialization
	void Start () {
        m_amountToSpawn = units.Length;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnInterval);
        GameObject objectEntity = (GameObject)Instantiate(m_agentPrefab, m_spawnPoint.position, m_spawnPoint.rotation);
        Enemy enemy = objectEntity.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.initActiveUnit(units[m_spawned]);
            enemy.setTarget(target);
        }
        m_waypointManager.AddEntity(objectEntity);

        if (m_spawned++ < m_amountToSpawn - 1 | m_infinite)
            StartCoroutine(Spawn());
    }


    public int getSpawnedCount()
    {
        return m_spawned;
    }

}
