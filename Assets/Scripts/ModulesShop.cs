using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModulesShop : MonoBehaviour
{
    public GameObject buytext;

    public GameObject firstSection;
    public GameObject secondSection;
    public GameObject thirdSection;

    public GameObject[] headsOfRocket;
    public GameObject[] bodiesOfRocket;
    public GameObject[] bottomsOfRocket;

    public Button firstSectionButton;
    public Button secondSectionButton;
    public Button thirdSectionButton;

    public Button[] headButtons;
    public Button[] bodiesButtons;
    public Button[] bottomButtons;

    public GameObject[] headPrices;
    public GameObject[] bodiesPrices;
    public GameObject[] bottomPrices;

    public Button[] healthButtons;

    public AudioClip coinSound;
    public AudioSource mainSource;
    // Start is called before the first frame update



    public void buyHeads(int idOfHead)
    {
        switch (idOfHead)
        {
            case 0:
                pickHead(idOfHead);
                break;
            case 1:
                    if (PlayerPrefs.HasKey("firstHead"))
                    {
                        pickHead(idOfHead);
                    }
                    else if(PlayerPrefs.GetInt("money") >= 1500)
                    {
                    headPrices[idOfHead - 1].SetActive(false);
                    mainSource.PlayOneShot(coinSound);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 1500);
                        PlayerPrefs.SetInt("firstHead", 1);
                        pickHead(idOfHead);
                    }
                    else
                    {
                        StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
                        StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
                    }
                break;
            case 2:
                    if (PlayerPrefs.HasKey("secondHead"))
                    {
                        pickHead(idOfHead);
                    }
                    else if (PlayerPrefs.GetInt("money") >= 8500)
                    {
                    headPrices[idOfHead - 1].SetActive(false);
                    mainSource.PlayOneShot(coinSound);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 8500);
                        PlayerPrefs.SetInt("secondHead", 1);
                        pickHead(idOfHead);
                    }
                else
                {
                    StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
                    StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
                }
                break;
            case 3:
                
                    if (PlayerPrefs.HasKey("thirdHead"))
                    {
                        pickHead(idOfHead);
                    }
                    else if (PlayerPrefs.GetInt("money") >= 35000)
                    {
                    headPrices[idOfHead - 1].SetActive(false);
                    mainSource.PlayOneShot(coinSound);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 35000);
                        PlayerPrefs.SetInt("thirdHead", 1);
                        pickHead(idOfHead);
                    }
                else
                {
                    StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
                    StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
                }
                break;
        }
    }

    void pickHead(int idOfHead)
    {
        for (int i = 0; i < headsOfRocket.Length; i++)
        {
            headsOfRocket[i].SetActive(false);
        }
        firstSection.SetActive(false);
        PlayerPrefs.SetInt("idOfHead", idOfHead);
        headsOfRocket[idOfHead].SetActive(true);
        firstSectionButton.image.sprite = headButtons[idOfHead].image.sprite;
    }
    public void buyBodies(int idOfBody)
    {
        switch (idOfBody)
        {
            case 0:
                pickBody(idOfBody);
                break;
            case 1:
                if (PlayerPrefs.HasKey("firstBody"))
                {
                    pickBody(idOfBody);
                }
                else if (PlayerPrefs.GetInt("money") >= 1500)
                {
                    bodiesPrices[idOfBody - 1].SetActive(false);
                    mainSource.PlayOneShot(coinSound);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 1500);
                    PlayerPrefs.SetInt("firstBody", 1);
                    pickBody(idOfBody);
                }
                else
                {
                    StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
                    StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
                }
                break;
            case 2:
                if (PlayerPrefs.HasKey("secondBody"))
                {
                    pickBody(idOfBody);
                }
                else if (PlayerPrefs.GetInt("money") >= 8500)
                {
                    bodiesPrices[idOfBody - 1].SetActive(false);
                    mainSource.PlayOneShot(coinSound);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 8500);
                    PlayerPrefs.SetInt("secondBody", 1);
                    pickBody(idOfBody);
                }
                else
                {
                    StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
                    StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
                }
                break;
            case 3:

                if (PlayerPrefs.HasKey("thirdBody"))
                {
                    pickBody(idOfBody);
                }
                else if (PlayerPrefs.GetInt("money") >= 35000)
                {
                    bodiesPrices[idOfBody - 1].SetActive(false);
                    mainSource.PlayOneShot(coinSound);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 35000);
                    PlayerPrefs.SetInt("thirdBody", 1);
                    pickBody(idOfBody);
                }
                else
                {
                    StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
                    StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
                }
                break;
        }
    }

    void pickBody(int idOfBody)
    {
        for (int i = 0; i < bodiesOfRocket.Length; i++)
        {
            bodiesOfRocket[i].SetActive(false);
        }
        secondSection.SetActive(false);
        PlayerPrefs.SetInt("idOfBody", idOfBody);
        bodiesOfRocket[idOfBody].SetActive(true);
        secondSectionButton.image.sprite = bodiesButtons[idOfBody].image.sprite;
    }

    public void buyBottoms(int idOfBottom)
    {
        switch (idOfBottom)
        {
            case 0:
                pickBottom(idOfBottom);
                break;
            case 1:
                if (PlayerPrefs.HasKey("firstBottom"))
                {
                    pickBottom(idOfBottom);
                }
                else if (PlayerPrefs.GetInt("money") >= 1500)
                {
                    bottomPrices[idOfBottom - 1].SetActive(false);
                    mainSource.PlayOneShot(coinSound);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 1500);
                    PlayerPrefs.SetInt("firstBottom", 1);
                    pickBottom(idOfBottom);
                }
                else
                {
                    StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
                    StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
                }
                break;
            case 2:
                if (PlayerPrefs.HasKey("secondBottom"))
                {
                    pickBottom(idOfBottom);
                }
                else if (PlayerPrefs.GetInt("money") >= 8500)
                {
                    bottomPrices[idOfBottom - 1].SetActive(false);
                    mainSource.PlayOneShot(coinSound);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 8500);
                    PlayerPrefs.SetInt("secondBottom", 1);
                    pickBottom(idOfBottom);
                }
                else
                {
                    StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
                    StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
                }
                break;
            case 3:

                if (PlayerPrefs.HasKey("thirdBody"))
                {
                    pickBottom(idOfBottom);
                }
                else if (PlayerPrefs.GetInt("money") >= 35000)
                {
                    bottomPrices[idOfBottom - 1].SetActive(false);
                    mainSource.PlayOneShot(coinSound);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 35000);
                    PlayerPrefs.SetInt("thirdBottom", 1);
                    pickBottom(idOfBottom);
                }
                else
                {
                    StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
                    StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
                }
                break;
        }
    }

    void pickBottom(int idOfBottom)
    {
        for (int i = 0; i < bottomsOfRocket.Length; i++)
        {
            bottomsOfRocket[i].SetActive(false);
        }
        thirdSection.SetActive(false);
        PlayerPrefs.SetInt("idOfBottom", idOfBottom);
        bottomsOfRocket[idOfBottom].SetActive(true);
        thirdSectionButton.image.sprite = bottomButtons[idOfBottom].image.sprite;
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("firstHead"))
        {
            headPrices[0].SetActive(false);
        }
        if (PlayerPrefs.HasKey("secondHead"))
        {
            headPrices[1].SetActive(false);
        }
        if (PlayerPrefs.HasKey("thirdHead"))
        {
            headPrices[2].SetActive(false);
        }
        if (PlayerPrefs.HasKey("firstBody"))
        {
            bodiesPrices[0].SetActive(false);
        }
        if (PlayerPrefs.HasKey("secondBody"))
        {
            bodiesPrices[1].SetActive(false);
        }
        if (PlayerPrefs.HasKey("thirdBody"))
        {
            bodiesPrices[2].SetActive(false);
        }
        if (PlayerPrefs.HasKey("firstBottom"))
        {
            bottomPrices[0].SetActive(false);
        }
        if (PlayerPrefs.HasKey("secondBottom"))
        {
            bottomPrices[1].SetActive(false);
        }
        if (PlayerPrefs.HasKey("thirdBottom"))
        {
            bottomPrices[2].SetActive(false);
        }

        if (PlayerPrefs.HasKey("healthButton1"))
        {
            healthButtons[0].interactable = false;
        }
        if (PlayerPrefs.HasKey("healthButton2"))
        {
            healthButtons[1].interactable = false;
        }
        if (PlayerPrefs.HasKey("healthButton3"))
        {
            healthButtons[2].interactable = false;
        }

        if (!PlayerPrefs.HasKey("idOfHead")){
            PlayerPrefs.SetInt("idOfHead", 0);
            PlayerPrefs.SetInt("idOfBody", 0);
            PlayerPrefs.SetInt("idOfBottom", 0);
        }
        else
        {
            for (int i = 0; i < headsOfRocket.Length; i++)
            {
                headsOfRocket[i].SetActive(false);
            }
            for (int i = 0; i < bodiesOfRocket.Length; i++)
            {
                bodiesOfRocket[i].SetActive(false);
            }
            for (int i = 0; i < bottomsOfRocket.Length; i++)
            {
                bottomsOfRocket[i].SetActive(false);
            }
            headsOfRocket[PlayerPrefs.GetInt("idOfHead")].SetActive(true);
            firstSectionButton.image.sprite = headButtons[PlayerPrefs.GetInt("idOfHead")].image.sprite;
            bodiesOfRocket[PlayerPrefs.GetInt("idOfBody")].SetActive(true);
            secondSectionButton.image.sprite = bodiesButtons[PlayerPrefs.GetInt("idOfBody")].image.sprite;
            bottomsOfRocket[PlayerPrefs.GetInt("idOfBottom")].SetActive(true);
            thirdSectionButton.image.sprite = bottomButtons[PlayerPrefs.GetInt("idOfBottom")].image.sprite;
        }
    }

    public void buyIt(int price)
    {
        if (PlayerPrefs.GetInt("money") >= price)
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);
            PlayerPrefs.SetInt("maxHearts", PlayerPrefs.GetInt("maxHearts") + 1);
            switch (price)
            {
                case 1000:
                    PlayerPrefs.SetInt("healthButton1", 1);
                    healthButtons[0].interactable = false;
                    mainSource.PlayOneShot(coinSound);
                    break;
                case 5000:
                    PlayerPrefs.SetInt("healthButton2", 1);
                    healthButtons[1].interactable = false;
                    mainSource.PlayOneShot(coinSound);
                    break;
                case 10000:
                    PlayerPrefs.SetInt("healthButton3", 1);
                    healthButtons[2].interactable = false;
                    mainSource.PlayOneShot(coinSound);
                    break;
            }
        } else
        {
            StartCoroutine(Timer(0f, () => { buytext.SetActive(true); }));
            StartCoroutine(Timer(1f, () => { buytext.SetActive(false); }));
        }

    }

    public void chooseSection(GameObject section)
    {
        firstSection.SetActive(false);
        secondSection.SetActive(false);
        thirdSection.SetActive(false);
        section.SetActive(true);
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
