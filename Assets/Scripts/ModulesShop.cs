using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModulesShop : MonoBehaviour
{
    public Button buttonOne;
    public Text buytext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void buyIt()
    {
        if (PlayerPrefs.GetInt("money") >= 100)
        {
            buttonOne.interactable = false;
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 100);
            if (!PlayerPrefs.HasKey("maxHearts"))
            {
                PlayerPrefs.SetInt("maxHearts", 4);
            }
            PlayerPrefs.SetInt("maxHearts", 4);
        } else
        {
            buytext.text = "Not enough money";
        }

    }
}
