using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    [Header("Board Variables")]
    public int column; // we need to the the position of the new gameobject board everytime we swap blocks.
    public int row;
    public int previousColumn;
    public int previousRow; // the row that was swapped
    public int targetX;
    public bool isMatched = false; // initially they arent matched so that everything doesnt end up matching, so setting it false and changing it to true will help to only make certain colors match. 
    private FindMatches findMatches;
    public int targetY;
    private Board board;
    private GameObject otherDot;
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;
    public float swipeAngle = 0;
    public float swipeResist = 1f;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        findMatches = FindObjectOfType<FindMatches>();
        //targetX = (int)transform.position.x;
        //targetY = (int)transform.position.y;
        //row = targetY;
        //column = targetX;
        //previousRow = row;
        //previousColumn = column;

    }

    // Update is called once per frame
    void Update() //checks for match, and if they are matched then they change the color to a darker color. 
    {
        //FindMatches();
        /*if (isMatched)
        {
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = new Color(1f, 1f, 1f, .2f);

        }
        */
        targetX = column;
        targetY = row;
        if(Mathf.Abs(targetX - transform.position.x) > .1)
        {
            //Move towards the target block
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .6f);
            if(board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
            }
            findMatches.FindAllMatches();
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
            transform.position = Vector2.Lerp(transform.position, tempPosition, .6f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
            }
            findMatches.FindAllMatches();

        }

        else
        {
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;
        }
    }

    //co-routine to check for certain conditions.
    public IEnumerator CheckMoveCo()
    {
        yield return new WaitForSeconds(.5f);// waits for 0.5 seconds
        if(otherDot != null)
        {
            if(!isMatched && !otherDot.GetComponent<Pieces>().isMatched)
            {
                otherDot.GetComponent<Pieces>().row = row;
                otherDot.GetComponent<Pieces>().column = column;
                row = previousRow;
                column = previousColumn;
                yield return new WaitForSeconds(.5f);
                board.currentState = GameState.move;

            }
            else
            {
                board.DestroyMatches();
                
            }
            
        }
    }

    private void OnMouseDown()
    {//gets the position of the mouse click when uer first clicks it.
        if(board.currentState == GameState.move)
        {
            firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets position of the first click
        }
        //Debug.Log(firstTouchPosition);
    }

    private void OnMouseUp()
    {// gets the position when the user lets go of the mouse click. 
        if(board.currentState == GameState.move)
        {
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //camrea.main gets the position of the world coordinate not the entire monitor screen coordinate. 
            CalculateAngle();

        }
    }
    void CalculateAngle()
    {
        if (Mathf.Abs(finalTouchPosition.y - firstTouchPosition.y) > swipeResist || Mathf.Abs(finalTouchPosition.x - firstTouchPosition.x) > swipeResist)
        {
            board.currentState = GameState.wait;

            swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI; //changes the radian found to angles, and we are basically doing pythagorean theorm here. 
                                                                                                                                                 //Debug.Log(swipeAngle);
            MovePieces();
            
        }
        else
        {
            board.currentState = GameState.move;
        }

    }
    void MovePieces()// moves based on player clicks, will account for the angle that the user swipes and not just straight 90 degree or 270 degrees. 
    {
        if(swipeAngle> -45 && swipeAngle <= 45 && column < board.width-1)
        {
            //Right swiping
            otherDot = board.allDots[column + 1, row];//changes clumn position gets the dot to the right
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Pieces>().column -= 1;//changes the position of that selected dot
            column += 1;// changes our chosen dot to that new column position
            StartCoroutine(CheckMoveCo());

        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && row<board.height-1) //depending on what angle the user swipes. 
        {
            //Up swiping
            otherDot = board.allDots[column, row+1];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Pieces>().row -= 1;
            row += 1;
            StartCoroutine(CheckMoveCo());

        }
        else if ((swipeAngle > 135 || swipeAngle <= -135) && column>0)
        {
            //Left swiping
            otherDot = board.allDots[column - 1, row];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Pieces>().column += 1;
            column -= 1;
            StartCoroutine(CheckMoveCo());

        }
        else if (swipeAngle < -45 && swipeAngle >= -135 && row>0)
        {
            //Down swiping
            otherDot = board.allDots[column, row-1];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Pieces>().row += 1;
            row -= 1;
            StartCoroutine(CheckMoveCo());

        }
        board.currentState = GameState.move;
    }

    void FindMatches() // initially the isMatched is false, as in no match. 
    {
        if(column > 0 && column < board.width - 1) //
        {
            GameObject leftDot1 = board.allDots[column - 1, row]; // swaps the dot with the dot to its left or right .  changing the column changes the dot position
            GameObject rightDot1 = board.allDots[column + 1, row];
            if (leftDot1 != null && rightDot1 != null)
            {
                if (leftDot1.tag == this.gameObject.tag && rightDot1.tag == this.gameObject.tag)
                {
                    leftDot1.GetComponent<Pieces>().isMatched = true;
                    rightDot1.GetComponent<Pieces>().isMatched = true;
                    isMatched = true;


                }
            }
        }
        if (row > 0 && row < board.height - 1) //
        {
            GameObject upDot1 = board.allDots[column, row+1]; //same thing as the previous if statement but goes vertical.
            GameObject downDot1 = board.allDots[column, row-1];
            if (upDot1 != null && downDot1 != null)
            {
                if (upDot1.tag == this.gameObject.tag && downDot1.tag == this.gameObject.tag)
                {
                    upDot1.GetComponent<Pieces>().isMatched = true;
                    downDot1.GetComponent<Pieces>().isMatched = true;
                    isMatched = true;


                }
            }
        }
    }
}
