using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Game mode tracking
	enum Mode { Start, Game, End };
	Mode current = Mode.Start;

	// Gonna need reference to the objects to spawn
	test_Rocket player = null;
	test_Satalite player_Controlled = null;

	// Keep a track of all the active satillites to count for points
	public List<test_Satalite> satalites = new List<test_Satalite>();

	// Game Score
	float gameScore = 0.0f;
	int totalSatalites = 0;

	// Game State tracking

	// Use this for initialization
	void Start () {

		// The game manager will persist and be reset
		DontDestroyOnLoad(this.gameObject);
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		switch (current)
		{
		case Mode.Start:

			ResetGame ();
			StartGame ();
			current = Mode.Game;

			break;


		case Mode.Game:

			// Add score and spawn stuff
		
			break;


		case Mode.End:

			// Display Score 

			break;
		}
		
	}


	void StartGame()
	{

		// Spawn in the player and setup an other required conditions

	}

	void ResetGame()
	{
		
		// Reset the score
		gameScore = 0.0f;
		totalSatalites = 0;

		// If there is player objects ect destroy them and reset
		if (player != null)
		{
			Destroy (player);
			player = null;
		}

		if (player_Controlled != null)
		{
			Destroy (player_Controlled);
			player_Controlled = null;
		}

		// Destroy the remaining satillites 
		foreach (var sat in satalites)
		{
			Destroy (sat);
		}

		// Clear the list
		satalites.Clear();

	}
		
}
