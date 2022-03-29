using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public float MaxX;
    public GameObject[] Bombs;
    public int BombQuantity = 0;
    public int BmQuantity=1;
    public static BombSpawner instance;
    public static BombSpawner instancebomb;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        instancebomb = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSpawningBomb();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBomb()
    {
        if(BombQuantity<=BmQuantity)
        {
            int rand = Random.Range(0, Bombs.Length);
            float randomx = Random.Range(-2.5f, MaxX);
            Vector3 randompos = new Vector3(randomx, transform.position.y, transform.position.z);
            Instantiate(Bombs[rand], randompos, transform.rotation);
            BombQuantity++;
        }
         
    }

    IEnumerator SpawnerBomb()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {

            SpawnBomb();
            yield return new WaitForSeconds(3f);
            
        }
    }

    public void StartSpawningBomb()
    {
        StartCoroutine("SpawnerBomb");
    }
    public void StopSpawningBomb()
    {
        StopCoroutine("SpawnerBomb");
    }
    public void BombQuantityMinus()
    {
        BombQuantity = BombQuantity - 1;
    }
}
