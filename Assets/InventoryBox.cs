using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBox : MonoBehaviour
{
    public int id;
    public int count;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "0";
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        count = inventoryManager.inventory[id];
        text.text = count.ToString();
    }
}
