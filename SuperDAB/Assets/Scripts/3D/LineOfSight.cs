using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Object"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            print("visible");
        }
        print("enter");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            print("invisible");
        }
        print("exit");
    }
}
