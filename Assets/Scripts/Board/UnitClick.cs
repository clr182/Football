using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitClick : MonoBehaviour
{
    Transform trans;
    Selections selections;
    public Camera cam;

    //public Material[] material;
    //private Renderer rend;
    //bool FirstMaterial = true;
    //bool SecondMaterial = false;



    private void OnMouseDown()
    {
        switch (selections) 
        {
            case Selections.Defender:
                //Debug.Log(gameObject.GetComponent<Hex>().GetType());
                
                //if (FirstMaterial)
                //{
                //    rend.sharedMaterial = material[1];
                //    SecondMaterial = true;
                //    FirstMaterial = false;
                //}
                //
                //else if (SecondMaterial)
                //{
                //    rend.sharedMaterial = material[0];
                //    SecondMaterial = false;
                //    FirstMaterial = true;
                //}
                break;

            case Selections.Striker:
                break;

            case Selections.Midfielder:
                break;

            default:
                
                break;
        }


        //getObjectClicked(gameObject);
    }


    private void OnMouseOver()
    {


    }




    private void Start()
    {
        //selections = Selections.Defender;
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //rend.sharedMaterial = material[0];
    }   //


    


    private void Update()
    {
        GameObject hitPlayer;
        GameObject hitHex;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if(Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.GetComponent<Player>())
                {
                    //selectType = hit.transform.gameObject.GetComponent<Player>().GetType();
                    hitPlayer = hit.transform.gameObject;

                }
                else if (hit.transform.gameObject.GetComponent<Hex>())
                {
                    hitHex = hit.transform.gameObject;
                }


            }


        }

        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log(gameObject.GetComponent<Player>().GetStillActive());
        }
    }
}


//maybe use this later as a power up or something
//Destroy(this.gameObject);