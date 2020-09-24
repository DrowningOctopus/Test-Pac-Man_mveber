using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GhostBlinky : MonoBehaviour, IGhostController
{
    NavMeshAgent blinky;
    CharacterController pacman;

    // Start is called before the first frame update
    void Start()
    {
        blinky = GetComponent<NavMeshAgent>();
        pacman = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePacMan();
    }

    public void ChasePacMan()
    {
        blinky.SetDestination(pacman.gameObject.transform.position);
        Debug.Log(blinky.destination.x + ", " + blinky.destination.y + ", " + blinky.destination.z);
        Debug.Log(blinky.gameObject.transform.position.x + ", " + blinky.gameObject.transform.position.y + ", " + blinky.gameObject.transform.position.z);
    }
}
