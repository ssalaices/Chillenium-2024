using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{

    [SerializeField] AICombat combatScript;
    [SerializeField] AIWander wanderScript;
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] private int zombieCount = 5;

    // Start is called before the first frame update
    void Start()
    {

        zombiePrefab.AddComponent<AICombat>();
        zombiePrefab.AddComponent<AIWander>();

        combatScript.maxHealth = 100;

        for(int i = 0; i < zombieCount; i++)
        {
            Instantiate(zombiePrefab);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
