using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MeteorSpawning : MonoBehaviour
{
    public GameObject meteor;
    public GameObject player;
    Vector3 spawnPosition;
    public float timeOnTask;
    public float repeatTime;
    public bool spawningOfMeteors;
    public GameObject startButton;
    public GameObject healthBar;
    
    public Text scores;
    public GameObject highestScore;
    public GameObject collectableScores;
    bool scoreGaining = false;
    public static int scoreCount;
    public GameObject reactors;
    public Text rewardText;
    public Text moneyText;
    public GameObject moneyItself;
    public GameObject effectsOfSpace;

    void Update()
    {
        if (scoreGaining)
        {
            scores.text = scoreCount.ToString();
        }
    }

    void Awake()
    {

    }
    public void invokeSpawning()
    {
        moneyItself.SetActive(false);
        collectableScores.SetActive(true);
        highestScore.SetActive(false);
        rewardText.text = "";
        reactors.SetActive(true);
        scoreGaining = true;
        startButton.SetActive(false);
        healthBar.SetActive(true);
        InvokeRepeating("spawnGameObject", timeOnTask, repeatTime);
        effectsOfSpace.SetActive(true);
    }

    public void cancelSpawning()
    {
        moneyItself.SetActive(true);
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + (scoreCount/10));
        moneyText.text = PlayerPrefs.GetInt("money").ToString();
        collectableScores.SetActive(false);
        highestScore.SetActive(true);
        scores.text = PlayerPrefs.GetInt("highestScore").ToString();
        reactors.SetActive(false);
        scoreCount = 0;
        scoreGaining = false;
        CancelInvoke("spawnGameObject");
        healthBar.SetActive(false);
        startButton.SetActive(true);
        effectsOfSpace.SetActive(false);
    }
   void spawnGameObject()
    {
        spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), player.transform.position.y + 10f, 0f);
        Instantiate(meteor, spawnPosition, Quaternion.Euler(Random.Range(1, 90), Random.Range(1, 90), Random.Range(1, 90)));
        scoreCount += 10;
        Vector3 customScale = new Vector3 (Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3));
        meteor.transform.localScale = customScale;
    }
}
