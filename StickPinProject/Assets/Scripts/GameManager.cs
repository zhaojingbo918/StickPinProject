using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Transform startPoint;
    private Transform spawnPoint;
    public GameObject PinPrefab;
    public Pin currentPin;
    // Use this for initialization
    void Start()
    {
        startPoint = GameObject.Find("StartPoint").transform;
        spawnPoint = GameObject.Find("SpawnPoint").transform;

        this.SpawnPin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPin.Flay();
            this.SpawnPin();
        }
    }


    public void SpawnPin()
    {
        Debug.Log("--------spawnPin----------");
        currentPin = GameObject.Instantiate(PinPrefab, spawnPoint.position, PinPrefab.transform.rotation).GetComponent<Pin>();
    }
}
