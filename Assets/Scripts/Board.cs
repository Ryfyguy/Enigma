using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public int width; //how wide
    public int height; // how tall
    //2d array can hold two different value sort of like x and y
    public GameObject tilePrefab;
    public GameObject[] dots;
    private BackgroundTile[,] allTiles;
    public GameObject[,] allDots;
    // Start is called before the first frame update
    void Start(){
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
                Vector2 tempPosition = new Vector2(i, z);
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
                maxIterations = 0;
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
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
    
}
