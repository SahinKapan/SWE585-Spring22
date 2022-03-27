using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//We win when we get back to the starting point
public class YouWin : MonoBehaviour
{

    public GameObject restartButton;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cube" && CoinText.coinAmount == 1)
        {
            CoinText.text2.text = "You win";
            Time.timeScale = 0;
            restartButton.SetActive(true);
            CoinText.coinAmount = 0;
        }
    }

    
}
