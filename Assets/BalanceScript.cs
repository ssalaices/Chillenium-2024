using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceScript : MonoBehaviour
{
    public int debt;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Debt: $0";
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        debt = inventoryManager.debt;
        text.text = "Debt: $" + debt.ToString();
    }
}
