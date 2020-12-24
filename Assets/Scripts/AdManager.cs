using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;

[RequireComponent(typeof(Button))]
public class AdManager : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "3944554";
#elif UNITY_ANDROID
    private string gameId = "3944555";
#endif
    public Text rewardText;
    public GameObject menuOfDeath;
    public GameObject heart1;
    public bool isTestBool = false;
    public Image restoreHealth;
    public static bool checkWatched = false;

    // Update is called once per frame
    void Update()
    {

    }

    Button myButton;
    string myPlacementId = "rewardedVideo";

    void Start()
    {
        Advertisement.AddListener(this);

        myButton = GetComponent<Button>();

        myButton.interactable = Advertisement.IsReady(myPlacementId);

        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        rewardText.text = "";
        if (PlayerPrefs.HasKey("removeAds"))
        {
            if(PlayerPrefs.GetInt("removeAds") == 1)
            {
                rewardPlayer();
            }
        } else
        {
            Advertisement.Show(myPlacementId);
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            rewardPlayer();
        }
        else if (showResult == ShowResult.Skipped)
        {
            rewardText.text = "The ad did not finish due to a skip.";
        }
        else if (showResult == ShowResult.Failed)
        {
           rewardText.text = "The ad did not finish due to an error.";
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    void advertismentInitialize()
    {
        Advertisement.Initialize(gameId, isTestBool);
    }

    void rewardPlayer()
    {
        checkWatched = true;
        heart1.SetActive(true);
        menuOfDeath.SetActive(false);
        Player.timeForTask = 0;
        restoreHealth.fillAmount = 0;
    }
}


