using UnityEngine;

public class SpinRoulette : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject[] rewardItems;
    int counter = 0;

    void Start()
    {
        Debug.Log("entered spinroulette");
        rewardItems = GameObject.FindGameObjectsWithTag("RewardItem");

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < rewardItems.Length; i++)
        {
            rewardItems[i].transform.Find("Highlight").gameObject.SetActive(false);
        }


        GameObject currentObj = rewardItems[counter];
        currentObj.transform.Find("Highlight").gameObject.SetActive(true);


        if (Time.frameCount % 1000 == 0)
        {
            counter++;
        }

        if (counter >= rewardItems.Length)
        {
            counter = 0;
        }
            
    }

    
}
