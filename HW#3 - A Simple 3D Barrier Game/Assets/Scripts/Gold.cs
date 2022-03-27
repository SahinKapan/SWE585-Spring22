using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    //When the bottom is reached
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cube")
        {
            CoinText.coinAmount += 1;
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("GoldPick");
        }
    }
}
