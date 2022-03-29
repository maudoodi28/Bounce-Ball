using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        GameManager.instance1.scoreup = false;
        GameManager.instancelife.lifePanel();
        BombSpawner.instancebomb.BombQuantityMinus();
    }
}
