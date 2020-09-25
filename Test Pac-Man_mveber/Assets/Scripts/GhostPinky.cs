using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Describes specifically the moving behaviour of the pink ghost aka Pinky
public class GhostPinky : GhostController
{
    public Vector3 restPosition;        // The position it tries to reach when not chasing Pac-Man
    public float chaseOffset;           // Distance between Pinky and Pac-Man for Pinky to try and stay ahead in its chase 

    // When chasing Pac-Man, Blinky tries to fing a path ahead of by chaseOffset
    public override void ChasePacMan()
    {
        // Checks user input to determine Pinky's offset direction
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 offset = new Vector3(horizontal, 0, vertical);

        // Offsets Pinky by chaseOffset in the direction Pac-Man is going (which is the direction the user is inputing)
        CharacterController pacman = FindObjectOfType<CharacterController>();
        GetComponent<NavMeshAgent>().SetDestination(pacman.gameObject.transform.position + chaseOffset * offset);
    }

    // When not chasing Pac-Man, Pinky tries to reach its rest position
    public override void Scatter()
    {
        GetComponent<NavMeshAgent>().SetDestination(restPosition);
    }

    // When running away from Pac-Man, Pinky scatters
    public override void Frighten()
    {
        Scatter();
    }
}
