using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int[] inventory = new int[12];
    public int balance = 0;
    public void AddItem(int type)
    {
        ++inventory[type];
    }
    public void SellItem(int type, int count) {
        if (count <= inventory[type]) {
            for (int i = 0; i < count; ++i) {
                balance += Random.Range(50, 101);
            }
        } else Debug.Log("Tried to sold more than he had");
    }
}
