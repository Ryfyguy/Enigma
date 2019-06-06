using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMatches : MonoBehaviour
{

    private Board board;
    public List<GameObject> currentMatches = new List<GameObject>(); //can add and subtract from
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }

    public void FindAllMatches()
    {
        StartCoroutine(FindAllMatchesCo());
    }

    private void AddToListAndMatch(GameObject dot)
    {
        if (!currentMatches.Contains(dot))
        {
            currentMatches.Add(dot);
        }
        dot.GetComponent<Pieces>().isMatched = true;
    }

    private void GetNearbyPieces(GameObject dot1, GameObject dot2, GameObject dot3)
    {
        AddToListAndMatch(dot1);
        AddToListAndMatch(dot2);
        AddToListAndMatch(dot3);
    }
    private IEnumerator FindAllMatchesCo() 
    {
        yield return new WaitForSeconds(.2f);
        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                GameObject currentDot = board.allDots[i, j];
                if(currentDot != null) // checks tags for matching 
                {
                    Pieces currentDotDot = currentDot.GetComponent<Pieces>();

                    if (i > 0 && i < board.width -1) // if we are in the second column and no more within the second column
                    {
                        GameObject leftDot = board.allDots[i - 1, j];
                        GameObject rightDot = board.allDots[i + 1, j];
                        if (leftDot != null && rightDot != null)
                        {
                            Pieces leftDotDot = leftDot.GetComponent<Pieces>();

                            Pieces rightDotDot = rightDot.GetComponent<Pieces>();
                            if (leftDot != null && rightDot != null)
                            {
                                if (leftDot.tag == currentDot.tag && rightDot.tag == currentDot.tag)
                                {
                                    GetNearbyPieces(leftDot, currentDot, rightDot);


                                }
                            }
                        }
                        
                    }
                    if (j > 0 && j < board.height - 1) // if we are in the second column and no more within the second column
                    {
                        GameObject upDot = board.allDots[i, j+1];
                        GameObject downDot = board.allDots[i, j-1];
                        if(upDot != null && downDot != null)
                        {
                            Pieces upDotDot = upDot.GetComponent<Pieces>();

                            Pieces downDotDot = downDot.GetComponent<Pieces>();
                            if (upDot != null && downDot != null)
                            {
                                if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag)
                                {

                                    GetNearbyPieces(upDot, currentDot, downDot);

                                }
                            }
                        }
                        
                    }
                }
            }
        }
        yield return new WaitForSeconds(.2f);

    }

    List<GameObject> GetColumnPieces(int column) // cycle all pieces and check the array and if we are in the same column
    {


        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.height; i++)
        {
            if (board.allDots[column, i] != null)
            {
                dots.Add(board.allDots[column, i]);
                board.allDots[column, i].GetComponent<Pieces>().isMatched = true;
            }
        }
            return dots;
    }

    List<GameObject> GetRowPieces(int row) // cycle all pieces and check the array and if we are in the same column
    {


        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.width; i++) // get all the dots in a row, add them to a list and also make them matched. and return in the def. 
        {
            if (board.allDots[i, row] != null)
            {
                dots.Add(board.allDots[i, row]);
                board.allDots[i, row].GetComponent<Pieces>().isMatched = true;
            }
        }
        return dots;
    }
}
