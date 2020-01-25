using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterHolder;
    [SerializeField] private string letter;
    [SerializeField] private Vector3 stationPos;

    private bool isHeld = false;
    private bool isOccupying = false;
    private Vector3 cargoPos;
    private Cargo cargo;

    public Vector3 StationPos { get => stationPos; set => stationPos = value; }
    public string Letter { get => letter; set => letter = value; }
    public bool IsOccupying { get => isOccupying; set => isOccupying = value; }
    public Vector3 CargoPos { get => cargoPos; set => cargoPos = value; }
    public Cargo Cargo { get => cargo; set => cargo = value; }

    // Start is called before the first frame update
    void Awake()
    {
        characterHolder = GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        transform.position = stationPos;
        characterHolder.text = letter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        }
    }

    public void SetHeld(bool held)
    {
        isHeld = held;
        if(!held && cargo == null)
        {
            transform.position = stationPos;
        }
        else if(!held && cargo != null)
        {
            transform.position = cargoPos;
        }
    }
}
