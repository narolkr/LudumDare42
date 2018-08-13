using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShowPanels : MonoBehaviour {

	public GameObject tutorialPanel;                            //Store a reference to the Game Object tutorialPanel
    public GameObject creditPanel;                            //Store a reference to the Game Object creditPanel
    public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;                           //Store a reference to the Game Object PausePanel 
    public AudioSource clickSound;

    private GameObject activePanel;                         
    private MenuObject activePanelMenuObject;
    private EventSystem eventSystem;



    private void SetSelection(GameObject panelToSetSelected)
    {

        activePanel = panelToSetSelected;
        activePanelMenuObject = activePanel.GetComponent<MenuObject>();
        if (activePanelMenuObject != null)
        {
           // activePanelMenuObject.SetFirstSelected();
        }
    }

    public void Start()
    {
        SetSelection(menuPanel);
    }

    //Call this function to activate and display the Options panel during the main menu
    public void ShowTutorialPanel()
	{
        clickSound.Play();
        tutorialPanel.SetActive(true);
        optionsTint.SetActive(true);
        menuPanel.SetActive(false);
        SetSelection(tutorialPanel);

    }

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideTutorialPanel()
	{
        menuPanel.SetActive(true);
        tutorialPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
        clickSound.Play();
        menuPanel.SetActive (true);
        SetSelection(menuPanel);
    }

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);

	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
        clickSound.Play();
        pausePanel.SetActive (true);
		optionsTint.SetActive(true);
        SetSelection(pausePanel);
    }

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}

    public void ShowCreditPanel()
    {
        clickSound.Play();
        creditPanel.SetActive(true);
        optionsTint.SetActive(true);
        menuPanel.SetActive(false);
        SetSelection(creditPanel);

    }

    //Call this function to deactivate and hide the Options panel during the main menu
    public void HideCreditPanel()
    {
        menuPanel.SetActive(true);
        creditPanel.SetActive(false);
        optionsTint.SetActive(false);
    }
}
