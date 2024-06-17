using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> spawns;
    public GameObject enterSpawn;

    public void AssignSpawn(GameObject player) {
        foreach(GameObject spawn in spawns) {
            if(spawn.GetComponent<Spawnpoint>().isTaken == false) {
                spawn.GetComponent<Spawnpoint>().SetOwner(player);
                return;
            }
        }
        player.transform.position = new Vector3(enterSpawn.transform.position.x, enterSpawn.transform.position.y, enterSpawn.transform.position.z);
    }
    public void SpawnPlayer(GameObject player) {
        GameObject spawn = player.GetComponent<PlayerSetup>().assignedSpawn;
        player.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z);
    }
}
