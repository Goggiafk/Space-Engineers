using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MeteorSpawning : MonoBehaviour
{
    public GameObject[] meteors;
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

    public GameObject multiplierItself;
    public Text multiplierText;

    int multiplier;

    void Update()
    {
        multiplier = (Mathf.RoundToInt(MeteorCollision.speedOfMeteors/5)+1);
        multiplierText.text = multiplier.ToString();

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
        Player.maxNumberOfHealth = PlayerPrefs.GetInt("maxHearts");
        Player.healthOfRocket = PlayerPrefs.GetInt("maxHearts");
        moneyItself.SetActive(false);
        multiplierItself.SetActive(true);
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
        multiplierItself.SetActive(false);
        moneyItself.SetActive(true);
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + (scoreCount * multiplier / 10));
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
        Player.healthOfRocket = PlayerPrefs.GetInt("maxHearts");
    }
    void spawnGameObject()
    {
        spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), player.transform.position.y + 10f, 0f);
        int randomMeteor = Random.Range(0, meteors.Length);
        if (!(randomMeteor == 10))
        {
            Instantiate(meteors[randomMeteor], spawnPosition, Quaternion.Euler(Random.Range(1, 90), Random.Range(1, 90), Random.Range(1, 90)));
            Vector3 customScale = new Vector3(Random.Range(2, 4), Random.Range(1, 4), Random.Range(1, 3));
            meteors[randomMeteor].transform.localScale = customScale;
        }
        else
        {
            Instantiate(meteors[randomMeteor], spawnPosition, Quaternion.identity);
            meteors[10].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        scoreCount += 10;
    }
}
