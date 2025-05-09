using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int obstacleColorNumber;

    //Player.cs
    public int PlayerColorNumber;

    // Start is called before the first frame update
    void Start()
    {
        obstacleColorNumber = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
            player.PlayerHpChange(-10f);
    }
}
