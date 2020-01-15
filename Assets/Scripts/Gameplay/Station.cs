using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private List<Vector3> availablePositions = new List<Vector3>();
    [SerializeField] private List<char> letters = new List<char>();
    [SerializeField] private List<GameObject> charGO = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int start = -6;

        for (int i = 0; i < letters.Count; i++)
        {            
            if(i%2 == 0)
            {
                Vector3 tempPos = new Vector3(start, 3, 0);
                Character tempChar = charGO[i].GetComponent<Character>();
                availablePositions.Add(tempPos);
                tempChar.StationPos = tempPos;
                tempChar.Letter = letters[i];
                charGO[i].SetActive(true);
            }
            else
            {
                Vector3 tempPos = new Vector3(start, 0, 0);
                Character tempChar = charGO[i].GetComponent<Character>();
                availablePositions.Add(tempPos);
                tempChar.StationPos = tempPos;
                tempChar.Letter = letters[i];
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
}
