using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public enum GameState
	{
		Start = 0,
		Play,
		End
	}

	private GameState gameState = GameState.Start;
	private Player myPlayer;

	private void Start()
	{
		// Create Player

		// Create Spawner
	}

	/// <summary>
	/// Main Game System Update
	/// </summary>
	private void Update()
    {
		// Check Game State
		if (CheckGameState() == false) return;

		// Monster Spawn


		// Timer update
    }

	private bool CheckGameState()
	{
		return true;
	}
}
