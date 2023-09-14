using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class QueensGameLogic : MonoBehaviour
{
    // singleton reference
    public static QueensGameLogic game = null;

    [SerializeField] public const int SIZE_X = 8;
    [SerializeField] public const int SIZE_Y = 8;

    [SerializeField] private char[] board;

    /*
     * Board setup:
     * '-': empty
     * 
     * 'P': white pawn
     * 'p': black pawn
     * 
     * 'B': white bishop
     * 'b': black bishop
     * 
     * 'N': white knight
     * 'n': black knight
     * 
     * 'R': white rook
     * 'r': black rook
     * 
     * 'Q': white queen
     * 'q': black queen
     * 
     * 'K': white king
     * 'k': black king
     * 
     */

    //public void inputMove()

    public char[] GetBoard() { return board; }

    private void Awake()
    {
        if (game == null)
            game = this;
        else
            Debug.Log("Events singleton instance error");
    }

    private void Start()
    {
        SetUpBoard();
    }

    private void SetUpBoard()
    {
        board = new char[SIZE_X * SIZE_Y];
        SetBoardFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");
        //SetBoardFEN("pppppppp/pppppppp/pppppppp/pppppppp/pppppppp/pppppppp/pppppppp/pppppppp");
    }

    // TODO: add complete FEN string parsing
    // TODO: boardPos starting value depending on SIZE_X and SIZE_Y
    public void SetBoardFEN(string FENstring)
    {
        int boardPos = 56; // start on back rank

        foreach(char c in FENstring)
        {
            // if space 1-8
            if(char.IsDigit(c))
            {
                int digit = c - '0'; // find the integer value

                for(int i = 0; i < digit; i++)
                {
                    board[boardPos] = '-';
                    boardPos++;
                }
            }
            
            // if a piece
            else if(char.IsLetter(c))
            {
                board[boardPos] = c;
                boardPos++;
            }

            // if next rank
            else if(c == '/')
            {
                boardPos -= 16; // go back one rank and go to beginning of that rank
            }

            else { Debug.Log("FEN Error (probably has a space)");  }
        }

        // call the event onNewBoard
        Events.events.NewBoard();

        /*
        for(int i = 0; i < board.Length; i++)
        {
            Debug.Log(i + " " + board[i]);
        }
        */
    }

    public int[] TileSelect(int pos)
    {
        int[] moves = { };


        return moves;
    }
}
