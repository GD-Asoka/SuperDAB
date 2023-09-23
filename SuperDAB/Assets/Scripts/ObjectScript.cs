using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public bool levitate = false;
    public bool xAxisObject = true;
    public float levitateLimit = 5;
    public PlayerController player;

    private void Start()
    {
       GetComponent<MeshRenderer>().enabled = false;
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    levitate = !levitate;
        //    MoveObject();
        //}
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LineOfSight"))
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LineOfSight"))
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
