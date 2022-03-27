using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The number of gold won and the text of winning, losing
public class CoinText : MonoBehaviour
{
    
    public static Text text;
    public static Text text2;
    public static int coinAmount = 0;

    void Start()
    {
        text = GetComponent<Text>();
        text2 = GameObject.FindGameObjectWithTag("Youwintext").GetComponent<Text>();
    }


    void Update()
    {
        text.text = coinAmount.ToString(); 
    }
}
