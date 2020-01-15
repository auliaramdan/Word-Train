using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    private bool isHolding;

    public bool IsHolding { get => isHolding; set => isHolding = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Character")
        {
            if(!isHolding)
            {
                Character temp = other.GetComponent<Character>();
                temp.CargoPos = transform.position;
                temp.Cargo = this;
                isHolding = true;
            }
        }
    }
}
