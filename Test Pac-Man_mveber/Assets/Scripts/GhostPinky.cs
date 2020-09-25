using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostPinky : GhostController
{
    public Vector3 restPosition;

    public override void ChasePacMan()
    {
        // Check user input to determine where pinky's offset is
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 offset = new Vector3(horizontal, 0, vertical);

        // offset pinky by 4 in the direction Pac-Man is going, so by 4 in the direction the user is inputing
        CharacterController pacman = FindObjectOfType<CharacterController>();
        GetComponent<NavMeshAgent>().SetDestination(pacman.gameObject.transform.position + 4 * offset);
    }

    public override void Scatter()
    {
        GetComponent<NavMeshAgent>().SetDestination(restPosition);
    }

    public override void Frighten()
    {
        Scatter();
    }

    public override void SetGhostFearState(bool fearStatus)
    {
        SetGhostFear(fearStatus);
        Behaviour thisGhostConsumable = (Behaviour)this.GetComponentInChildren(typeof(GhostConsumable), true);
        thisGhostConsumable.enabled = fearStatus;
        if (fearStatus)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = ghostColor;
        }
    }
}
