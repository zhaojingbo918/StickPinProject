using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHead : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinHead")
        {
            Debug.Log("与PinHead发生碰撞");
            var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.StopGame();
        }
        else
        {
            Debug.Log("与ffffffffffff发生碰撞");
        }
    }

}
