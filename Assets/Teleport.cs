using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 newPosition;
    public Vector3 newMonsterPosition;
    public GameObject monster;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = newPosition;
            monster.transform.position = newMonsterPosition;
        }
    }
}
