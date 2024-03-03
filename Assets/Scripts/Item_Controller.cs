using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Item_Controller : MonoBehaviour
{
   public Tilemap mudtiles;
   public int type;
   public void OnTriggerEnter2D(Collider2D other) {
        if (mudtiles.GetTile(Vector3Int.FloorToInt(gameObject.transform.position)) == null)
        {
            Destroy(gameObject);
            InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
            inventoryManager.AddItem(type);
        }
   }
}