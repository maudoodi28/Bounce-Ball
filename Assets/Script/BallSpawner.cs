using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    
    public float maxX;
    public int BallQuantity=0;
    public int BQuantity=4;
    public GameObject[] Balls;

    public static BallSpawner instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSpawningBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnerBall()
    {
        if(BallQuantity<=BQuantity)
        {
            int rand = Random.Range(0, Balls.Length);
            float randomX = Random.Range(-2f, maxX);
            Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);
            Instantiate(Balls[rand], randomPos, transform.rotation);
            BallQuantity++;
        }
    }

    IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            
            SpawnerBall();
            yield return new WaitForSeconds(2f);
            
        }
    }

    public void StartSpawningBall()
    {
        StartCoroutine("SpawnBall");
    }
    public void StopSpawningBall()
    {
        StopCoroutine("SpawnBall");
    }
    public void BallQuantityMinus()
    {
        BallQuantity = BallQuantity - 1;
    }
}
