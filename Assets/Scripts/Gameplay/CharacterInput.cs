using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    private Camera mainCam;
    private bool isHolding;
    private Character heldCharacter;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        #if UNITY_EDITOR

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Debug.DrawRay(ray.origin, ray.direction * 10);
            if(Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.tag == "Character")
                {
                    if(!isHolding)
                    {
                        heldCharacter = hit.collider.gameObject.GetComponent<Character>();
                        heldCharacter.SetHeld(true);
                        isHolding = true;
                    }
                       
                }
            }          
        }

        else if(Input.GetMouseButtonUp(0))
        {
            if(isHolding)
            {
                isHolding = false;
                heldCharacter.SetHeld(false);
                heldCharacter = null;
            }
        }


#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            //Debug.DrawRay(ray.origin, ray.direction * 10);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.tag == "Character")
                {
                    if (!isHolding)
                    {
                        heldCharacter = hit.collider.gameObject.GetComponent<Character>();
                        heldCharacter.SetHeld(true);
                        isHolding = true;
                    }

                }
            }
        }

        else if (Input.touchCount <= 0)
        {
            //Debug.Log("Put down");
            if (isHolding)
            {
                isHolding = false;
                heldCharacter.SetHeld(false);
            }
        }
#endif

    }
}