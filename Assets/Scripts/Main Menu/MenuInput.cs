using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    public GameObject quitPanel;

    [SerializeField]
    private GameObject basePanel;
    [SerializeField]
    private GameObject activeObject;
    private bool isActivating = false;
    private Stack panelStack = new Stack();    

    private void Start() {
        panelStack.Push(basePanel);
        activeObject = basePanel;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if((GameObject)panelStack.Peek() != basePanel && activeObject != null) {
                //Deactivate();
                if(activeObject.GetComponent<Animator>() != null)
                {
                    activeObject.GetComponent<Animator>().SetTrigger("Start");
                }
                PopFromStack();
            }

            else if(!quitPanel.activeInHierarchy)
            {
                quitPanel.SetActive(true);
            }
        }        
    }

    public void Activate(GameObject activated) {
        activeObject.SetActive(false);
        panelStack.Push(activated);
        activeObject = (GameObject)panelStack.Peek();
        activeObject.SetActive(true);
       // activeObject = (GameObject)panelStack.Peek();
        if(activeObject.GetComponent<Animator>() != null) {
            activeObject.GetComponent<Animator>().SetBool("Open", true);
        }      
        //Debug.Log(activeObject);
    }

    public void ActivateOnly(GameObject activated) {
        //activeObject.SetActive(false);
        panelStack.Push(activated);
        activeObject = (GameObject)panelStack.Peek();
        if(activeObject.GetComponent<Animator>() != null) {
            activeObject.GetComponent<Animator>().SetBool("Open", true);
        }
        //activeObject.SetActive(true);
        //Debug.Log(activeObject);
    }

    public void Traceback(int count) {
        activeObject.SetActive(false);
        for (int i = 0; i < count; i++)
        {
            panelStack.Pop();
        }
        activeObject = (GameObject)panelStack.Peek();
        if(activeObject.GetComponent<Animator>() != null) {
            activeObject.GetComponent<Animator>().SetBool("Open", true);
        }      
        activeObject.SetActive(true);
    }

    public void Deactivate() {
        if (activeObject.GetComponent<Animator>() != null)
        {
            activeObject.GetComponent<Animator>().SetBool("Open", false);
        }
        //activeObject.SetActive(false);
        panelStack.Pop();
        activeObject = (GameObject)panelStack.Peek();         
        //activeObject.SetActive(true);
    }

    public void PushToStack(GameObject pushed)
    {
        panelStack.Push(pushed);
        activeObject = (GameObject)panelStack.Peek();
    }

    public void PopFromStack()
    {
        panelStack.Pop();
        activeObject = (GameObject)panelStack.Peek();
    }
}
