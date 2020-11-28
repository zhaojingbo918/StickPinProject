using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Transform startPoint;
    private Transform spawnPoint;
    public GameObject PinPrefab;
    public Pin currentPin;
    private bool isStop;
    private Camera mainCamera;
    // Use this for initialization
    void Start()
    {
        startPoint = GameObject.Find("StartPoint").transform;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        mainCamera = Camera.main;
        this.SpawnPin();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop && Input.GetMouseButtonDown(0))
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

    public void StopGame()
    {
        if (!isStop)
        {
            isStop = true;

            GameObject.Find("Circle").GetComponent<RotateSelf>().enabled = false;

            StartCoroutine(GameOverAnimation());
        }
    }


    IEnumerator GameOverAnimation()
    {
        while (true)
        {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, 5 * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 4, 5 * Time.deltaTime);
           
            if (Mathf.Abs(mainCamera.orthographicSize - 4) < 0.01f)
            {
                break;
            }
             
            yield return 0;
        }

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
