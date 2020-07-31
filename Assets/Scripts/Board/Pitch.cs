using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.Jobs;

public class Pitch : MonoBehaviour
{

    public Player footballer;
    public Hex hexPrefab;

    static int gridWidth = 15; //11
    static int gridHeight = 21; //15

    float hexWidth = 4.9f;
    float hexHeight = 4.7f;

    public float offsetGap;
    Vector3 startPos;

    public Hex[,] board = new Hex[gridHeight, gridWidth];
    Player[] activePoistions = new Player[5];
    Vector3 yPos = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        AddGap();
        CalcStartPos();
        gridCreation();
        createTeams();
    }


    public Hex[,] GetBoard()
    {
        return this.board;
    }



    void AddGap()
    {
        hexWidth += hexWidth * offsetGap;
        hexHeight += hexHeight * offsetGap;
    }

    void CalcStartPos()
    {
        float offset = 0;
        if (gridHeight / 2 % 2 != 0)
            offset = hexHeight / 2;

        float x = -hexWidth * (gridWidth/ 2) - offset;
        float z = hexHeight * 0.75f * (gridWidth / 2);

        startPos = new Vector3(x, 0, z);
    }

    Vector3 CalcWorldPos(Vector3 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.y * hexHeight + 0.75f;

        return new Vector3(x, 0, z);
    }

    void gridCreation()
    {
        for(int x = 0; x < gridHeight; x++)
        {
            for( int y = 0; y < gridWidth; y++)
            {
                Hex hex;
                
                Vector3 position;
                Vector2 gridPos = new Vector2(x, y);
                position = CalcWorldPos(gridPos);
                hex = Instantiate(hexPrefab, position, Quaternion.Euler(-90,0,180));
                hex.SetHexPosition(position);
                hex.SetIDX(x);
                hex.SetIDY(y);
                this.board[x, y] = hex;
            }
        }
        
    }

    /*
     * d1 17|5
     * d2 17|9
     * s1 13|3
     * s2 13|11
     * MM 12|7
     * 
     * 
     */


    void createTeams()
    {
        createPlayHex(board[17,5], Selections.Defender, 0, "player1");
        createPlayHex(board[17,9], Selections.Defender, 1, "player2");
        createPlayHex(board[13,3], Selections.Striker, 2, "player3");
        createPlayHex(board[13,11], Selections.Striker, 3, "player4");
        createPlayHex(board[12, 7], Selections.Midfielder, 4, "player5");
    }


    void createPlayHex(Hex position, Selections type, int activePosition, string name)
    {
        Player player;
        player = Instantiate(footballer, position.transform.position + yPos, Quaternion.Euler(-90, 0, 180));
        player.SetCurrentPosition(position);
        player.SetPosition(position.transform);
        player.SetType(type);
        player.Name = name;
        activePoistions[activePosition] = player;
    }

  

    //takes setactivegrid() and iterates through it t number of times. t = no of active positions 
    void highlightHex1()
    {
        foreach (Player t in activePoistions)
        {
            highlightHex2(t);
        }
    }


    void highlightHex2(Player t)
    {
        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                if ((board[i, j]).Equals(t.GetComponent<Player>().GetCurrentPosition()))
                {
                    board[i, j].GetComponent<Hex>().SetHexType(HexType.active);
                    highlightNeighbors(board[i,j], i, j);
                }

                if(i == 0 || j == 0 || i == 20 || j == 14)
                {
                    board[i, j].GetComponent<Hex>().SetHexType(HexType.nonplayable);
                }
            }
        }
    }

    void highlightNeighbors(Hex hex, int i, int j)
    {
        hex.GetComponent<Hex>().SetNeighbors(hex, i, j, board);
    }
     



    private void Update()
    {
        highlightHex1();
        
    }

}
