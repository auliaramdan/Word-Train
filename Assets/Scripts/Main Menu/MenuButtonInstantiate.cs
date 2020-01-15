using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonInstantiate : MonoBehaviour {

	public GameObject targetObject, parentObject;

	Quit quit;

	private void Start() {
		quit = GameObject.FindObjectOfType<Quit>();
	}

	public void Activate() {
		
		GameObject newPanel = Instantiate(targetObject, parentObject.transform);
		if(quit != null)
				quit.activePanels.Push(newPanel);
	}

	public void DestroyObject() {
		if(targetObject.GetComponent<Animator>() != null)	targetObject.GetComponent<Animator>().SetTrigger("Quit");
		Destroy(targetObject, 1.2f);
	}

	public void DestroyObject(GameObject targetedObject) {
		if(targetedObject.GetComponent<Animator>() != null)	targetedObject.GetComponent<Animator>().SetTrigger("Quit");
		if(quit != null)
			quit.activePanels.Pop();
		Destroy(targetedObject, 1.2f);
	}
}