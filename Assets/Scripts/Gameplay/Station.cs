using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private List<Vector3> availablePositions = new List<Vector3>();
    [SerializeField] private List<string> letters = new List<string>();
    [SerializeField] private List<GameObject> charGO = new List<GameObject>();
    [SerializeField] private Level charList;

    // Start is called before the first frame update
    void Start()
    {
        int start = -6;

        for (int i = 0; i < charList.charList.Count; i++)
        {            
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
        for (int i = 0; i < charGO.Count; i++)
        {
            
        }
    }
}
