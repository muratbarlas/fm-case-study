using UnityEngine;

public class SpinRoulette : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject[] rewardItems;

    void Start()
    {
        Debug.Log('h');
        rewardItems = GameObject.FindGameObjectsWithTag("RewardItem");

        Spin();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spin()
    {
        Debug.Log(rewardItems);

        foreach (GameObject obj in rewardItems)
        {
            Debug.Log(obj.GetComponent<RewardItem>().id);
        }
    }
}
