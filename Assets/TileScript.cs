using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] private Color lightColor, darkColor;

    [SerializeField] private SpriteRenderer render;

    private int xPos;
    private int yPos;

    public void SetTileInfo(int x, int y)
    {
        xPos = x;
        yPos = y;

        if ((x + y) % 2 == 0)
            render.color = lightColor;
        else
            render.color = darkColor;
    }

    private void OnMouseDown()
    {
        //Events.events.TileSelect(xPos, yPos); // broadcast event w/ parameters
        BoardVisualScript.visualBoard.TileSelect(xPos, yPos);
    }

    private void OnMouseUp()
    {
        Events.events.FinalTileSelect(xPos, yPos); // broadcast event w/ parameters
    }
}
