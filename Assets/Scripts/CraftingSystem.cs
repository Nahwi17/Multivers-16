//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CraftingSystem : MonoBehaviour
//{
//    public GameObject craftingScreenUI;
//    public GameObject toolsScreenUI;
//    // public GameObject inventory;

//    public List<string> inventoryItemList = new List<string>();

//    //category button
//    Button toolsBTN;

//    //Craft button
//    Button craftPotionBTN;

//    //Requirement Text 
//    Text PotionReq1, PotionReq2;

//    public bool isOpen;

//    //All blueprint


//    public static CraftingSystem Instance {get; set;}

//    private void Awake() 
//    {

//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        isOpen = false;

//        toolsBTN = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button>();
//        toolsBTN.onClick.AddListener(delegate{OpenToolsCategory();});

//        //potion
//        //PotionReq1 = toolsScreenUI.transform.Find("Potion").transform.Find("req1").GetComponent<Text>();
//        //PotionReq2 = toolsScreenUI.transform.Find("Potion").transform.Find("req2").GetComponent<Text>();

//        craftPotionBTN = toolsScreenUI.transform.Find("Potion").transform.Find("Button").GetComponent<Button>();
//        craftPotionBTN.onClick.AddListener(delegate{CraftAnyItem();});
       

//    }

//    void OpenToolsCategory()
//    {
//        craftingScreenUI.SetActive(false);
//        toolsScreenUI.SetActive(true);
//    }

//    //void CraftAnyItem()
//    //{
//    //    //add item into inventory
        
//    //    InventoryUIManager.Instance.AddToInventory();

//    //    InventoryUIManager.Instance.RemoveItem();

//    //    InventoryUIManager.Instance.ReCalculeList();

//    //    RefreshNeededItems();
        

//    //}
//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
//        {
//            Debug.Log("i is pressed");
//            craftingScreenUI.SetActive(true);
//            Cursor.lockState = CursorLockMode.None;
//            isOpen = true;
//        }
//        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
//        {
//            craftingScreenUI.SetActive(false);
//            toolsScreenUI.SetActive(false);
            
//            // if (!inventory.Instance.isOpen)
//            // {
//               Cursor.lockState = CursorLockMode.Locked; 
//            // }
            
//            isOpen = false;
//        }
//    }
//}
