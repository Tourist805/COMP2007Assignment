using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public static int EggCount = 0;

    private void Start()
    {
        ++Egg.EggCount;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Entered collider");
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        --Egg.EggCount;

        if(Egg.EggCount <= 0)
        {
            Debug.Log("You win");
        }
    }
}
