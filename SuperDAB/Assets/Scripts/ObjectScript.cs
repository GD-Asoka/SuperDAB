using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    private bool levitate = false;
    public float levitateLimit = 5;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            levitate = !levitate;
            MoveObject();
        }
    }

    private void MoveObject()
    {
        if(levitate)
        {
            Vector3 newPos = new Vector3(0, levitateLimit, 0);
            transform.position += newPos;
        }
        else
        {
            Vector3 newPos = new Vector3(0, -levitateLimit, 0);
            transform.position += newPos;
        }
    }
}
