using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int[] inventory = new int[12];
    public void AddItem(int type)
    {
        ++inventory[type];
    }
}
