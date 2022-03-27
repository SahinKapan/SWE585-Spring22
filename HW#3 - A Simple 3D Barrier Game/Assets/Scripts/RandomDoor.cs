using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomDoor : MonoBehaviour
{
    public Vector3 endPos;
    private float speed;
    private bool moving = true;
    private bool opening = true;
    private Vector3 startPos;
    private float delay = 0.0f;

    public GameObject DifficultyToggles;

    void Start()
    {
        DifficultyToggles.transform.GetChild((int)GameValues.Difficulty).GetComponent<Toggle>().isOn = true;
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        //Door speed is changing according to difficulty.
        switch (GameValues.Difficulty)
        {
            case GameValues.Difficulties.Easy:
                speed = 1.0f;
                break;
            case GameValues.Difficulties.Medium:
                speed = 3.0f;
                break;
            case GameValues.Difficulties.Hard:
                speed = 5.0f;
                break;
        }
        print("Hız:" + speed);

        if (opening)
            {
                StartCoroutine(MoveObject(endPos));
            }
            else
            {
                StartCoroutine(MoveObject(startPos));
            }
    }

    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }

    //Door movement function
    IEnumerator MoveObject(Vector3 goalPos)
    {
        float dist = Vector3.Distance(transform.position, goalPos);
        
        if (dist > .1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        }
        else
        {
            if (opening)
            {
                float waitForMove = NextFloat(0.0f, 20.0f);
                delay += Time.deltaTime;
                if (delay > waitForMove)
                {
                    opening = false;
                }
            }
            else
            {
                moving = false;
                opening = true;
            }
        }
        yield return new WaitForFixedUpdate();
    }

    //Random door closing and opening
    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    //It is for difficulty
    #region Difficulty
    public void SetEasyDifficulty()
    {
        GameValues.Difficulty = GameValues.Difficulties.Easy;
    }
    public void SetMediumDifficulty()
    {
        GameValues.Difficulty = GameValues.Difficulties.Medium;
    }
    public void SetHardDifficulty()
    {
        GameValues.Difficulty = GameValues.Difficulties.Hard;
    }
    #endregion

}
