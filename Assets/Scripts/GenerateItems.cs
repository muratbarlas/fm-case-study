using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GenerateItems : MonoBehaviour
{

    public GameObject objectPrefab;   // A prefab with a SpriteRenderer
    public Sprite[] rewardSprites;
    //public List<GameObject> enemies;    
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            // Pick a position (for example, spread them out on the X axis)
            Vector3 spawnPos = new Vector3(i * 2f, 0, 0);

            // Instantiate prefab
            GameObject newObj = Instantiate(objectPrefab, spawnPos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
