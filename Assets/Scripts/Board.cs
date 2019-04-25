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
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = "( " + i + ", " + z + " )";
                allDots[i, z] = dot;
            }

        }
    }
    
}
