using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sell : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public Text soldFor;
    public Text debt;
    public Text quote;
    void Start() {
        Button button = GetComponent<Button>();
    }
    // Update is called once per frame
    void Update() {
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager.inventory[id] == 0) return;
        inventoryManager.RemoveItem(id);
        int price = Random.Range(50, 101);
        soldFor.text = "This object was sold for $" + price.ToString();
        inventoryManager.debt -= price;
        debt.text = "You need to sell $" + inventoryManager.debt.ToString() + " to pay off your debt!";
        switch (id) {
            case 0:
                quote.text = "Wow, a business suit! Those were outlawed ages ago because the government got sick of business majors renting out too many bars for night parties.";
                break;
            case 1:
                quote.text = "A wedge of cheese? Incredible! The president banned all cheese production because it smelled bad, so this is a relic!";
                break;
            case 2:
                quote.text = "Ooooh, look at this coffee pot! We got rid of those because some president from 200 years ago or something spilled coffee on his pants before a huge speech. Good find!";
                break;
            case 3:
                quote.text = "Yee haw, nice cowboy hat! Unfortunately, you can't find them much anymore because 400 years ago, all of these were swapped out in favor of cat ears. I mean, both are cool though.";
                break;
            case 4:
                quote.text = "A rubber ducky! Banned because people found them too annoying. I will be sure not to take this for granted.";
                break;
            case 5:
                quote.text = "Man, how 2016 of you. What a nice fidget spinner! These were banned because high school teachers worldwide got sick of them.";
                break;
            case 6:
                quote.text = "Woah, is that a real fish? These bad boys are mostly extinct due to massive fish demand in the economy and subsequent overfishing, but I guess they're still somewhere down there!";
                break;
            case 7:
                quote.text = "The ice cube that never melts! This should truly be a national treasure.";
                break;
            case 8:
                quote.text = "A literal cat. Those were replaced by robo kitties up there, so I'd call this a very nice find!";
                break;
            case 9:
                quote.text = "Didn't think I'd ever see a pine cone again! Unfortunately, O'Hare Air cut down every last pine tree to make more profit off of air.";
                break;
            case 10:
                quote.text = "A trumpet! What a classic, banned because the government hates freedom of expression. Truly a lick most devious!";
                break;
            case 11:
                quote.text = "Hah, a whoopie cushion. These were removed from society because girls don't fart.";
                break;
            default:
                break;
        }
    }
}