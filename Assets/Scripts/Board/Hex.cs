using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    // Start is called before the first frame update
    int idX;
    int idY;
    bool active;
    Vector3 hexPosition;

    HexType hexType;
    Renderer rend;
    public Material[] material;
    [SerializeField] Hex[] neighbors;

    #region GETSET

    public int GetIDX()
    {
        return this.idX;
    }

    public void SetIDX(int id)
    {
        this.idX = id;
    }

    public int GetIDY()
    {
        return this.idY;
    }

    public void SetIDY(int id)
    {
        this.idY = id;
    }

    public void SetActive(bool x)
    {
        active = x;
    }

    public bool GetActive()
    {
        return this.active;
    }

    public HexType GetHexType()
    {
        return this.hexType;
    }
    
    public void SetHexType(HexType type)
    {
        this.hexType = type;
    }
    public Vector3 GetHexPosition()
    {
        return this.hexPosition;
    }

    public void SetHexPosition(Vector3 hexPosition)
    {
        this.hexPosition = hexPosition;
    }
    #endregion

    
  

    /* active: 5|5
     * 
     * NorEas: 6|4 - 
     * right:  5|5 -
     * Sou/Eas:6|6 -
     * 
     * SouW/We:5|6 -
     * Left:   4|5 -
     * nor/Wes:5|4
     * 
     * min = 0
     * max on the x = 14
     * max on the y = 10
     */


    


    public void SetNeighbors(Hex hex, int i, int j, Hex[,] board)
    {
        
        this.neighbors[0] = board[i + 1, j - 1];
        this.neighbors[1] = board[i + 1, j];
        this.neighbors[2] = board[i + 1, j + 1];
        this.neighbors[3] = board[i, j + 1];
        this.neighbors[4] = board[i - 1, j ];
        this.neighbors[5] = board[i , j -1];

        foreach(Hex n in neighbors)
        {
            n.SetHexType(HexType.neighbor);
        }
    }








    // Update is called once per frame
    void Start()
    {
        this.rend = GetComponent<Renderer>();
        this.rend.enabled = true;
        this.rend.sharedMaterial = material[0];
        this.active = false;
        this.neighbors = new Hex[6];
    }

    private void Update()
    {
        switch (hexType) {
            case HexType.nonplayable:
                this.rend.sharedMaterial = material[0];
                break;
            case HexType.playable:
                this.rend.sharedMaterial = material[1];
                break;
            case HexType.active:
                this.rend.sharedMaterial = material[2];
                break;
            case HexType.neighbor:
                this.rend.sharedMaterial = material[3];
                break;
        }



        //if (this.active == true)
        //{
        //    this.rend.sharedMaterial = material[1];
        //}
        //else
        //{
        //    this.rend.sharedMaterial = material[0];
        //}
    }
}
