using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManager : MonoBehaviour
{
    
    private bool isSlide;
    private Camera cam; 
    public LayerMask mask;
    [SerializeField] private float sensitivity; 
    private float firstPositionX;
    public Vector3 minX = new Vector3(-2.71f, 0f, 0f);
    public Vector3 maxX = new Vector3(2.73f, 0f, 0f);

    private void Start()
    {
        cam=Camera.main;
    }
    /*
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z= 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position,mousePos-transform.position,Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,100,mask))
            {
                Vector3 firstPosition = hit.point;

            }
        }
    }
    */

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnFingerDown();
            isSlide = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            OnFingerUp();
            isSlide = false;
        }

        if (isSlide)
        {
            OnFinger();
        }
    }

    private void OnFingerDown()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,100,mask))
        {
            firstPositionX = hit.point.x;
        }
    }
    
    private void OnFingerUp()
    {
        Debug.Log("onfingerup");
    }

    private void OnFinger()
    {
        Ray ray2 = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;
        if (Physics.Raycast(ray2, out hit2, 100, mask))
        {
            var currentPosX = hit2.point.x;

            var deltaX = currentPosX - firstPositionX;
            //b.SetMinMax(minX,maxX);
            

            Platform.instance.SetPos(deltaX * sensitivity);
            firstPositionX = currentPosX;
        }
    }
}
