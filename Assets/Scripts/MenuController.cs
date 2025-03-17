using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
	[SerializeField] private GameObject MainPanel;
	void Start()
    {
		DisableSettinsPanel();
	}

    public void EnableSettinsPanel()
    {
		MainPanel.SetActive(false);
		settingsPanel.SetActive(true);
	}

	public void DisableSettinsPanel()
	{
		MainPanel.SetActive(true);
		settingsPanel.SetActive(false);
	}
}
