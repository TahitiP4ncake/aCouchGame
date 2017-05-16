using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionsMaster : MonoBehaviour 
{
	public Text red;
	public Text blue;
	public Text green;
	public Text yellow;

	public bool P2;
	public bool P3;
	public bool P4;
	public bool P5;

	bool gameHasBegun; //true if the game has started yet, false if still in the menu
    int numberOfPlayers;
	Touch touch;

	void Update () 
	{
		//changer si on appuie sur espace ou si on touche
		if(gameHasBegun && (Input.touchCount == 1 || Input.GetKeyDown("space")))
			Tour();

		//revenir au menu si on double-touche
		if(Input.touchCount==2 || Input.GetKeyDown(KeyCode.A))
		{
			red.text = "2 Players";
			blue.text = "3 Players";
			green.text = "4 Players";
			yellow.text = "5 Players";

			gameHasBegun = false;
			P2 = false;
			P3 = false;
			P4 = false;
			P5 = false;
		}

		//Lancer le jeu si le joueurs selectionne un nombre de joueurs
		if (!gameHasBegun)
		{
			numberOfPlayers = P2 ? 2 : P3 ? 3 : P4 ? 4 : P5 ? 5: 0;
			if (numberOfPlayers != 0)
			{
				gameHasBegun = true;
				Tour();
			}
		}
	}

	//Lancer un nouveau tour
	void Tour ()
	{
		int[,] bodyParts = GenerateBodyPartsWithColors(numberOfPlayers);
		Text[] texts = {red, blue, green, yellow};

		for (int i = 0; i < 4; i ++)
		{
			int b = bodyParts[i,0];
			int f = bodyParts[i,1];
			int h = bodyParts[i,2];

			texts[i].text = "";
			texts[i].text += (b == 0) ? "" : (b == 1) ? (b + " Butt\n") : (b + " Butts\n");
			texts[i].text += (f == 0) ? "" : (f == 1) ? (f + " Foot\n") : (f + " Feet\n");
			texts[i].text += (h == 0) ? "" : (h == 1) ? (h + " Hand\n") : (h + " Hands\n");
		}
	}

	//Générer un tableau de 4x3 associant des parties du corps et des couleurs
	int[,] GenerateBodyPartsWithColors (int players)
	{
		int[,] outcome = new int[4,3];
		for (int i = 0; i < 4; i++)
			for (int j = 0; j < 3; j++)
				outcome[i,j] = 0;

		int [] bodyParts = GenerateBodyParts(players);

		for (int i = 0; i < 3; i++)
			for (int j = 0; j < bodyParts[i]; j++)
				outcome [Random.Range(0,4), i] ++;

		return outcome;
	}

	//Générer un tableau de 3 entiers : fesse, pied, mains
	int[] GenerateBodyParts (int players)
	{
		int minButts = 0;
		int maxButts = players - 1;
		int actualButts = WeightedRandom(minButts, maxButts, 1);

		int minFeet = players - 1 - actualButts;
		int maxFeet = 2*players - 1 - actualButts;
		int actualFeet = WeightedRandom(minFeet, maxFeet, 1);

		int minHands = Mathf.Max(0, players - actualButts - actualFeet);
		int maxHands = 2*players;
		int actualHands = WeightedRandom(minHands, maxHands, 1);

		return new int[] {actualButts, actualFeet, actualHands};
	}

	//Générer un nombre aléatoire entre deux bornes, avec plus de chances de donner un nombre bas. Plus la difficulté est haute plus la chance est élevée. Valeur de base : 1
	int WeightedRandom (int min, int max, int difficulty)
	{
		return (int) (min + Mathf.Pow((Random.value*Mathf.Pow(max - min + 1, 1.0f/(1.0f+difficulty))), 1 + difficulty));
	}
}
