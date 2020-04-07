using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private List<Vector3> availablePositions = new List<Vector3>();
    [SerializeField] private List<string> letters = new List<string>();
    [SerializeField] private List<GameObject> charGO = new List<GameObject>();
    [SerializeField] private Level charList;
    [SerializeField] private List<GameObject> cargo = new List<GameObject>();
    [SerializeField] private List<Level> levelList = new List<Level>();

    private List<Vector3> cargoInitialPos = new List<Vector3>();
    private int levelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cargo.Count; i++)
        {
            cargoInitialPos.Add(cargo[i].transform.position);
        }
        /*
        int start = -6;

        for (int i = 0; i < charList.charList.Count; i++)
        {
            cargo[i].SetActive(true);
            cargo[i].GetComponent<Cargo>().Answer = charList.answerList[i];

            if(i%2 == 0)
            {
                Vector3 tempPos = new Vector3(start, 3, 0);
                Character tempChar = charGO[i].GetComponent<Character>();
                availablePositions.Add(tempPos);
                tempChar.StationPos = tempPos;
                tempChar.Letter = charList.charList[i];
                charGO[i].SetActive(true);
            }
            else
            {
                Vector3 tempPos = new Vector3(start, 0, 0);
                Character tempChar = charGO[i].GetComponent<Character>();
                availablePositions.Add(tempPos);
                tempChar.StationPos = tempPos;
                tempChar.Letter = charList.charList[i];
                charGO[i].SetActive(true);
                start += 4;
            }
        }
        */
        ArrangePieces();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Character")
        {
            Character temp = other.GetComponent<Character>();
            if(temp.Cargo != null)
            {
                temp.Cargo.IsHolding = false;
                temp.Cargo = null;
            }
        }
    }

    public void CheckCargo() {
        bool done = true;
        for (int i = 0; i < charList.charList.Count; i++)
        {
            //cargo[i].GetComponent<Cargo>().ChangeSprite(charGO[i].GetComponent<Character>().Letter == charList.charList[cargo[i].GetComponent<Cargo>().Answer - 1]);
            if(charGO[i].GetComponent<Character>().Cargo != null) {
                bool result = charGO[i].GetComponent<Character>().Letter == charList.charList[charGO[i].GetComponent<Character>().Cargo.Answer - 1];
                charGO[i].GetComponent<Character>().Cargo.ChangeSprite(result);
                if(!result) done = false;
            }

                
        }
        if(done) {
            StartCoroutine(FinishTrain());
        }
    }

    private IEnumerator FinishTrain(){
        ServiceLocator.GetService<AudioManager>().Play("train");
        yield return new WaitForSeconds(1);
        for (int i = 0; i < charList.charList.Count; i++)
            {
                charGO[i].transform.SetParent(charGO[i].GetComponent<Character>().Cargo.transform);
                cargo[i].GetComponent<Animator>().SetTrigger("Finish");
            }
        
        yield return new WaitForSeconds(3);
        ServiceLocator.GetService<AudioManager>().Stop("train");
        levelIndex += levelIndex + 1 >= levelList.Count? 0 : 1;
        charList = levelList[levelIndex];
        for (int i = 0; i < cargo.Count; i++)
        {
            cargo[i].GetComponent<Animator>().SetTrigger("Restart");
        }
        for (int i = 0; i < charGO.Count; i++)
        {
            charGO[i].SetActive(false);
        }
        
        ArrangePieces();
    }

    private void ArrangePieces(){
        for (int i = 0; i < cargo.Count; i++)
        {
            cargo[i].SetActive(false);
            cargo[i].transform.position = cargoInitialPos[i];
        }

        float start = -1.74f;

        for (int i = 0; i < charList.charList.Count; i++)
        {
            charGO[i].transform.SetParent(null);
            cargo[i].SetActive(true);
            cargo[i].GetComponent<Cargo>().Answer = charList.answerList[i];

            if(i%2 == 0)
            {
                Vector3 tempPos = new Vector3(start, 0.13f, 0);
                Character tempChar = charGO[i].GetComponent<Character>();
                tempChar.Cargo = null;
                tempChar.SetHeld(false);
                availablePositions.Add(tempPos);
                tempChar.StationPos = tempPos;
                tempChar.Letter = charList.charList[i];
                charGO[i].SetActive(true);
                //start += 2.372f;
            }
            else
            {
                Vector3 tempPos = new Vector3(start, 2.282f, 0);
                Character tempChar = charGO[i].GetComponent<Character>();
                availablePositions.Add(tempPos);
                tempChar.StationPos = tempPos;
                tempChar.Cargo = null;
                tempChar.SetHeld(false);
                tempChar.Letter = charList.charList[i];
                charGO[i].SetActive(true);
                start += 2.372f;
            }
        }
    }
}
