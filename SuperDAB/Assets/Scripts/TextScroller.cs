using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScroller : MonoBehaviour
{
    public float normalScrollSpeed = 100;
    public float fastScrollSpeed = 100;
    public float currentScrollSpeed = 1000;

    public float endpoint;

    private void Start()
    {
        currentScrollSpeed = normalScrollSpeed;
    }

    private void Update()
    {
        Vector3 tempPos = GetComponent<RectTransform>().localPosition;
        tempPos.y += currentScrollSpeed * Time.deltaTime;
        GetComponent<RectTransform>().localPosition = tempPos;

        if(Input.GetButton("Jump"))
        {
            currentScrollSpeed = fastScrollSpeed;
        }
        else
        {
            currentScrollSpeed = normalScrollSpeed;
        }

        if(GetComponent<RectTransform>().localPosition.y >= endpoint ) 
        {
            FindObjectOfType<UI_Manager>().enabled = true;
        }
    }
}
