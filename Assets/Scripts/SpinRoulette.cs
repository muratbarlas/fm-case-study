using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpinRoulette : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject[] rewardItems;
    public Button spinButton;
    int counter = 0;
    bool startSpin = false;
    int randomStop = 0;
    bool passedOneLap = false;


    void Start()
    {
        Debug.Log("entered spinroulette");
        rewardItems = GameObject.FindGameObjectsWithTag("RewardItem");

    }

    // Update is called once per frame
    void Update()
    {
        if (startSpin)
        {
            for (int i = 0; i < rewardItems.Length; i++)
            {
                rewardItems[i].transform.Find("Highlight").gameObject.SetActive(false);
            }


            GameObject currentObj = rewardItems[counter];
            currentObj.transform.Find("Highlight").gameObject.SetActive(true);

            if (Time.frameCount % 500 == 0)
            {
                counter++;
            }

            if (counter >= rewardItems.Length)
            {
                counter = 0;
                passedOneLap = true;

            }

            if (passedOneLap && counter == randomStop)
            {
                startSpin = false;
                passedOneLap = false;
                spinButton.interactable = true;
                StartCoroutine(FlashAnimation(currentObj));
            }

        }
    }


    public void Spin()
    {
        spinButton.interactable = false;
        counter = 0;
        startSpin = true;
        randomStop = Random.Range(0, rewardItems.Length);
    }


    public IEnumerator FlashAnimation(GameObject currentObj)
    {
        for (int i = 0; i < 4; i++)   
        {
            currentObj.transform.Find("Highlight").gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            currentObj.transform.Find("Highlight").gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }

    }

}

