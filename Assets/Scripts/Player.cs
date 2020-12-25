using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Unity.Mathematics;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    public GameObject menuOfDeath;
    public static int healthOfRocket;
    public static int maxNumberOfHealth;

    public Image[] hearts;
    public Sprite heartSprite;
    public Sprite emptySprite;

    public Text text;
    public Text scoreText;
    public Image timerForVideo;
    public static float timeForTask = 100;
    float timeForTaskBar = 0;
    bool checkDeath = false;
    public Button restoreButton;
    public Text moneyText;

    public Button removeAdsButton1;
    public Button removeAdsButton2;

    public GameObject firstScreen;

    void Start()
    {
        if (!PlayerPrefs.HasKey("firstTime"))
        {
            firstScreen.SetActive(true);
            PlayerPrefs.SetInt("firstTime", 1);
        }
        scoreText.text = PlayerPrefs.GetInt("highestScore").ToString();
        moneyText.text = PlayerPrefs.GetInt("money").ToString();
        if (!PlayerPrefs.HasKey("maxHearts"))
        {
            PlayerPrefs.SetInt("maxHearts", 3);
        }
        maxNumberOfHealth = PlayerPrefs.GetInt("maxHearts");
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Meteor")
        {
            Destroy(collision.gameObject);
            MeshRenderer rocketRendered = GetComponent<MeshRenderer>();
            Collider rockCollider = GetComponent<Collider>();
            StartCoroutine(Timer(0f, () => { rockCollider.enabled = false; }));
            /*StartCoroutine(Timer(0f, () => { rocketRendered.enabled = false; }));
            StartCoroutine(Timer(0.5f, () => { rocketRendered.enabled = true; }));
            StartCoroutine(Timer(1f, () => { rocketRendered.enabled = false; }));
            StartCoroutine(Timer(1.5f, () => { rocketRendered.enabled = true; }));*/
            StartCoroutine(Timer(1.5f, () => { rockCollider.enabled = true; }));
            StartCoroutine(Timer(0f, () => { text.text = "Ouch!"; }));
            StartCoroutine(Timer(0.8f, () => { text.text = ""; }));

            if (healthOfRocket > 0)
            {
                healthOfRocket--;
            }
            if (healthOfRocket <= 0)
            {
                menuOfDeath.SetActive(true);
                if (MeteorSpawning.scoreCount > PlayerPrefs.GetInt("highestScore"))
                {
                    PlayerPrefs.SetInt("highestScore", MeteorSpawning.scoreCount);
                    scoreText.text = "Highest Score:\n" + PlayerPrefs.GetInt("highestScore").ToString();
                }
                checkDeath = true;
                Time.timeScale = 0.05f;
            }
        }
        else if (collision.gameObject.tag == "Money")
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 20);
            StartCoroutine(Timer(0f, () => { text.text = "+20"; }));
            StartCoroutine(Timer(0.8f, () => { text.text = ""; }));
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("removeAds"))
        {
            if (PlayerPrefs.GetInt("removeAds") == 1)
            {
                removeAdsButton1.interactable = false;
                removeAdsButton2.interactable = false;
            }
        }

        moneyText.text = PlayerPrefs.GetInt("money").ToString();
        if (healthOfRocket > maxNumberOfHealth)
        {
            healthOfRocket = maxNumberOfHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < healthOfRocket)
            {
                hearts[i].sprite = heartSprite;
            }
            else
            {
                hearts[i].sprite = emptySprite;
            }
            if (i < maxNumberOfHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (checkDeath)
        {
            timeForTask -= Time.timeScale * 2;
            timeForTaskBar = Mathf.Clamp(timeForTask, 0f, 100f) / 100;
            timerForVideo.fillAmount = timeForTaskBar;
            if (timerForVideo.fillAmount <= 0)
            {
                checkDeath = false;
                restoreButton.interactable = false;
                if (AdManager.checkWatched)
                {
                    AdManager.checkWatched = false;
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
        }
    }
    public void restorePlayer()
    {
        transform.position = new Vector3(0, 0, 0);
        restoreButton.interactable = true;
        AdManager.checkWatched = false;
        checkDeath = false;
        timeForTask = 100;
        timerForVideo.fillAmount = 1;
        Time.timeScale = 1;
        menuOfDeath.SetActive(false);
        healthOfRocket = maxNumberOfHealth;
    }

    IEnumerator Timer(float time, System.Action action)
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        action();
    }
}
