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
    // Start is called before the first frame update
    void Start(){
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
            findMatches.currentMatches.Remove(allDots[column, row]);
            GameObject particle = Instantiate(destroyEffect, allDots[column, row].transform.position, Quaternion.identity);
            Destroy(particle, .5f);
            Destroy(allDots[column, row]);
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
        yield return new WaitForSeconds(.2f);
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
        yield return new WaitForSeconds(.2f); // wait some time to see if there are any mathches and drstroy them

        while (MatchesOnBoard())
        {
            yield return new WaitForSeconds(.2f);
            DestroyMatches();
        }
        yield return new WaitForSeconds(.2f);
        currentState = GameState.move;
    }
    
}
