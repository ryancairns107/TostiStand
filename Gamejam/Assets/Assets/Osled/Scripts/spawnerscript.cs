using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerscript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject box;
    public GameObject hand;
    float randx;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Time.time > nextSpawn)
        {
            Instantiate(hand, whereToSpawn, Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
            randx = Random.Range(-85.8f, -73.9f);
            whereToSpawn = new Vector2(randx, transform.position.y);
            Instantiate(box, whereToSpawn, Quaternion.identity);


        }
    }

    
      
    
}
