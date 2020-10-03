using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 position;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(player.transform.position.x, 0,-5);
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        position = new Vector3(player.transform.position.x, 0,-5);
        transform.position = position;
    }
}
