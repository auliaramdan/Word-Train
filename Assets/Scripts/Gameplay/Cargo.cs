using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] private Sprite correctSprite, wrongSprite;
    private bool isHolding;
    private SpriteRenderer spriteRenderer;
    private Sprite defaultSprite;

    public bool IsHolding { get => isHolding; set => isHolding = value; }
    public int Answer{get; set;}

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        
        isHolding = false;
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
        StartCoroutine(CheckCargo(result));
    }

    private IEnumerator CheckCargo(bool result) {
        spriteRenderer.sprite = result? correctSprite : wrongSprite;
        yield return new WaitForSeconds(3);
        spriteRenderer.sprite = defaultSprite;
    }
}
