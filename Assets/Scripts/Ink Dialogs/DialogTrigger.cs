using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
	[SerializeField] private GameObject _visualCue;
	[SerializeField] private TextAsset _inkJSON;

	private bool _isPlayerInRange;

	private void Awake()
	{
		_visualCue.SetActive(false);
		_isPlayerInRange = false;
	}
	private void Update()
	{
		if (_isPlayerInRange && !DialogManager.GetInstance()._dialogIsPlaying)
		{
			_visualCue.SetActive(true);
			if (Input.GetKeyDown(KeyCode.E))
			{
				DialogManager.GetInstance().EnterDialogMode(_inkJSON);
			}
		}
		else
		{
			_visualCue.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_isPlayerInRange = true;
		}

	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_isPlayerInRange = false;
		}
	}
}
