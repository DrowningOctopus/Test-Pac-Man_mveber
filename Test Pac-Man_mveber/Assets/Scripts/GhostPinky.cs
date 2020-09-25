using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostPinky : GhostController
{
    public Vector3 restPosition;
    public Material fearColor;
    NavMeshAgent pinky;
    CharacterController pacman;
    ScoreManager scoreManager;
    Material ghostColor;

    // Start is called before the first frame update
    void Start()
    {
        pinky = GetComponent<NavMeshAgent>();
        pacman = FindObjectOfType<CharacterController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        ghostColor = this.GetComponent<Renderer>().material;
    }

    public override void ChasePacMan()
    {
        // Check user input to determine where pinky's offset is
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 offset = new Vector3(horizontal, 0, vertical);

        // offset pinky by 4 in the direction Pac-Man is going, so by 4 in the direction the user is inputing
        pinky.SetDestination(pacman.gameObject.transform.position + 4 * offset);
    }

    public override void Scatter()
    {
        pinky.SetDestination(restPosition);
    }

    public override void Frighten()
    {
        Scatter();
    }

    public override void SetGhostFearState(bool fearStatus)
    {
        ghostFear = fearStatus;
        if (fearStatus)
        {
            Behaviour thisGhostConsumable = (Behaviour)this.GetComponentInChildren(typeof(GhostConsumable), true);
            thisGhostConsumable.enabled = true;
            this.GetComponent<Renderer>().material = fearColor;
        }
        else
        {
            this.GetComponent<Renderer>().material = ghostColor;
        }
    }
}
