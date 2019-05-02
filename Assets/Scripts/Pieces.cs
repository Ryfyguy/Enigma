﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    public int column; // we need to the the position of the new gameobject board everytime we swap blocks.
    public int row;
    public int targetX;
    public bool isMatched = false;
    public int targetY;
    private Board board;
    private GameObject otherDot;
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;
    public float swipeAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        row = targetY;
        column = targetX;
    }

    // Update is called once per frame
    void Update() //checks for match, and if they are matched then they change the color to a darker color. 
    {
        FindMatches();
        if (isMatched)
        {
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = new Color(1f, 1f, 1f, .2f);

        }
        targetX = column;
        targetY = row;
        if(Mathf.Abs(targetX - transform.position.x) > .1)
        {
            //Move towards the target block
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);

        }
        else
        {
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = tempPosition;
            board.allDots[column, row] = this.gameObject;
        }
        if (Mathf.Abs(targetY - transform.position.y) > .1)
        {
            //Move towards the target block
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);

        }
        else
        {
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;
            board.allDots[column, row] = this.gameObject;
        }
    }

    private void OnMouseDown()
    {//gets the position of the mouse click when uer first clicks it. 
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets position of the first click
        //Debug.Log(firstTouchPosition);
    }

    private void OnMouseUp()
    {// gets the position when the user lets go of the mouse click. 
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //camrea.main gets the position of the world coordinate not the entire monitor screen coordinate. 
        CalculateAngle();
    }
    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180/Mathf.PI; //changes the radian found to angles, and we are basically doing pythagorean theorm here. 
        //Debug.Log(swipeAngle);
        MovePieces();
    }
    void MovePieces()// moves based on player clicks, will account for the angle that the user swipes and not just straight 90 degree or 270 degrees. 
    {
        if(swipeAngle> -45 && swipeAngle <= 45 && column < board.width)
        {
            //Right swiping
            otherDot = board.allDots[column + 1, row];//changes clumn position gets the dot to the right
            otherDot.GetComponent<Pieces>().column -= 1;//changes the position of that selected dot
            column += 1;// changes our chosen dot to that new column position
        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && row<board.height) //depending on what angle the user swipes. 
        {
            //Up swiping
            otherDot = board.allDots[column, row+1];
            otherDot.GetComponent<Pieces>().row -= 1;
            row += 1;
        }
        else if ((swipeAngle > 135 || swipeAngle <= -135) && column>0)
        {
            //Left swiping
            otherDot = board.allDots[column - 1, row];
            otherDot.GetComponent<Pieces>().column += 1;
            column -= 1;
        }
        else if (swipeAngle < -45 && swipeAngle >= -135 && row>0)
        {
            //Down swiping
            otherDot = board.allDots[column, row-1];
            otherDot.GetComponent<Pieces>().row += 1;
            row -= 1; 
        }
    }

    void FindMatches() // initially the isMatched is false, as in no match. 
    {
        if(column > 0 && column < board.width - 1) //
        {
            GameObject leftDot1 = board.allDots[column - 1, row]; // swaps the dot with the dot to its left or right .  changing the column changes the dot position
            GameObject rightDot1 = board.allDots[column + 1, row];
            if (leftDot1.tag == this.gameObject.tag && rightDot1.tag == this.gameObject.tag) 
            {
                leftDot1.GetComponent<Pieces>().isMatched = true;
                rightDot1.GetComponent<Pieces>().isMatched = true;
                isMatched = true;


            }
        }
        if (row > 0 && row < board.height - 1) //
        {
            GameObject upDot1 = board.allDots[column, row+1]; //same thing as the previous if statement but goes vertical.
            GameObject downDot1 = board.allDots[column, row-1];
            if (upDot1.tag == this.gameObject.tag && downDot1.tag == this.gameObject.tag)
            {
                upDot1.GetComponent<Pieces>().isMatched = true;
                downDot1.GetComponent<Pieces>().isMatched = true;
                isMatched = true;


            }
        }
    }
}