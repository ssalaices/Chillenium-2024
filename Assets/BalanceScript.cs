using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceScript : MonoBehaviour
{
    public int balance;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Balance: $0";
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        balance = inventoryManager.balance;
        text.text = "Balance: $" + balance.ToString();
    }
}
