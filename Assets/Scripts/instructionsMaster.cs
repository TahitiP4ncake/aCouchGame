using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionsMaster : MonoBehaviour {

	#region Variables
    //4 SPACE TEXT
    public Text red;
    public Text blue;
    public Text green;
    public Text yellow;

    public int numberOfPlayer;

	//max number of bodyparts available in the players
    private int hands;
    private int foots;
    private int butts;
    private int heads;

    private int usedHands;
    private int usedFoots;
    private int usedButts;
    private int usedHeads;

    private int choice;
    private int colorChoice;
    private int number;

    private Text orders;
    private string part;

    private bool tour;

    private bool start;

    public bool P2;
    public bool P3 = false;
    public bool P4;
    public bool P5;

    private Touch touch;

    public int numberOfPart;
    //List<string> instructions = new List<string>();

    //Dictionary<string, int> dictionary = new Dictionary<string, int>();

    private bool display;
	#endregion

	void playerSelection()
    {
        red.text = "2 Players";
        blue.text = "3 Players";
        green.text = "4 Players";
        yellow.text = "5 Players";
    }

	void Update () 
	{
		//Dans l'update ?!! sauvage
        hands = numberOfPlayer * 2;
        foots = numberOfPlayer * 2;
        butts = numberOfPlayer;
        //heads = numberOfPlayer;

        CheckInput();

        if (!start)
        {
            if (P2)
            {
                numberOfPlayer = 2;
                StartGame();
                Debug.Log("2 joueurs");
            }
            
            if (P3)
            {
                numberOfPlayer = 3;
                StartGame();
                Debug.Log("3 joueurs");
            }
            
            if (P4)
            {
                numberOfPlayer = 4;
                StartGame();
                Debug.Log("4 joueurs");
            }
            if (P5)
            {
                numberOfPlayer = 5;
                Debug.Log("5 joueurs");
                StartGame();
            }
        }

		if (Input.GetKeyDown(KeyCode.U))
			Debug.Log (WeightedRandom(5, 9));
		
		if (Input.GetKeyDown(KeyCode.I))
		{
			int[] i = GenerateBodyParts(3);
			Debug.Log(i[0] + " butts, " + i[1] + " feet, " + i[2] + " hands");
		}
    }
    /*
    void Order()
    {
        
        tour = true;
        choice = Random.Range(1, 5);
        
        colorChoice = Random.Range(1, 5);
        if(choice == 1)
        {
            part = " hand";
            number = Random.Range(1, hands);
        }
        if(choice ==2)
        {
            part = " foot";
            number = Random.Range(1, foots);
        }
        if(choice ==3)
        {
            part = " butt";
            number = Random.Range(1, butts);
        }
        if(choice == 4)
        { 
            part = " head";
            number = Random.Range(1, heads);
        }
        if(colorChoice==1)
        {
            red.text = number + part ;
        }
        if (colorChoice == 2)
        {
            blue.text = number + part;
        }
        if (colorChoice == 3)
        {
            green.text = number + part;
        }
        if (colorChoice == 4)
        {
            yellow.text = number + part;
        }
    }
    */

    void StartGame()
    {

        start = true;
        

        red.text = "";
        blue.text = "";
        green.text = "";
        yellow.text = "";

        Tour();
        //Order();
    }

    IEnumerator tourWait()
    {
        yield return new WaitForSecondsRealtime(.5f);
        tour = false;
    }

    void CheckInput()
    {
       if(Input.touchCount == 1 && !tour && start)
        {
            Tour();
            //Order();
        }
       if(Input.GetKeyDown("space"))
        {
            Tour();
        }
        
       if(Input.touchCount==2)
        {
            playerSelection();
            start = false;
            P2 = false;
            P3 = false;
            P4 = false;
            P5 = false;

        }
    }

    void Tour()
    {
        tour = true;
        StartCoroutine(tourWait());

        numberOfPart = numberOfPlayer + Random.Range(2,5);
        //Debug.Log(numberOfPart);
        red.text = "";
        blue.text = "";
        green.text = "";
        yellow.text = "";
        usedHands = 0;
        usedFoots = 0;
        usedButts = 0;
        //usedHeads = 0;


        for (int i = 0; i < numberOfPart;)
        {
            //Debug.Log(i);
            //choice = Random.Range(1, 4);
            choice = Random.Range(1,4);
            colorChoice = Random.Range(1, 5);
            display = false;
            if (choice == 1 && i<hands)
            {
                part = " hand";
                number = Random.Range(1, hands-usedHands);
                
                //Debug.Log(hands-usedHands);
                if(number+i>(numberOfPart))
                {
                    number -= (number - (numberOfPart));
                }
                usedHands += number;
                i += number;
                display = true;
            }


            if (choice == 2 && i<foots)
            {
                part = " foot";
                number = Random.Range(1, foots - usedFoots);
                
                if (number > (numberOfPart - i))
                {
                    number -= (number - (numberOfPart - i));
                }
                usedFoots += number;
                i += number;
                display = true;
            }

            if (choice == 3 && i<butts)
            {
                part = " butt";
                number = Random.Range(1, butts - usedButts);

                if (number+i > (numberOfPart))
                {
                    number -= (number - (numberOfPart - i));
                }
                usedButts += number;
                i += number;

                display = true;
            }

            /*
            if (choice == 4)
            {
                part = " head";
                number = Random.Range(1, heads-usedHeads);
                usedHeads += number;
            }
            */
            if (colorChoice == 1 && display)
            {
                red.text = red.text + " \n" + number + part;
            }
            if (colorChoice == 2 && display)
            {
                blue.text = blue.text + " \n" + number + part;
            }
            if (colorChoice == 3 && display)
            {
                green.text = green.text + " \n" + number + part;
            }
            if (colorChoice == 4 && display)
            {
                yellow.text =yellow.text + " \n" + number + part;
            }
            if(!display)
            {
                i += 1;
            }
        }

        if(usedHands>numberOfPart-2)
        {
            Tour();
        }
    }
    /*
    void OnGUI()
    {
        foreach (Touch touch in Input.touches)
        {
            string message = "";
            message += "ID: " + touch.fingerId + "\n";
            message += "Phase : " + touch.phase.ToString() + "\n";
            message += "TapCount : " + touch.tapCount + "\n";
            message += "Pos X : " + touch.position.x + "\n";
            message += "Pos Y : " + touch.position.y + "\n";

            int num = touch.fingerId;
            GUI.Label(new Rect(0 + 130 * num, 0, 120, 100), message);
        }
    }
    */

	int[] GenerateBodyParts (int players)
	{
		int minButts = 0;
		int maxButts = players - 1;
		int actualButts = WeightedRandom(minButts, maxButts);

		int minFeet = players - 1 - actualButts;
		int maxFeet = 2*players - 1 - actualButts;
		int actualFeet = WeightedRandom(minFeet, maxFeet);

		int minHands = Mathf.Max(0, players - actualButts - actualFeet);
		int maxHands = 2*players;
		int actualHands = WeightedRandom(minHands, maxHands);

		return new int[] {actualButts, actualFeet, actualHands};
	}

	int WeightedRandom (int min, int max)
	{
		return (int) (min + Mathf.Pow((Random.value*Mathf.Sqrt(max - min + 1)), 2));
	}
}
