using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ShopFunction : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite shop;
    [SerializeField] Sprite shopEmpty;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.sprite = shopEmpty;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.sprite = shopEmpty;
    }

}
