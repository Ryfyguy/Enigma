using UnityEngine;

public class Click : MonoBehaviour
{
    public TextMesh zero;
    public TextMesh one;
    public TextMesh two;
    public TextMesh three;
    public TextMesh four;
    public TextMesh five;
    public TextMesh six;
    public TextMesh seven;
    public TextMesh eight;
    public TextMesh nine;
    public TextMesh zeroTwo;
    public TextMesh threeTwo;
    public TextMesh fourTwo;
    public TextMesh fiveTwo;
    public TextMesh fourThree;
    public TextMesh twoTwo;
    public TextMesh threeThree;
    public TextMesh threeFour;
    public TextMesh fourFour;

    private string TestAnswer;


    // Start is called before the first frame update
    void Start()
    {
        zero.color = Color.yellow;
        zeroTwo.color = Color.yellow;

    }

    // Update is called once per frame
    void Update()
    {

    

        if (!Input.GetKeyUp(KeyCode.LeftShift))
        {
            Alphabet();
            TestAnswer = "";
            TestAnswer += zero.text;
            TestAnswer += one.text;
            TestAnswer += two.text;
            TestAnswer += three.text;
            TestAnswer += " ";
            TestAnswer += threeTwo.text;
            TestAnswer += four.text;
            TestAnswer += five.text;
            TestAnswer += zeroTwo.text;
            TestAnswer += fourTwo.text;
            TestAnswer += fiveTwo.text;
            TestAnswer += six.text;
            TestAnswer += fourThree.text;
            TestAnswer += " ";
            TestAnswer += twoTwo.text;
            TestAnswer += threeThree.text;
            TestAnswer += " ";
            TestAnswer += seven.text;
            TestAnswer += eight.text;
            TestAnswer += nine.text;
            TestAnswer += threeFour.text;
            TestAnswer += fourFour.text;
            GM.AnswerCheck = TestAnswer;
           

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            
            if (GM.Position == 9)
            {
                GM.Position = 0;
            }
            else
            {
                GM.Position += 1;
            }
            changeCurrent();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            
            if (GM.Position == 0){
                GM.Position = 9;
            }
            else
            {
                GM.Position -= 1;
            }
            changeCurrent();
        }


    }
    void changeCurrent()
    {
        if (GM.Position == 1)
        {
            one.color = Color.yellow;
            zero.color = Color.black;
            zeroTwo.color = Color.black;
            two.color = Color.black;
            twoTwo.color = Color.black;
        }
        else if (GM.Position == 2)
        {
            one.color = Color.black;
            two.color = Color.yellow;
            twoTwo.color = Color.yellow;
            three.color = Color.black;
            threeTwo.color = Color.black;
            threeThree.color = Color.black;
            threeFour.color = Color.black;

        }
        else if (GM.Position == 3)
        {
            two.color = Color.black;
            twoTwo.color = Color.black;
            three.color = Color.yellow;
            threeTwo.color = Color.yellow;
            threeThree.color = Color.yellow;
            threeFour.color = Color.yellow;
            four.color = Color.black;
            fourTwo.color = Color.black;
            fourThree.color = Color.black;
            fourFour.color = Color.black;
        }
        else if (GM.Position == 4)
        {
            three.color = Color.black;
            threeTwo.color = Color.black;
            threeThree.color = Color.black;
            threeFour.color = Color.black;
            four.color = Color.yellow;
            fourTwo.color = Color.yellow;
            fourThree.color = Color.yellow;
            fourFour.color = Color.yellow;
            five.color = Color.black;
            fiveTwo.color = Color.black;
        }
        else if (GM.Position == 5)
        {
            four.color = Color.black;
            fourTwo.color = Color.black;
            fourThree.color = Color.black;
            fourFour.color = Color.black;
            five.color = Color.yellow;
            fiveTwo.color = Color.yellow;
            six.color = Color.black;
        }
        else if (GM.Position == 6)
        {
            five.color = Color.black;
            fiveTwo.color = Color.black;
            six.color = Color.yellow;
            seven.color = Color.black;
        }
        else if (GM.Position == 7)
        {
            six.color = Color.black;
            seven.color = Color.yellow;
            eight.color = Color.black;
        }
        else if (GM.Position == 8)
        {
            seven.color = Color.black;
            eight.color = Color.yellow;
            nine.color = Color.black;
        }
        else if (GM.Position == 9)
        {
            eight.color = Color.black;
            nine.color = Color.yellow;
            zero.color = Color.black;
            zeroTwo.color = Color.black;
        }
        else
        {
            nine.color = Color.black;
            zero.color = Color.yellow;
            zeroTwo.color = Color.yellow;
            one.color = Color.black;
        }
    }
    void Alphabet()
    {

        if (Input.GetKeyUp(KeyCode.A))
        {
            if (GM.Position == 0)
            {
                zero.text = "a";
                zeroTwo.text = "a";
            }
            else if (GM.Position == 1)
            { one.text = "a"; }
            else if (GM.Position == 2)
            {
                two.text = "a";
                twoTwo.text = "a";
            }
            else if (GM.Position == 3)
            {
                three.text = "a";
                threeTwo.text = "a";
                threeFour.text = "a";
                threeThree.text = "a";
            }
            else if (GM.Position == 4)
            {
                four.text = "a";
                fourTwo.text = "a";
                fourThree.text = "a";
                fourFour.text = "a";
            }
            else if (GM.Position == 5)
            {
                five.text = "a";
                fiveTwo.text = "a";
            }
            else if (GM.Position == 6)
            { six.text = "a"; }
            else if (GM.Position == 7)
            { seven.text = "a"; }
            else if (GM.Position == 8)
            { eight.text = "a"; }
            else if (GM.Position == 9)
            { nine.text = "a"; }
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            if (GM.Position == 0)
            {
                zero.text = "b";
                zeroTwo.text = "b";
            }
            else if (GM.Position == 1)
            { one.text = "b"; }
            else if (GM.Position == 2)
            {
                two.text = "b";
                twoTwo.text = "b";
            }
            else if (GM.Position == 3)
            {
                three.text = "b";
                threeTwo.text = "b";
                threeFour.text = "b";
                threeThree.text = "b";
            }
            else if (GM.Position == 4)
            {
                four.text = "b";
                fourTwo.text = "b";
                fourThree.text = "b";
                fourFour.text = "b";
            }
            else if (GM.Position == 5)
            {
                five.text = "b";
                fiveTwo.text = "b";
            }
            else if (GM.Position == 6)
            { six.text = "b"; }
            else if (GM.Position == 7)
            { seven.text = "b"; }
            else if (GM.Position == 8)
            { eight.text = "b"; }
            else if (GM.Position == 9)
            { nine.text = "b"; }
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (GM.Position == 0)
            {
                zero.text = "c";
                zeroTwo.text = "c";
            }
            else if (GM.Position == 1)
            { one.text = "c"; }
            else if (GM.Position == 2)
            {
                two.text = "c";
                twoTwo.text = "c";
            }
            else if (GM.Position == 3)
            {
                three.text = "c";
                threeTwo.text = "c";
                threeFour.text = "c";
                threeThree.text = "c";
            }
            else if (GM.Position == 4)
            {
                four.text = "c";
                fourTwo.text = "c";
                fourThree.text = "c";
                fourFour.text = "c";
            }
            else if (GM.Position == 5)
            {
                five.text = "c";
                fiveTwo.text = "c";
            }
            else if (GM.Position == 6)
            { six.text = "c"; }
            else if (GM.Position == 7)
            { seven.text = "c"; }
            else if (GM.Position == 8)
            { eight.text = "c"; }
            else if (GM.Position == 9)
            { nine.text = "c"; }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (GM.Position == 0)
            {
                zero.text = "d";
                zeroTwo.text = "d";
            }
            else if (GM.Position == 1)
            {
                one.text = "d";
            }
            else if (GM.Position == 2)
            {
                two.text = "d";
                twoTwo.text = "d";
            }
            else if (GM.Position == 3)
            {
                three.text = "d";
                threeTwo.text = "d";
                threeFour.text = "d";
                threeThree.text = "d";
            }
            else if (GM.Position == 4)
            {
                four.text = "d";
                fourTwo.text = "d";
                fourThree.text = "d";
                fourFour.text = "d";
            }
            else if (GM.Position == 5)
            {
                five.text = "d";
                fiveTwo.text = "d";
            }
            else if (GM.Position == 6)
            {
                six.text = "d";
            }
            else if (GM.Position == 7)
            {
                seven.text = "d";
            }
            else if (GM.Position == 8)
            {
                eight.text = "d";
            }
            else if (GM.Position == 9)
            {
                nine.text = "d";
            }
        }
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (GM.Position == 0)
                {
                    zero.text = "e";
                    zeroTwo.text = "e";
                }
                else if (GM.Position == 1)
                { one.text = "e"; }
                else if (GM.Position == 2)
                {
                    two.text = "e";
                    twoTwo.text = "e";
                }
                else if (GM.Position == 3)
                {
                    three.text = "e";
                    threeTwo.text = "e";
                    threeFour.text = "e";
                    threeThree.text = "e";
                }
                else if (GM.Position == 4)
                {
                    four.text = "e";
                    fourTwo.text = "e";
                    fourThree.text = "e";
                    fourFour.text = "e";
                }
                else if (GM.Position == 5)
                {
                    five.text = "e";
                    fiveTwo.text = "e";
                }
                else if (GM.Position == 6)
                { six.text = "e"; }
                else if (GM.Position == 7)
                { seven.text = "e"; }
                else if (GM.Position == 8)
                { eight.text = "e"; }
                else if (GM.Position == 9)
                { nine.text = "e"; }
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                if (GM.Position == 0)
                {
                    zero.text = "f";
                    zeroTwo.text = "f";
                }
                else if (GM.Position == 1)
                { one.text = "f"; }
                else if (GM.Position == 2)
                {
                    two.text = "f";
                    twoTwo.text = "f";
                }
                else if (GM.Position == 3)
                {
                    three.text = "f";
                    threeTwo.text = "f";
                    threeFour.text = "f";
                    threeThree.text = "f";
                }
                else if (GM.Position == 4)
                {
                    four.text = "f";
                    fourTwo.text = "f";
                    fourThree.text = "f";
                    fourFour.text = "f";
                }
                else if (GM.Position == 5)
                {
                    five.text = "f";
                    fiveTwo.text = "f";
                }
                else if (GM.Position == 6)
                { six.text = "f"; }
                else if (GM.Position == 7)
                { seven.text = "f"; }
                else if (GM.Position == 8)
                { eight.text = "f"; }
                else if (GM.Position == 9)
                { nine.text = "f"; }
            }
            if (Input.GetKeyUp(KeyCode.G))
            {
                if (GM.Position == 0)
                {
                    zero.text = "g";
                    zeroTwo.text = "g";
                }
                else if (GM.Position == 1)
                { one.text = "g"; }
                else if (GM.Position == 2)
                {
                    two.text = "g";
                    twoTwo.text = "g";
                }
                else if (GM.Position == 3)
                {
                    three.text = "g";
                    threeTwo.text = "g";
                    threeFour.text = "g";
                    threeThree.text = "g";
                }
                else if (GM.Position == 4)
                {
                    four.text = "g";
                    fourTwo.text = "g";
                    fourThree.text = "g";
                    fourFour.text = "g";
                }
                else if (GM.Position == 5)
                {
                    five.text = "g";
                    fiveTwo.text = "g";
                }
                else if (GM.Position == 6)
                { six.text = "g"; }
                else if (GM.Position == 7)
                { seven.text = "g"; }
                else if (GM.Position == 8)
                { eight.text = "g"; }
                else if (GM.Position == 9)
                { nine.text = "g"; }
            }
            if (Input.GetKeyUp(KeyCode.H))
            {
                if (GM.Position == 0)
                {
                    zero.text = "h";
                    zeroTwo.text = "h";
                }
                else if (GM.Position == 1)
                { one.text = "h"; }
                else if (GM.Position == 2)
                {
                    two.text = "h";
                    twoTwo.text = "h";
                }
                else if (GM.Position == 3)
                {
                    three.text = "h";
                    threeTwo.text = "h";
                    threeFour.text = "h";
                    threeThree.text = "h";
                }
                else if (GM.Position == 4)
                {
                    four.text = "h";
                    fourTwo.text = "h";
                    fourThree.text = "h";
                    fourFour.text = "h";
                }
                else if (GM.Position == 5)
                {
                    five.text = "h";
                    fiveTwo.text = "h";
                }
                else if (GM.Position == 6)
                { six.text = "h"; }
                else if (GM.Position == 7)
                { seven.text = "h"; }
                else if (GM.Position == 8)
                { eight.text = "h"; }
                else if (GM.Position == 9)
                { nine.text = "h"; }
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                if (GM.Position == 0)
                {
                    zero.text = "i";
                    zeroTwo.text = "i";
                }
                else if (GM.Position == 1)
                { one.text = "i"; }
                else if (GM.Position == 2)
                {
                    two.text = "i";
                    twoTwo.text = "i";
                }
                else if (GM.Position == 3)
                {
                    three.text = "i";
                    threeTwo.text = "i";
                    threeFour.text = "i";
                    threeThree.text = "i";
                }
                else if (GM.Position == 4)
                {
                    four.text = "i";
                    fourTwo.text = "i";
                    fourThree.text = "i";
                    fourFour.text = "i";
                }
                else if (GM.Position == 5)
                {
                    five.text = "i";
                    fiveTwo.text = "i";
                }
                else if (GM.Position == 6)
                { six.text = "i"; }
                else if (GM.Position == 7)
                { seven.text = "i"; }
                else if (GM.Position == 8)
                { eight.text = "i"; }
                else if (GM.Position == 9)
                { nine.text = "i"; }
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                if (GM.Position == 0)
                {
                    zero.text = "j";
                    zeroTwo.text = "j";
                }
                else if (GM.Position == 1)
                { one.text = "j"; }
                else if (GM.Position == 2)
                {
                    two.text = "j";
                    twoTwo.text = "j";
                }
                else if (GM.Position == 3)
                {
                    three.text = "j";
                    threeTwo.text = "j";
                    threeFour.text = "j";
                    threeThree.text = "j";
                }
                else if (GM.Position == 4)
                {
                    four.text = "j";
                    fourTwo.text = "j";
                    fourThree.text = "j";
                    fourFour.text = "j";
                }
                else if (GM.Position == 5)
                {
                    five.text = "j";
                    fiveTwo.text = "j";
                }
                else if (GM.Position == 6)
                { six.text = "j"; }
                else if (GM.Position == 7)
                { seven.text = "j"; }
                else if (GM.Position == 8)
                { eight.text = "j"; }
                else if (GM.Position == 9)
                { nine.text = "j"; }
            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                if (GM.Position == 0)
                {
                    zero.text = "k";
                    zeroTwo.text = "k";
                }
                else if (GM.Position == 1)
                { one.text = "k"; }
                else if (GM.Position == 2)
                {
                    two.text = "k";
                    twoTwo.text = "k";
                }
                else if (GM.Position == 3)
                {
                    three.text = "k";
                    threeTwo.text = "k";
                    threeFour.text = "k";
                    threeThree.text = "k";
                }
                else if (GM.Position == 4)
                {
                    four.text = "k";
                    fourTwo.text = "k";
                    fourThree.text = "k";
                    fourFour.text = "k";
                }
                else if (GM.Position == 5)
                {
                    five.text = "k";
                    fiveTwo.text = "k";
                }
                else if (GM.Position == 6)
                { six.text = "k"; }
                else if (GM.Position == 7)
                { seven.text = "k"; }
                else if (GM.Position == 8)
                { eight.text = "k"; }
                else if (GM.Position == 9)
                { nine.text = "k"; }
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                if (GM.Position == 0)
                {
                    zero.text = "l";
                    zeroTwo.text = "l";
                }
                else if (GM.Position == 1)
                { one.text = "l"; }
                else if (GM.Position == 2)
                {
                    two.text = "l";
                    twoTwo.text = "l";
                }
                else if (GM.Position == 3)
                {
                    three.text = "l";
                    threeTwo.text = "l";
                    threeFour.text = "l";
                    threeThree.text = "l";
                }
                else if (GM.Position == 4)
                {
                    four.text = "l";
                    fourTwo.text = "l";
                    fourThree.text = "l";
                    fourFour.text = "l";
                }
                else if (GM.Position == 5)
                {
                    five.text = "l";
                    fiveTwo.text = "l";
                }
                else if (GM.Position == 6)
                { six.text = "l"; }
                else if (GM.Position == 7)
                { seven.text = "l"; }
                else if (GM.Position == 8)
                { eight.text = "l"; }
                else if (GM.Position == 9)
                { nine.text = "l"; }
            }
            if (Input.GetKeyUp(KeyCode.M))
            {
                if (GM.Position == 0)
                {
                    zero.text = "m";
                    zeroTwo.text = "m";
                }
                else if (GM.Position == 1)
                { one.text = "m"; }
                else if (GM.Position == 2)
                {
                    two.text = "m";
                    twoTwo.text = "m";
                }
                else if (GM.Position == 3)
                {
                    three.text = "m";
                    threeTwo.text = "m";
                    threeFour.text = "m";
                    threeThree.text = "m";
                }
                else if (GM.Position == 4)
                {
                    four.text = "m";
                    fourTwo.text = "m";
                    fourThree.text = "m";
                    fourFour.text = "m";
                }
                else if (GM.Position == 5)
                {
                    five.text = "m";
                    fiveTwo.text = "m";
                }
                else if (GM.Position == 6)
                { six.text = "m"; }
                else if (GM.Position == 7)
                { seven.text = "m"; }
                else if (GM.Position == 8)
                { eight.text = "m"; }
                else if (GM.Position == 9)
                { nine.text = "m"; }
            }
            if (Input.GetKeyUp(KeyCode.N))
            {
                if (GM.Position == 0)
                {
                    zero.text = "n";
                    zeroTwo.text = "n";
                }
                else if (GM.Position == 1)
                { one.text = "n"; }
                else if (GM.Position == 2)
                {
                    two.text = "n";
                    twoTwo.text = "n";
                }
                else if (GM.Position == 3)
                {
                    three.text = "n";
                    threeTwo.text = "n";
                    threeFour.text = "n";
                    threeThree.text = "n";
                }
                else if (GM.Position == 4)
                {
                    four.text = "n";
                    fourTwo.text = "n";
                    fourThree.text = "n";
                    fourFour.text = "n";
                }
                else if (GM.Position == 5)
                {
                    five.text = "n";
                    fiveTwo.text = "n";
                }
                else if (GM.Position == 6)
                { six.text = "n"; }
                else if (GM.Position == 7)
                { seven.text = "n"; }
                else if (GM.Position == 8)
                { eight.text = "n"; }
                else if (GM.Position == 9)
                { nine.text = "n"; }
            }
            if (Input.GetKeyUp(KeyCode.O))
            {
                if (GM.Position == 0)
                {
                    zero.text = "o";
                    zeroTwo.text = "o";
                }
                else if (GM.Position == 1)
                { one.text = "o"; }
                else if (GM.Position == 2)
                {
                    two.text = "o";
                    twoTwo.text = "o";
                }
                else if (GM.Position == 3)
                {
                    three.text = "o";
                    threeTwo.text = "o";
                    threeFour.text = "o";
                    threeThree.text = "o";
                }
                else if (GM.Position == 4)
                {
                    four.text = "o";
                    fourTwo.text = "o";
                    fourThree.text = "o";
                    fourFour.text = "o";
                }
                else if (GM.Position == 5)
                {
                    five.text = "o";
                    fiveTwo.text = "o";
                }
                else if (GM.Position == 6)
                { six.text = "o"; }
                else if (GM.Position == 7)
                { seven.text = "o"; }
                else if (GM.Position == 8)
                { eight.text = "o"; }
                else if (GM.Position == 9)
                { nine.text = "o"; }
            }
            if (Input.GetKeyUp(KeyCode.P))
            {
                if (GM.Position == 0)
                {
                    zero.text = "p";
                    zeroTwo.text = "p";
                }
                else if (GM.Position == 1)
                { one.text = "p"; }
                else if (GM.Position == 2)
                {
                    two.text = "p";
                    twoTwo.text = "p";
                }
                else if (GM.Position == 3)
                {
                    three.text = "p";
                    threeTwo.text = "p";
                    threeFour.text = "p";
                    threeThree.text = "p";
                }
                else if (GM.Position == 4)
                {
                    four.text = "p";
                    fourTwo.text = "p";
                    fourThree.text = "p";
                    fourFour.text = "p";
                }
                else if (GM.Position == 5)
                {
                    five.text = "p";
                    fiveTwo.text = "p";
                }
                else if (GM.Position == 6)
                { six.text = "p"; }
                else if (GM.Position == 7)
                { seven.text = "p"; }
                else if (GM.Position == 8)
                { eight.text = "p"; }
                else if (GM.Position == 9)
                { nine.text = "p"; }
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                if (GM.Position == 0)
                {
                    zero.text = "q";
                    zeroTwo.text = "q";
                }
                else if (GM.Position == 1)
                { one.text = "q"; }
                else if (GM.Position == 2)
                {
                    two.text = "q";
                    twoTwo.text = "q";
                }
                else if (GM.Position == 3)
                {
                    three.text = "q";
                    threeTwo.text = "q";
                    threeFour.text = "q";
                    threeThree.text = "q";
                }
                else if (GM.Position == 4)
                {
                    four.text = "q";
                    fourTwo.text = "q";
                    fourThree.text = "q";
                    fourFour.text = "q";
                }
                else if (GM.Position == 5)
                {
                    five.text = "q";
                    fiveTwo.text = "q";
                }
                else if (GM.Position == 6)
                { six.text = "q"; }
                else if (GM.Position == 7)
                { seven.text = "q"; }
                else if (GM.Position == 8)
                { eight.text = "q"; }
                else if (GM.Position == 9)
                { nine.text = "q"; }
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                if (GM.Position == 0)
                {
                    zero.text = "r";
                    zeroTwo.text = "r";
                }
                else if (GM.Position == 1)
                { one.text = "r"; }
                else if (GM.Position == 2)
                {
                    two.text = "r";
                    twoTwo.text = "r";
                }
                else if (GM.Position == 3)
                {
                    three.text = "r";
                    threeTwo.text = "r";
                    threeFour.text = "r";
                    threeThree.text = "r";
                }
                else if (GM.Position == 4)
                {
                    four.text = "r";
                    fourTwo.text = "r";
                    fourThree.text = "r";
                    fourFour.text = "r";
                }
                else if (GM.Position == 5)
                {
                    five.text = "r";
                    fiveTwo.text = "r";
                }
                else if (GM.Position == 6)
                { six.text = "r"; }
                else if (GM.Position == 7)
                { seven.text = "r"; }
                else if (GM.Position == 8)
                { eight.text = "r"; }
                else if (GM.Position == 9)
                { nine.text = "r"; }
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                if (GM.Position == 0)
                {
                    zero.text = "s";
                    zeroTwo.text = "s";
                }
                else if (GM.Position == 1)
                { one.text = "s"; }
                else if (GM.Position == 2)
                {
                    two.text = "s";
                    twoTwo.text = "s";
                }
                else if (GM.Position == 3)
                {
                    three.text = "s";
                    threeTwo.text = "s";
                    threeFour.text = "s";
                    threeThree.text = "s";
                }
                else if (GM.Position == 4)
                {
                    four.text = "s";
                    fourTwo.text = "s";
                    fourThree.text = "s";
                    fourFour.text = "s";
                }
                else if (GM.Position == 5)
                {
                    five.text = "s";
                    fiveTwo.text = "s";
                }
                else if (GM.Position == 6)
                { six.text = "s"; }
                else if (GM.Position == 7)
                { seven.text = "s"; }
                else if (GM.Position == 8)
                { eight.text = "s"; }
                else if (GM.Position == 9)
                { nine.text = "s"; }
            }
            if (Input.GetKeyUp(KeyCode.T))
            {
                if (GM.Position == 0)
                {
                    zero.text = "t";
                    zeroTwo.text = "t";
                }
                else if (GM.Position == 1)
                { one.text = "t"; }
                else if (GM.Position == 2)
                {
                    two.text = "t";
                    twoTwo.text = "t";
                }
                else if (GM.Position == 3)
                {
                    three.text = "t";
                    threeTwo.text = "t";
                    threeFour.text = "t";
                    threeThree.text = "t";
                }
                else if (GM.Position == 4)
                {
                    four.text = "t";
                    fourTwo.text = "t";
                    fourThree.text = "t";
                    fourFour.text = "t";
                }
                else if (GM.Position == 5)
                {
                    five.text = "t";
                    fiveTwo.text = "t";
                }
                else if (GM.Position == 6)
                { six.text = "t"; }
                else if (GM.Position == 7)
                { seven.text = "t"; }
                else if (GM.Position == 8)
                { eight.text = "t"; }
                else if (GM.Position == 9)
                { nine.text = "t"; }
            }
            if (Input.GetKeyUp(KeyCode.U))
            {
                if (GM.Position == 0)
                {
                    zero.text = "u";
                    zeroTwo.text = "u";
                }
                else if (GM.Position == 1)
                { one.text = "u"; }
                else if (GM.Position == 2)
                {
                    two.text = "u";
                    twoTwo.text = "u";
                }
                else if (GM.Position == 3)
                {
                    three.text = "u";
                    threeTwo.text = "u";
                    threeFour.text = "u";
                    threeThree.text = "u";
                }
                else if (GM.Position == 4)
                {
                    four.text = "u";
                    fourTwo.text = "u";
                    fourThree.text = "u";
                    fourFour.text = "u";
                }
                else if (GM.Position == 5)
                {
                    five.text = "u";
                    fiveTwo.text = "u";
                }
                else if (GM.Position == 6)
                { six.text = "u"; }
                else if (GM.Position == 7)
                { seven.text = "u"; }
                else if (GM.Position == 8)
                { eight.text = "u"; }
                else if (GM.Position == 9)
                { nine.text = "u"; }
            }
            if (Input.GetKeyUp(KeyCode.V))
            {
                if (GM.Position == 0)
                {
                    zero.text = "v";
                    zeroTwo.text = "v";
                }
                else if (GM.Position == 1)
                { one.text = "v"; }
                else if (GM.Position == 2)
                {
                    two.text = "v";
                    twoTwo.text = "v";
                }
                else if (GM.Position == 3)
                {
                    three.text = "v";
                    threeTwo.text = "v";
                    threeFour.text = "v";
                    threeThree.text = "v";
                }
                else if (GM.Position == 4)
                {
                    four.text = "v";
                    fourTwo.text = "v";
                    fourThree.text = "v";
                    fourFour.text = "v";
                }
                else if (GM.Position == 5)
                {
                    five.text = "v";
                    fiveTwo.text = "v";
                }
                else if (GM.Position == 6)
                { six.text = "v"; }
                else if (GM.Position == 7)
                { seven.text = "v"; }
                else if (GM.Position == 8)
                { eight.text = "v"; }
                else if (GM.Position == 9)
                { nine.text = "v"; }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                if (GM.Position == 0)
                {
                    zero.text = "w";
                    zeroTwo.text = "w";
                }
                else if (GM.Position == 1)
                { one.text = "w"; }
                else if (GM.Position == 2)
                {
                    two.text = "w";
                    twoTwo.text = "w";
                }
                else if (GM.Position == 3)
                {
                    three.text = "w";
                    threeTwo.text = "w";
                    threeFour.text = "w";
                    threeThree.text = "w";
                }
                else if (GM.Position == 4)
                {
                    four.text = "w";
                    fourTwo.text = "w";
                    fourThree.text = "w";
                    fourFour.text = "w";
                }
                else if (GM.Position == 5)
                {
                    five.text = "w";
                    fiveTwo.text = "w";
                }
                else if (GM.Position == 6)
                { six.text = "w"; }
                else if (GM.Position == 7)
                { seven.text = "w"; }
                else if (GM.Position == 8)
                { eight.text = "w"; }
                else if (GM.Position == 9)
                { nine.text = "w"; }
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                if (GM.Position == 0)
                {
                    zero.text = "x";
                    zeroTwo.text = "x";
                }
                else if (GM.Position == 1)
                { one.text = "x"; }
                else if (GM.Position == 2)
                {
                    two.text = "x";
                    twoTwo.text = "x";
                }
                else if (GM.Position == 3)
                {
                    three.text = "x";
                    threeTwo.text = "x";
                    threeFour.text = "x";
                    threeThree.text = "x";
                }
                else if (GM.Position == 4)
                {
                    four.text = "x";
                    fourTwo.text = "x";
                    fourThree.text = "x";
                    fourFour.text = "x";
                }
                else if (GM.Position == 5)
                {
                    five.text = "x";
                    fiveTwo.text = "x";
                }
                else if (GM.Position == 6)
                { six.text = "x"; }
                else if (GM.Position == 7)
                { seven.text = "x"; }
                else if (GM.Position == 8)
                { eight.text = "x"; }
                else if (GM.Position == 9)
                { nine.text = "x"; }
            }
            if (Input.GetKeyUp(KeyCode.Y))
            {
                if (GM.Position == 0)
                {
                    zero.text = "y";
                    zeroTwo.text = "y";
                }
                else if (GM.Position == 1)
                { one.text = "y"; }
                else if (GM.Position == 2)
                {
                    two.text = "y";
                    twoTwo.text = "y";
                }
                else if (GM.Position == 3)
                {
                    three.text = "y";
                    threeTwo.text = "y";
                    threeFour.text = "y";
                    threeThree.text = "y";
                }
                else if (GM.Position == 4)
                {
                    four.text = "y";
                    fourTwo.text = "y";
                    fourThree.text = "y";
                    fourFour.text = "y";
                }
                else if (GM.Position == 5)
                {
                    five.text = "y";
                    fiveTwo.text = "y";
                }
                else if (GM.Position == 6)
                { six.text = "y"; }
                else if (GM.Position == 7)
                { seven.text = "y"; }
                else if (GM.Position == 8)
                { eight.text = "y"; }
                else if (GM.Position == 9)
                { nine.text = "y"; }
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                if (GM.Position == 0)
                {
                    zero.text = "z";
                    zeroTwo.text = "z";
                }
                else if (GM.Position == 1)
                { one.text = "z"; }
                else if (GM.Position == 2)
                {
                    two.text = "z";
                    twoTwo.text = "z";
                }
                else if (GM.Position == 3)
                {
                    three.text = "z";
                    threeTwo.text = "z";
                    threeFour.text = "z";
                    threeThree.text = "z";
                }
                else if (GM.Position == 4)
                {
                    four.text = "z";
                    fourTwo.text = "z";
                    fourThree.text = "z";
                    fourFour.text = "z";
                }
                else if (GM.Position == 5)
                {
                    five.text = "z";
                    fiveTwo.text = "z";
                }
                else if (GM.Position == 6)
                { six.text = "z"; }
                else if (GM.Position == 7)
                { seven.text = "z"; }
                else if (GM.Position == 8)
                { eight.text = "z"; }
                else if (GM.Position == 9)
                { nine.text = "z"; }
            }

        }
    }

