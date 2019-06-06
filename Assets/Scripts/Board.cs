using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    wait,
    move
}
public class Board : MonoBehaviour
{
    private FindMatches findMatches;
    public GameState currentState = GameState.move;

    public int width; //how wide
    public int height; // how tall
    public int offSet;
    //2d array can hold two different value sort of like x and y
    public GameObject tilePrefab;
    public GameObject[] dots;
    public GameObject destroyEffect;
    private BackgroundTile[,] allTiles;
    public GameObject[,] allDots;
    public int baseValue = 20;
    private int streak = 1;
    private ScoreManager scoreManager;
    public float delay = 0.5f;
    public int[] scoreGoals;
    // Start is called before the first frame update
    void Start(){
        scoreManager = FindObjectOfType<ScoreManager>();
        findMatches = FindObjectOfType<FindMatches>();
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        SetUp();
    }
    private void SetUp()
    {
        for(int i =0; i<width; i++)
        {
            for(int z = 0; z<height; z++) // allows for the setup of the board. The dots object are placed over the actual board, making them the same. 
            {
                Vector2 tempPosition = new Vector2(i, z + offSet);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + ", " + z + " )";
                int dotToUse = Random.Range(0, dots.Length);
                int maxIterations = 0;
                while(MatchesAt(i,z, dots[dotToUse]) && maxIterations<100) // keeps checking all the dots and changes the dots until the board starts with zero matching colors. 
                {
                    dotToUse = Random.Range(0, dots.Length);
                    maxIterations++;
                }
                maxIterations = 0; //dots generated over time.
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.GetComponent<Pieces>().row = z;
                dot.GetComponent<Pieces>().column = i;
                dot.transform.parent = this.transform;
                dot.name = "( " + i + ", " + z + " )";
                allDots[i, z] = dot;
            }

        }
    }

    //checks whethero r not there are matches at a specific spot.
    private bool MatchesAt(int column, int row, GameObject piece)
    {
        // if column greater than 1 it will check the column to the left and right and same for row.
        if(column > 1 && row > 1)
        {
            if(allDots[column -1, row].tag == piece.tag && allDots[column -2, row].tag == piece.tag)
            {
                return true;
            }
            if (allDots[column, row-1].tag == piece.tag && allDots[column , row-2].tag == piece.tag)
            {
                return true;
            }

        }else if(column <= 1 || row <= 1)
        {
            if(row > 1)
            {
                if(allDots[column , row -1].tag == piece.tag && allDots[column, row -2].tag == piece.tag)
                {// checks the first 2 rows and columns
                    return true;
                }
            }
            if (column > 1)
            {
                if (allDots[column-1, row].tag == piece.tag && allDots[column-2, row].tag == piece.tag)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void DestroyMatchesAt(int column, int row)
    {
        if (allDots[column, row].GetComponent<Pieces>().isMatched)
        {

            GameObject particle = Instantiate(destroyEffect, allDots[column, row].transform.position, Quaternion.identity);
            Destroy(particle, .5f);
            Destroy(allDots[column, row]);
            scoreManager.IncreaseScore(baseValue * streak);
            allDots[column, row] = null; // this will destroy the piece if it already has been matched

        }
    }
    public void DestroyMatches()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j<height; j++) // going to check the row and column to see if it has a piece in it if it does it will try to destroy it. 
            {
                if (allDots[i,j] !=null)
                {
                    DestroyMatchesAt(i, j);
                }
            }
        }
        findMatches.currentMatches.Clear();
        findMatches.currentMatches.Clear();
        StartCoroutine(DecreaseRowCo());
    }

    private IEnumerator DecreaseRowCo()
    {
        int nullCount = 0;
        for (int i = 0; i <width; i++)
        {
            for(int j = 0; j <height; j++)
            {
                if(allDots[i,j] == null)
                {
                    nullCount++;
                }else if(nullCount > 0)
                {
                    allDots[i, j].GetComponent<Pieces>().row -= nullCount;
                    allDots[i, j] = null;
                }
            }
            nullCount = 0;
        }
        yield return new WaitForSeconds(delay * 0.5f);
        StartCoroutine(FillBoardCo());

    }

    private void RefillBoard()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j=0;j < height; j++)
            {
                if (allDots[i, j] == null)
                {
                    Vector2 tempPosition = new Vector2(i, j + offSet);
                    int dotToUse = Random.Range(0, dots.Length);
                    int maxIterations = 0;
                    while (MatchesAt(i, j, dots[dotToUse]))
                    {
                        maxIterations++;
                        dotToUse = Random.Range(0, dots.Length);
                    }
                    maxIterations = 0;
                    GameObject piece = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                    allDots[i, j] = piece;
                    piece.GetComponent<Pieces>().row = j;
                    piece.GetComponent<Pieces>().column = i;
                }
            }
        }
    }

    private bool MatchesOnBoard()
    {
        for(int i = 0; i <width; i++)
        {
            for(int j = 0; j< height; j++)
            {
                if (allDots[i, j] != null)
                {
                    if (allDots[i, j].GetComponent<Pieces>().isMatched)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private IEnumerator FillBoardCo()//refill board
    {
        RefillBoard();
        yield return new WaitForSeconds(delay); // wait some time to see if there are any mathches and drstroy them

        while (MatchesOnBoard())
        {
            streak++;
            DestroyMatches();

            yield return new WaitForSeconds(2 * delay);
        }
        findMatches.currentMatches.Clear();
        yield return new WaitForSeconds(.5f);
        if (IsDeadlocked())
        {
            ShuffleBoard();
            Debug.Log("Deadlock");
        }
        yield return new WaitForSeconds(delay);
        currentState = GameState.move;
        streak = 1;
    }

    private void SwitchPieces(int column, int row, Vector2 direction)
    {
        //Take second piece and save it in a holder
        GameObject holder = allDots[column + (int)direction.x, row + (int)direction.y] as GameObject; //hold the one we are switching with
        // switching the first dot to be second position
        allDots[column + (int)direction.x, row + (int)direction.y] = allDots[column, row]; // we will mve the first one in the second position and the held one into the first position
        // Set first do to be the second dot
        allDots[column, row] = holder;
    }

    //checking for matches on board and return a bool value
    private bool CheckForMatches()
    {
        for (int i = 0; i <width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                if(allDots[i,j] != null)
                {// if not empty space it will do this then check right and up dots
                    // make sure that one and two to the right are in the board
                    if(i <width - 2)
                    {
                        if(allDots[i + 1, j] !=null && allDots[i+2,j] != null)
                        {
                            if(allDots[i +1,j].tag == allDots[i,j].tag && allDots[i +2,j].tag == allDots[i, j].tag)
                            {
                                return true;
                            }
                        }

                    }
                    if (j <height - 2)
                    {
                        if (allDots[i, j + 1] != null && allDots[i, j + 2] != null)
                        {
                            if (allDots[i, j + 1].tag == allDots[i, j].tag && allDots[i, j + 2].tag == allDots[i, j].tag)
                            {
                                return true;
                            }
                        }
                    }
                    //check if the dots above exist
                    

                }

            }
        }
        return false;
    }

    private bool SwitchAndCheck(int column, int row, Vector2 direction)
    {
        SwitchPieces(column, row, direction);
        if (CheckForMatches())
        {
            SwitchPieces(column, row, direction);
            return true;
        }

        SwitchPieces(column, row, direction);
        return false;
    }


    private bool IsDeadlocked()
    {
        for(int i = 0; i <width; i++)
        {
            for (int j = 0; j <height; j++)
            {
                if (allDots [i,j] != null)
                {
                    if(i < width - 1)
                    {
                        if(SwitchAndCheck(i, j, Vector2.right))
                        {
                            return false;
                        }
                    }

                    if (j <height - 1)
                    {
                        if (SwitchAndCheck(i, j, Vector2.up))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

    private void ShuffleBoard()
    {
        // idea is create a list of current pieces on board and add everything on board, afterwardsd go through them to generate a random piece to put in that spot, then check recursively
        // Create a list of gameobjecy
        List<GameObject> newBoard = new List<GameObject>();
        // Add every piee to this list
        for (int i = 0; i <width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i,j] != null)
                {
                    newBoard.Add(allDots[i, j]);
                    // pick a random number
                    int pieceToUse = Random.Range(0, newBoard.Count);
                    // make container for the piece
                    // asign the column to the piece
                    int maxIterations = 0;
                    while (MatchesAt(i, j, newBoard[pieceToUse]) && maxIterations < 100) // keeps checking all the dots and changes the dots until the board starts with zero matching colors. 
                    {
                        pieceToUse= Random.Range(0, newBoard.Count);
                        maxIterations++;
                    }
                    Pieces piece = newBoard[pieceToUse].GetComponent<Pieces>();

                    maxIterations = 0; //dots generated over time.
                    // assign to the column
                    piece.column = i;
                    //asgn to the row
                    piece.row = j;
                    // fill in the dots array with new piece
                    allDots[i, j] = newBoard[pieceToUse];
                    // remove from piece
                    newBoard.Remove(newBoard[pieceToUse]);


                }
            }
        }

        // check if still deadlocked
        if (IsDeadlocked())
        {
            ShuffleBoard();
        }
    }
    
}
