using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaceButton : MonoBehaviour
{
    public enum productTypes {removeAds, coins15000, coins60000, coins120000 };
    public productTypes productType;

    public void purchaceButtonClicked()
    {
        switch (productType)
        {
            case productTypes.removeAds:
                IAPManager.instance.BuyRemoveAds();
                break;
            case productTypes.coins15000:
                IAPManager.instance.Buy15000coins();
                break;
            case productTypes.coins60000:
                IAPManager.instance.Buy60000coins();
                break;
            case productTypes.coins120000:
                IAPManager.instance.Buy120000coins();
                break;
        }
    }
}
