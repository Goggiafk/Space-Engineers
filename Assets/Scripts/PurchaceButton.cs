using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaceButton : MonoBehaviour
{
    public enum productTypes {removeAds };
    public productTypes productType;

    public void purchaceButtonClicked()
    {
        switch (productType)
        {
            case productTypes.removeAds:
                IAPManager.instance.BuyRemoveAds();
                break;
        }
    }
}
