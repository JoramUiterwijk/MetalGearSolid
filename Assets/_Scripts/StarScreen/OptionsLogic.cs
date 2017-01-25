using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OptionsUIhandler))]
public class OptionsLogic : MonoBehaviour 
{
	[SerializeField]private Button[] buttons;
	[SerializeField]private ButtonHoverLogic[] buttonLogic;
	[SerializeField]private StarScreenUIHandler startScreen;
	private HandleButtons qualityButtons;
	private OptionsUIhandler ui;
	private volumeLogic volume;
	private SaveProperties save;

	private void Start()
	{
		setReferences ();
		setButtonListeners ();
	}

	private void setReferences()
	{
		ui = GetComponent<OptionsUIhandler> ();
		volume = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<volumeLogic> ();
		qualityButtons = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HandleButtons> ();
		save = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<SaveProperties> ();
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			back ();
		}
	}

	private void setButtonListeners()
	{
		buttons [0].onClick.AddListener (delegate()
		{
			buttonLogic[0].enabled=false;
			buttonLogic[1].selectButton(0);
			buttonLogic[1].enabled=false;
			ui.enablePanel(0);
			volume.selectFirstItem();
		});

		buttons [1].onClick.AddListener (delegate()
		{
			buttonLogic[0].enabled=false;
			buttonLogic[1].selectButton(1);
			buttonLogic[1].enabled=false;
			ui.enablePanel(1);
			qualityButtons.selectFirstButton();
		});

		buttons [2].onClick.AddListener (delegate()
		{
			buttonLogic[0].enabled=true;
			buttonLogic[0].selectButton(0);
			buttonLogic[1].enabled=false;
			startScreen.disableScreen(2);
			startScreen.enableScreen(0);
		});
			
		buttons [3].onClick.AddListener (delegate(){save.Save();});
	}

	private void back()
	{
		ui.hidePanel (0,true);
		buttonLogic [1].enabled = true;
		buttonLogic [1].selectButton (0);
	}
}
