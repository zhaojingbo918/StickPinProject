using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float speed = 5;
    private bool isFly;
    private bool isReach = false;
    private Transform startPoint;
    public Transform circle;
    private Vector3 targetPosition;

    private GameManager gameManager;
    // Use this for initialization
    void Start()
    {
        startPoint = GameObject.Find("StartPoint").transform;
        circle = GameObject.Find("Circle").transform;
        targetPosition = new Vector3(circle.position.x, (float)(circle.position.y - 1.1), circle.position.z);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFly == false)
        {
            if (isReach == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startPoint.position) < 0.05f)
                {
                    isReach = true;
                }
            }
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
            {
                isFly = false;
                transform.position = targetPosition;
                transform.parent = circle;
              
            }

        }
    }

    private bool hasStartedFlay;

    public void Flay()
    {
        if (hasStartedFlay)
            return;
        hasStartedFlay = true;
        isFly = true;
        isReach = true;
        Debug.Log("flay--------");
    }
}
