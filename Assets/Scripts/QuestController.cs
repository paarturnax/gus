using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class QuestController : MonoBehaviour
{
	[SerializeField] private Teleport _teleportToScene;
	

	private void Awake()
	{
		
	}

	public void UpdateQuestStage(int queststage, int choice)
	{
		if (queststage == 1)
		{
			switch (choice)
			{
				case 0:
					_teleportToScene.gameObject.SetActive(true);
					break;
				case 1:
					StartCoroutine(SceneController.WaitThenLoadScene(1f, 0));
					break;
				case 2:
					break;
				default:
					break;
			}
		}
	}
}
