using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardVisualScript : MonoBehaviour
{
    // singleton reference
    public static BoardVisualScript visualBoard = null;

    [SerializeField] public const float TILE_SIZE = 1;

    [SerializeField] private TileScript tile;

    [SerializeField] private GameObject WpawnSprite;
    [SerializeField] private GameObject WknightSprite;
    [SerializeField] private GameObject WbishopSprite;
    [SerializeField] private GameObject WrookSprite;
    [SerializeField] private GameObject WqueenSprite;
    [SerializeField] private GameObject WkingSprite;

    [SerializeField] private GameObject BpawnSprite;
    [SerializeField] private GameObject BknightSprite;
    [SerializeField] private GameObject BbishopSprite;
    [SerializeField] private GameObject BrookSprite;
    [SerializeField] private GameObject BqueenSprite;
    [SerializeField] private GameObject BkingSprite;

    [SerializeField] private GameObject[] allPieces;
    [SerializeField] private int[] allPiecesLocations; // input: tile position; output: allPieces index of piece

    private void Awake()
    {
        if (visualBoard == null)
            visualBoard = this;
        else
            Debug.Log("Events singleton instance error");
    }

    private void Start()
    {
        // subscribe to board logic events
        Events.events.onNewBoard += SetUpVisualPieces;
        //Events.events.onMove += something;

        SetUpVisualBoard();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            QueensGameLogic.game.SetBoardFEN("rnbqkbnr/ppppPppp/8/8/8/8/PPPPPPPP/RNBQKBNR");
            SetUpVisualPieces();
        }
    }

    private void SetUpVisualBoard()
    {
        for (int i = 0; i < QueensGameLogic.SIZE_X; i++)
        {
            for (int j = 0; j < QueensGameLogic.SIZE_Y; j++)
            {
                // init tile
                TileScript newTile = Instantiate(tile, new Vector3(i * TILE_SIZE, j * TILE_SIZE, 0), transform.rotation);
                newTile.name = "Tile (" + i + ", " + j + ")";

                newTile.SetTileInfo(i, j);
            }
        }
    }

    private void SetUpVisualPieces()
    {
        char[] board = QueensGameLogic.game.GetBoard();

        allPieces = new GameObject[board.Length];
        allPiecesLocations = new int[QueensGameLogic.SIZE_X * QueensGameLogic.SIZE_Y];

        for(int i = 0; i < board.Length; i++)
        {
            int x = (i % 8);
            int y = (i / 8);

            GameObject toInstantiate = null;

            if (board[i] == 'P') toInstantiate = WpawnSprite;
            else if (board[i] == 'p') toInstantiate = BpawnSprite;
            else if (board[i] == 'B') toInstantiate = WbishopSprite;
            else if (board[i] == 'b') toInstantiate = BbishopSprite;
            else if (board[i] == 'N') toInstantiate = WknightSprite;
            else if (board[i] == 'n') toInstantiate = BknightSprite;
            else if (board[i] == 'R') toInstantiate = WrookSprite;
            else if (board[i] == 'r') toInstantiate = BrookSprite;
            else if (board[i] == 'Q') toInstantiate = WqueenSprite;
            else if (board[i] == 'q') toInstantiate = BqueenSprite;
            else if (board[i] == 'K') toInstantiate = WkingSprite;
            else if (board[i] == 'k') toInstantiate = BkingSprite;


            if (toInstantiate != null)
            {
                GameObject pieceInstance = Instantiate(toInstantiate, new Vector3(x * TILE_SIZE, y * TILE_SIZE, -0.1f), transform.rotation); // move it
                pieceInstance.transform.localScale = new Vector3(0.14f, 0.14f, 1); // shrink it

                // add it to arrays
                allPieces[i] = pieceInstance;
                allPiecesLocations[x + y * QueensGameLogic.SIZE_X] = i;
            }
            else if (board[i] != '-')
                Debug.Log("ERROR: Rendering error: (pos " + i + ") " + board[i]);
        }

        Debug.Log("NOTE: Setup visual pieces");
    }

    public void TileSelect(int x, int y)
    {
        int[] moves = QueensGameLogic.game.TileSelect(x + y * QueensGameLogic.SIZE_X);

        int index = allPiecesLocations[x + y * QueensGameLogic.SIZE_X];

        if (allPieces[index] != null)
        {

            //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        
    }
}
