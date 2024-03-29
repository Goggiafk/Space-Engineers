﻿using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public Text purchacesText;
    public GameObject settingsMenu;
    public GameObject purchaceMenu;
    public Text moneyText;

    public static IAPManager instance;

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    //Step 1 create your products
    private string removeAds = "remove_ads";
    private string coins15000 = "coins10000";
    private string coins60000 = "coins50000";
    private string coins120000 = "coins100000";


    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable
        builder.AddProduct(removeAds, ProductType.NonConsumable);
        builder.AddProduct(coins15000, ProductType.Consumable);
        builder.AddProduct(coins60000, ProductType.NonConsumable);
        builder.AddProduct(coins120000, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyRemoveAds()
    {
        BuyProductID(removeAds);
    }
    public void Buy15000coins()
    {
        BuyProductID(coins15000);
    }
    public void Buy60000coins()
    {
        BuyProductID(coins60000);
    }
    public void Buy120000coins()
    {
        BuyProductID(coins120000);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //Step 3 Create methods




    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, removeAds, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchace: PASS product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("removeAds", 1);
        } else if (String.Equals(args.purchasedProduct.definition.id, coins15000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchace: PASS product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 15000);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coins60000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchace: PASS product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 60000);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coins120000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchace: PASS product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 120000);
        } 
        else
        {
            Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
    }

    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
    }

    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchacing product asychronously: '{0}'", product.definition.id));
                changeScreenToPurchace();
                purchacesText.text = "Thanks for your purchace!";
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                changeScreenToPurchace();
                purchacesText.text = "Purchace failed \n :c";
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
            changeScreenToPurchace();
            purchacesText.text = "Purchace failed :c";
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }

    void changeScreenToPurchace()
    {
        settingsMenu.SetActive(false);
        purchaceMenu.SetActive(true);
    }
}