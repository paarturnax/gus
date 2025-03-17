using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMiniGameController : MonoBehaviour
{
    [SerializeField] private MovingPuzzl[] puzzles;
    [SerializeField] private GameObject AnimatedScreen;

    private bool isAllInPlace;

	private void Start()
	{
        AnimatedScreen.SetActive(false);
	}
	void Update()
    {
        isAllInPlace = true;

		foreach (MovingPuzzl puzzl in puzzles)
        {
            if (!puzzl.isOnPlace)
                isAllInPlace = false;
		}

        if (isAllInPlace)
			AnimatedScreen.SetActive(true);

	}
}
