using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private void Start()
    {
        // assuming Queens game
        transform.position = new Vector3(QueensGameLogic.SIZE_X * BoardVisualScript.TILE_SIZE / 2.0f - 0.5f, 
            QueensGameLogic.SIZE_Y * BoardVisualScript.TILE_SIZE / 2.0f - 0.5f, -10);
    }
}
