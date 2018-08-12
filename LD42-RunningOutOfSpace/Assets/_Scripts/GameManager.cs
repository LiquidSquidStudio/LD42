using UnityEngine;

public class GameManager : MonoBehaviour {

	// Game mode tracking
	//enum Mode { Start, Game, End };
	//Mode current = Mode.Start;


	//// Gonna need reference to the objects to spawn
	//test_Rocket player = null;
	//test_Satalite player_Controlled = null;
    

	// Game State tracking

	void Awake ()
    {
		// The game manager will persist and be reset
		DontDestroyOnLoad(this.gameObject);
	}
	
	void Update () 
	{
		
	}

    //void GameState()
    //{
    //    switch (current)
    //    {
    //        case Mode.Start:
    //            //ResetGame();
    //            //StartGame();
    //            current = Mode.Game;

    //            break;

    //        case Mode.Game:

    //            // Add score and spawn stuff

    //            break;

    //        case Mode.End:

    //            // Display Score 

    //            break;
    //    }
    //}
}
