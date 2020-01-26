using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    private bool isHolding;
    private SpriteRenderer spriteRenderer;

    public bool IsHolding { get => isHolding; set => isHolding = value; }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
                if(temp.Cargo != null && temp.Cargo != this) temp.Cargo.IsHolding = false;
                temp.CargoPos = transform.position;
                temp.Cargo = this;
                isHolding = true;
            }
        }
    }

    public void ChangeSprite(bool result) {
        
    }
}
