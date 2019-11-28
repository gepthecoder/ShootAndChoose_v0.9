using System;
using UnityEngine;
//using UnityEngine.Purchasing;
using UnityEngine.UI;

// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class IAPManager : MonoBehaviour/*, IStoreListener*/
{
    //private static IAPManager Instance { get; set; }

    //private static IStoreController m_StoreController;          // The Unity Purchasing system.
    //private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    //public static string PRODUCT_5000_RED_EMERALD = "red_emerald5000";
    //public static string PRODUCT_1000_GREEN_EMERALD = "green_emerald1000";
    //public static string PRODUCT_1000_BLUE_EMERALD = "blue_emerald1000";
    //public static string PRODUCT_1000_PURPLE_EMERALD = "purple_emerald1000";
    //public static string PRODUCT_1000_GOLDEN_EMERALD = "gold_emerald1000";

    //public static string PRODUCT_99999_COINS = "golden_coins99999";
    //public static string PRODUCT_50_HEALTH = "live_heart50";
    //public static string PRODUCT_10_HEALTH = "live_heart10";
    //public static string PRODUCT_4_HEALTH = "live_heart4";

    //public static string PRODUCT_NOADS = "no_ads";

    //public int BoughtNO_ADS = 0;

    //public Text PurchaseShopLiveCount;
    //public GameObject BoughtAdsBase;

    //private void Awake()
    //{
    //    Instance = this;

    //    if (PlayerPrefs.HasKey("boughtNoAds"))
    //    {
    //        //we had a previous session
    //        BoughtNO_ADS = PlayerPrefs.GetInt("boughtNoAds", 0);
    //        Debug.Log(BoughtNO_ADS + "   <-- bought no Ads has key");
    //    }
    //    else { Save(); }
    //}

    //private void Save()
    //{
    //    PlayerPrefs.SetInt("boughtNoAds", BoughtNO_ADS);
    //    Debug.Log(BoughtNO_ADS + "   <-- bought no Ads save");

    //}

    //private void Start()
    //{

    //    // If we haven't set up the Unity Purchasing reference
    //    if (m_StoreController == null)
    //    {
    //        // Begin to configure our connection to Purchasing
    //        InitializePurchasing();
    //    }

    //    if (!UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Contains("Level"))
    //        PurchaseShopLiveCount.text = PlayerPrefs.GetInt("playerHealth", 4).ToString();

    //    Debug.Log("Player health start: " + PlayerPrefs.GetInt("playerHealth")); 
   
    //}

    //void Update()
    //{
    //    if (PlayerPrefs.GetInt("boughtNoAds") == 1)
    //    {
    //        BoughtAdsBase.SetActive(true);
    //    }
    //    else {
    //        BoughtAdsBase.SetActive(false);
    //    }
    //}

    //public void InitializePurchasing()
    //{
    //    // If we have already connected to Purchasing ...
    //    if (IsInitialized())
    //    {
    //        // ... we are done here.
    //        return;
    //    }

    //    // Create a builder, first passing in a suite of Unity provided stores.
    //    var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

    //    builder.AddProduct(PRODUCT_5000_RED_EMERALD, ProductType.Consumable);
    //    builder.AddProduct(PRODUCT_1000_GREEN_EMERALD, ProductType.Consumable);
    //    builder.AddProduct(PRODUCT_1000_BLUE_EMERALD, ProductType.Consumable);
    //    builder.AddProduct(PRODUCT_1000_PURPLE_EMERALD, ProductType.Consumable);
    //    builder.AddProduct(PRODUCT_1000_GOLDEN_EMERALD, ProductType.Consumable);
        
    //    builder.AddProduct(PRODUCT_99999_COINS, ProductType.Consumable);
    //    builder.AddProduct(PRODUCT_50_HEALTH, ProductType.Consumable);
    //    builder.AddProduct(PRODUCT_10_HEALTH, ProductType.Consumable);
    //    builder.AddProduct(PRODUCT_4_HEALTH, ProductType.Consumable);

    //    builder.AddProduct(PRODUCT_NOADS, ProductType.NonConsumable); //ONLY BUY IT ONCE

    //    UnityPurchasing.Initialize(this, builder);
    //}


    //private bool IsInitialized()
    //{
    //    // Only say we are initialized if both the Purchasing references are set.
    //    return m_StoreController != null && m_StoreExtensionProvider != null;
    //}


    //public void Buy5000RedEmeralds()
    //{
    //    ShopAudioManager.buy_sound = true;
    //    BuyProductID(PRODUCT_5000_RED_EMERALD);
    //}
    //public void Buy1000GreenEmeralds()
    //{
    //    BuyProductID(PRODUCT_1000_GREEN_EMERALD);
    //    ShopAudioManager.buy_sound = true;

    //}
    //public void Buy1000BlueEmeralds()
    //{
    //    BuyProductID(PRODUCT_1000_BLUE_EMERALD);
    //    ShopAudioManager.buy_sound = true;

    //}
    //public void Buy1000PurpleEmeralds()
    //{
    //    BuyProductID(PRODUCT_1000_PURPLE_EMERALD);
    //    ShopAudioManager.buy_sound = true;

    //}
    //public void Buy1000GoldenEmeralds()
    //{
    //    BuyProductID(PRODUCT_1000_GOLDEN_EMERALD);
    //    ShopAudioManager.buy_sound = true;

    //}

    //public void Buy99999Coins()
    //{
    //    BuyProductID(PRODUCT_99999_COINS);
    //    ShopAudioManager.buy_sound = true;
    //}


    //public void Buy50Health()
    //{
    //    BuyProductID(PRODUCT_50_HEALTH);
    //    audioManager.purchaseHappend = true;
    //    GetMoreLives.userBoughtItem = true;
    //    ShopAudioManager.buy_sound = true;
    //}
    //public void Buy10Health()
    //{
    //    BuyProductID(PRODUCT_10_HEALTH);
    //    audioManager.purchaseHappend = true;
    //    GetMoreLives.userBoughtItem = true;
    //}
    //public void Buy4Health()
    //{
    //    Debug.Log("Player Health before: " + PlayerPrefs.GetInt("playerHealth"));
    //    BuyProductID(PRODUCT_4_HEALTH);
    //    audioManager.purchaseHappend = true;
    //    GetMoreLives.userBoughtItem = true;
    //    Debug.Log("Player Health after: " + PlayerPrefs.GetInt("playerHealth"));
    //}

    //public void BuyNoAds()
    //{
    //    BuyProductID(PRODUCT_NOADS);
    //    ShopAudioManager.buy_sound = true;

    //}


    //private void BuyProductID(string productId)
    //{
    //    // If Purchasing has been initialized ...
    //    if (IsInitialized())
    //    {
    //        // ... look up the Product reference with the general product identifier and the Purchasing 
    //        // system's products collection.
    //        Product product = m_StoreController.products.WithID(productId);

    //        // If the look up found a product for this device's store and that product is ready to be sold ... 
    //        if (product != null && product.availableToPurchase)
    //        {
    //            Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
    //            // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
    //            // asynchronously.
    //            m_StoreController.InitiatePurchase(product);
    //        }
    //        // Otherwise ...
    //        else
    //        {
    //            // ... report the product look-up failure situation  
    //            Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
    //        }
    //    }
    //    // Otherwise ...
    //    else
    //    {
    //        // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
    //        // retrying initiailization.
    //        Debug.Log("BuyProductID FAIL. Not initialized.");
    //    }
    //}

    //public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    //{
    //    // Purchasing has succeeded initializing. Collect our Purchasing references.
    //    Debug.Log("OnInitialized: PASS");

    //    // Overall Purchasing system, configured with products for this application.
    //    m_StoreController = controller;
    //    // Store specific subsystem, for accessing device-specific store features.
    //    m_StoreExtensionProvider = extensions;
    //}

    //public void OnInitializeFailed(InitializationFailureReason error)
    //{
    //    // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
    //    Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    //}


    //public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    //{
    //    if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_5000_RED_EMERALD, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        ManagerForShop.Instance.emeraldRed += 5000;
    //        ManagerForShop.Instance.Save();
    //    }
    //    else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1000_GREEN_EMERALD, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        ManagerForShop.Instance.emeraldGreen += 1000;
    //        ManagerForShop.Instance.Save();
    //    }
    //    else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1000_BLUE_EMERALD, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        ManagerForShop.Instance.emeraldBlue += 1000;
    //        ManagerForShop.Instance.Save();
    //    }
    //    else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1000_PURPLE_EMERALD, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        ManagerForShop.Instance.emeraldPurple += 1000;
    //        ManagerForShop.Instance.Save();
    //    }
    //    else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1000_GOLDEN_EMERALD, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        ManagerForShop.Instance.emeraldGold += 1000;
    //        ManagerForShop.Instance.Save();
    //    }
    //    else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_99999_COINS, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        WeaponShop.Instance.coins += 99999;
    //        WeaponShop.Instance.Save();
    //    }
    //    else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_50_HEALTH, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        PlayerPrefs.SetInt("playerHealth", PlayerPrefs.GetInt("playerHealth", 0) + 50);
    //        if(!UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Contains("Level"))
    //            PurchaseShopLiveCount.text = PlayerPrefs.GetInt("playerHealth", 0).ToString();

    //    }
    //    else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_10_HEALTH, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        PlayerPrefs.SetInt("playerHealth", PlayerPrefs.GetInt("playerHealth", 0) + 10);
    //        PlayerPrefs.Save();
    //    }
    //    else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_4_HEALTH, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        PlayerPrefs.SetInt("playerHealth", PlayerPrefs.GetInt("playerHealth", 0) + 4);
    //        PlayerPrefs.Save();

    //    }
    //    else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_NOADS, StringComparison.Ordinal))
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
    //        Instance.BoughtNO_ADS = 1;
    //        Instance.Save();
    //        Debug.Log("No Ads for you my friend!");

    //    }
    //    else
    //    {
    //        Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
    //    }

    //    return PurchaseProcessingResult.Complete;
    //}


    //public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    //{
    //    // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
    //    // this reason with the user to guide their troubleshooting actions.
    //    Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    //}
}