using UnityEngine;

public class GenerateItems : MonoBehaviour
{

    public GameObject objectPrefab;   
    public Sprite[] rewardSprites;
    void Start()
    {
        float spacing = 3f;
        float startX = -4.5f; 
        float startY = 5f;   
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {

                Vector3 spawnPos = new Vector3(startX + col * spacing, startY - row * spacing, 0);
                GameObject newObj = Instantiate(objectPrefab, spawnPos, Quaternion.identity);
                newObj.tag = "RewardItem";
                SpriteRenderer reward = newObj.transform.Find("Reward").GetComponent<SpriteRenderer>();
                reward.sprite = rewardSprites[Random.Range(0, rewardSprites.Length)];

                RewardItem rewardFields = newObj.GetComponent<RewardItem>();

                
                rewardFields.foodType = reward.sprite.name.Replace("-", "");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
