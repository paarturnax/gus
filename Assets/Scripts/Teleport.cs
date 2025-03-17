using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	[SerializeField] private int _targetSceneIndex;
	private void Awake()
	{
		gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			StartCoroutine(SceneController.WaitThenLoadScene(0.5f, _targetSceneIndex));
		}
		
	}
}
