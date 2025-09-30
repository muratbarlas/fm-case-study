using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;
using System.Reflection;

public class SpinRoulette : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject[] rewardItems;
    public Button spinButton;
    public GameObject popupPanel;
    int spinStep = 0;
    bool startSpin = false;
    int randomStop;
    int shuffledIndexPointer = 0;
    bool passedOneLap = false;
    private List<int> shuffledStops;
    float stepTimer = 0f;
    public GameObject walletParent;
    public WalletData walletData;

    //public WalletData walletData;

    // void Awake()
    // {

    //     walletData = Resources.Load<WalletData>("ScriptableObjects/WalletData");
    //     if (walletData == null)
    //     {
    //         Debug.Log("null wallet");
    //     }
    //      else
    // {
    //     Debug.Log("WalletData loaded: " + walletData.name);
    // }
    // }

    void Start()
    {
        Debug.Log("entered spinroulette");
        rewardItems = GameObject.FindGameObjectsWithTag("RewardItem");
        shuffledStops = Enumerable.Range(0, rewardItems.Length).ToList();
        ShuffleStops();
        //print
        string listString = string.Join(", ", shuffledStops);
        Debug.Log("Shuffled order: " + listString);
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

            GameObject currentObj = rewardItems[spinStep];
            currentObj.transform.Find("Highlight").gameObject.SetActive(true);

            stepTimer += Time.deltaTime;
            if (stepTimer >= 0.08f)
            {
                stepTimer = 0f;
                spinStep++;
            }

            if (spinStep >= rewardItems.Length)
            {
                spinStep = 0;
                passedOneLap = true;

            }

            if (passedOneLap && spinStep == randomStop)
            {
                startSpin = false;
                passedOneLap = false;
                StartCoroutine(FlashAnimation(currentObj));
                updateWalletCount(currentObj);

            }
        }
    }

    void ShuffleStops()
    {
        for (int i = 0; i < shuffledStops.Count; i++)
        {
            int rand = Random.Range(i, shuffledStops.Count);
            int temp = shuffledStops[i];
            shuffledStops[i] = shuffledStops[rand];
            shuffledStops[rand] = temp;
        }
    }

    public void Spin()
    {
        spinButton.interactable = false;
        spinStep = 0;
        startSpin = true;
        randomStop = shuffledStops[shuffledIndexPointer];
        shuffledIndexPointer++;

    }

    public IEnumerator FlashAnimation(GameObject currentObj)
    {
        popupPanel.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            currentObj.transform.Find("Highlight").gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            currentObj.transform.Find("Highlight").gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(0.25f);
        popupPanel.SetActive(false);
        currentObj.transform.Find("Selected").gameObject.SetActive(true);
        currentObj.transform.Find("Check").gameObject.SetActive(true);
        if (shuffledIndexPointer == shuffledStops.Count)
        {
            Debug.Log("collected all rewards");
            SceneManager.LoadScene("TitleScene");
        }
        spinButton.interactable = true;

    }


    public void updateWalletCount(GameObject currentObj)
    {
        string foodType = currentObj.GetComponent<RewardItem>().foodType;
        Debug.Log(foodType);
        FieldInfo walletField = walletData.GetType().GetField(foodType, BindingFlags.Instance | BindingFlags.Public);
        int currentValue = (int)walletField.GetValue(walletData);
        int incrementedVal = currentValue+1;
        walletField.SetValue(walletData, incrementedVal);
        //update tmp on ui
        Transform FoodItem = walletParent.transform.Find(foodType);
        TextMeshPro tmp = FoodItem.GetComponentInChildren<TextMeshPro>();
        tmp.text = incrementedVal.ToString();
    }

}

