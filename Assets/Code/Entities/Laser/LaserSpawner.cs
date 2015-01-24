using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laser;

    public float intervalTime;
    public float intervalRandomRange;
    public float spawnRangeY;

    private float timer;
	// Use this for initialization
	void Start ()
	{
	    ResetTimer();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer -= Time.deltaTime;
	    if(timer <= 0)
	    {
	        SpawnLaser();
            ResetTimer();
	    }
	}

    void ResetTimer()
    {
        if(intervalRandomRange > 0)
        {
            timer = Random.Range(intervalTime + intervalRandomRange, intervalTime - intervalRandomRange);
        }
        else
        {
            timer = intervalTime;
        }
    }

    void SpawnLaser()
    {
        float spawnPositionY;
        if (spawnRangeY > 0)
        {
            spawnPositionY = Random.Range(transform.position.y + spawnRangeY, transform.position.y - spawnRangeY);
        }
        else
        {
            spawnPositionY = transform.position.y;
        }
        var spawnPosition = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        var laser = (GameObject)Instantiate(this.laser, spawnPosition, transform.rotation);
        laser.BroadcastMessage("OnActivate");
    }
}
