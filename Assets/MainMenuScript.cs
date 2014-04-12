using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	private GUISkin MainMenuSkin = new GUISkin();
	private Texture2D logoTexture;

	private Rect startBtnRect;
	private Rect exitBtnRect;

	private void createMainMenu() {
		startBtnRect = new Rect(55, 100, 180, 40);
		exitBtnRect = new Rect(55, 150, 180, 40);

		//layout start
		GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 200));
		
		//the menu background box
		GUI.Box(new Rect(0, 0, 300, 200), "");
		
		//logo picture
		GUI.Label(new Rect(15, 10, 300, 68), logoTexture);

		//////////////////////////////////////
		// Check for mouse clicking events. //
		//////////////////////////////////////
		if(GUI.Button(startBtnRect, "Start game")) {
			MainMenuScript script = (MainMenuScript) GetComponent("MainMenuScript");
			Debug.Log("Game starting...");
			Application.LoadLevel("SpeculumMaximus");
			script.enabled = false;
		}
		//quit button
		if(GUI.Button(exitBtnRect, "Quit")) {
			Application.Quit();
		}
		
		//layout end
		GUI.EndGroup(); 
	}

	private void OnGUI() {
		//load GUI skin
		GUI.skin = MainMenuSkin;
		
		//execute theFirstMenu function
		createMainMenu();
	}
}