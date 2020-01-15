using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	public MainMenu mainMenu;
	public Stack<GameObject> activePanels = new Stack<GameObject>();

	MenuButtonInstantiate menu;
	
	private void Start() {
		menu = gameObject.AddComponent(typeof(MenuButtonInstantiate)) as MenuButtonInstantiate;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(activePanels.Count > 0) {
				menu.DestroyObject(activePanels.Peek());
			}
			else {
				mainMenu.QuitGame();
			}
		}		
	}
}
