using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public GameObject restartButton;
  
    private void FixedUpdate()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += Movement * speed * Time.deltaTime;
    }

    //What happens if the red cube hits the doors:
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Door")
        {
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            CoinText.text2.text = "You lost";
            Time.timeScale = 0;
            restartButton.SetActive(true);
            CoinText.coinAmount = 0;
        }
        

    }

    

}
