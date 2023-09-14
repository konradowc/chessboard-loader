using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    // singleton reference
    public static Events events = null;

    private void Awake()
    {
        if (events == null)
            events = this;
        else
            Debug.Log("Events singleton instance error");
    }

    /*
     * Game logic events
     */

    // completely new board has been set
    public event Action onNewBoard;
    public void NewBoard()
    {
        if(onNewBoard != null) onNewBoard();
    }

    // a single move has been made
    public event Action onMove;
    public void Move()
    {
        if(onMove!= null) onMove();
    }

    /*
     * Visual board events
     */

    public event Action onPieceSelect;
    public int pieceX;
    public int pieceY;
    public void PieceSelect(int x, int y)
    {
        if (onTileSelect != null)
        {
            pieceX = x;
            pieceY = y;
            onPieceSelect();
        }
    }

    public event Action onTileSelect;
    public int tileX;
    public int tileY;
    public void TileSelect(int x, int y)
    {
        if (onTileSelect != null)
        {
            tileX = x;
            tileY = y;
            onTileSelect();
        }
    }

    public event Action onFinalTileSelect;
    public int finalTileX;
    public int finalTileY;
    public void FinalTileSelect(int x, int y)
    {
        if (onFinalTileSelect != null)
        {
            finalTileX = x;
            finalTileY = y;
            onFinalTileSelect();
        }
    }
}
