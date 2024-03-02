using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Controller : MonoBehaviour
{
   public int type;
   public void OnTriggerEnter2D(Collider2D other) {
      Destroy(gameObject);
      InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
      inventoryManager.AddItem(type);
   }
}