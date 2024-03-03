using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int[] inventory = new int[12];
    public int debt;
    void Start()
    {
        debt = 1500;
    }
    public void AddItem(int type) {
        ++inventory[type];
    }
    public void RemoveItem(int type) {
        --inventory[type];
    }
}
