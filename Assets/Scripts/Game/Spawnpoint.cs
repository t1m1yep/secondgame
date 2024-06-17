using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public bool isTaken = false;
    public GameObject owner;
    public void SetOwner(GameObject player) {
        owner = player;
        owner.GetComponent<PlayerSetup>().assignedSpawn = gameObject;
        isTaken = true;
    }
    public void RemoveOwner() {
        owner = null;
        isTaken = false;
    }
}
