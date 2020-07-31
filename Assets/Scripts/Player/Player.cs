using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int actionPoints;
    Hex currentPosition;
    Transform position;
    bool stillActive;
    Material color;
    string name;
    int boardPosI;
    int boardPosJ;
    Selections type;

    #region GETSET
    public int GetActionPoints()
    {
        return this.actionPoints;
    }

    public void SetActionPoints(int ap)
    {
        this.actionPoints = ap;
    }

    public Material GetColor()
    {
        return this.color;
    }

    public void SetColor(Material c)
    {
        this.color = c;
    }

    public string Name { get; set; } = "default";

    public Selections GetType()
    {
        return this.type;
    }

    public void SetType(Selections type)
    {
        this.type = type;
    }

    public Hex GetCurrentPosition()
    {
        return this.currentPosition;
    }

    public void SetCurrentPosition(Hex cp)
    {
        this.currentPosition = cp;
    }

    public bool GetStillActive()
    {
        return this.stillActive;
    }

    public void SetStillActive(bool b)
    {
        this.stillActive = b;
    }

    public Transform GetTransform()
    {
        return this.position;
    }

    public void SetPosition(Transform p)
    {
        this.position = p;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        this.actionPoints = 3;
        this.stillActive = false;
    }

    void movePlayer(Hex hex)
    {
        this.currentPosition = hex;
    }

}
