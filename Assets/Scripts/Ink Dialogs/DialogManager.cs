using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using Microsoft.Win32.SafeHandles;

public class DialogManager : MonoBehaviour
{
    private static DialogManager instance;

	[SerializeField] QuestController _questController;

	[Header("Dialog UI")]
	[SerializeField] private GameObject _dialogPanel;
	[SerializeField] private TextMeshProUGUI _dialogText;

	[SerializeField] private GameObject[] _choices;
	private TextMeshProUGUI[] _choiceTexts;

	private Story _currentStory;
	public bool _dialogIsPlaying { get; private set; }
	
	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("Singletone is not single!!!");
		}
		instance = this;

		_dialogIsPlaying = false;
		_dialogPanel.SetActive(false);



		_choiceTexts = new TextMeshProUGUI[_choices.Length];
		int index = 0;
		foreach(GameObject choice in _choices)
		{
			_choiceTexts[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
			index++;
		}
	}

	public static DialogManager GetInstance()
	{
		return instance;
	}

	private void Update()
	{
		if (!_dialogIsPlaying)
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			ContinueDialog();
		}
	}

	public void EnterDialogMode(TextAsset inkJSON)
	{
		_currentStory = new Story(inkJSON.text);
		_dialogIsPlaying = true;
		_dialogPanel.SetActive(true);

		ContinueDialog();
	}

	private void ExitDialogMode()
	{
		_dialogIsPlaying = false;
		_dialogPanel.SetActive(false);
		_dialogText.text = "";
	}

	private void ContinueDialog()
	{
		if (_currentStory.canContinue)
		{
			_dialogText.text = _currentStory.Continue();
			DisplayChoices();
		}
		else
		{
			ExitDialogMode();
		}
	}

	private void DisplayChoices()
	{
		List<Choice> currentChoices = _currentStory.currentChoices;

		if (currentChoices.Count > _choices.Length)
		{
			Debug.LogError("Сейчас интерфейс поддерживает только три варианта ответа");
			return;
		}

		int index = 0;

		foreach(Choice choice in currentChoices)
		{
			_choices[index].gameObject.SetActive(true);
			_choiceTexts[index].text = choice.text;
			index++;
		}

		for (int i = index; i < _choices.Length; i++)
		{
			_choices[i].gameObject.SetActive(false);
		}
	}

	public void MakeChoice(int choiceIndex)
	{
		print(choiceIndex);
		_currentStory.ChooseChoiceIndex(choiceIndex);
		ContinueDialog();
		_questController.UpdateQuestStage(1, choiceIndex);
	}
}
