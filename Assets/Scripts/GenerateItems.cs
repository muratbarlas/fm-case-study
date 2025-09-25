using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GenerateItems : MonoBehaviour
{

    public GameObject objectPrefab;   
    public Sprite[] rewardSprites;
    //public List<GameObject> enemies;    
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = new Vector3(i * 2f, 0, 0);

            GameObject newObj = Instantiate(objectPrefab, spawnPos, Quaternion.identity);
            SpriteRenderer sr = newObj.GetComponent<SpriteRenderer>();
            
            sr.sprite = rewardSprites[Random.Range(0, rewardSprites.Length)];
            


        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
