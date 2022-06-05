using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDoors : MonoBehaviour
{
    public Vector3 endPos;
    private float speed;
    private bool moving = true;
    private bool opening = true;
    private Vector3 startPos;
    private float delay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        speed = 3.0f;

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

    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

   
    
}
