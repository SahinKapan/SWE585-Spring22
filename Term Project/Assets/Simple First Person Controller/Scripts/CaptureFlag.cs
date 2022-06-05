using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureFlag : MonoBehaviour
{
	private GameObject Flag;
	private GameObject Home;
	private string Text1 = "Capture the flag!";
	//private string Text2 = "";
	//private string Text3 = "";
	private float initialLocationX;
	private float initialLocationZ;
	private bool FlagTaken = false;
	
	void Awake()
    {
        Home = GameObject.FindWithTag("FlagHome");
        Flag = GameObject.FindWithTag("Flag");
    }
	
    // Start is called before the first frame update
    void Start()
    {
        initialLocationZ = gameObject.transform.position.z;
		initialLocationX = gameObject.transform.position.x;
		Home.transform.position = new Vector3(initialLocationX, 5, initialLocationZ);
    }

    // Update is called once per frame
    void Update()
    {
		//Text2 = "PositionX: " + gameObject.transform.position.x;
		//Text3 = "PositionZ: " + gameObject.transform.position.z;
		if (FlagTaken == false)
		{
			if (3 < gameObject.transform.position.z && 5 > gameObject.transform.position.z ){
				FlagTaken = true;
				Flag.SetActive(false);
				Text1 = "Go back to home!";
			}
		}
		
		if (FlagTaken == true)
		{
			if ((initialLocationX - 1) < gameObject.transform.position.x && gameObject.transform.position.x < (1 + initialLocationX)){
				if ((initialLocationZ - 1) < gameObject.transform.position.z && gameObject.transform.position.z < (1 + initialLocationZ)){
					Text1 = "You win!";
					Time.timeScale = 0;
				}
			}
		}
    }
	
	void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 24;
        GUI.Label(new Rect(200, 50, 200, 150), Text1, fontSize);
		//GUI.Label(new Rect(200, 100, 250, 150), Text2, fontSize);
		//GUI.Label(new Rect(200, 120, 250, 150), Text3, fontSize);
		
    }
}
