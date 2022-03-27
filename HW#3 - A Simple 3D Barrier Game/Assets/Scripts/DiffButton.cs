using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This button opens the difficulty level adjustment menu, press it again to close it.
public class DiffButton : MonoBehaviour
{

    public GameObject toggle;
    
    public void EnableYap()
    {
        if (toggle.activeInHierarchy == true)
            toggle.SetActive(false);
        else
            toggle.SetActive(true);

        

    }
}
