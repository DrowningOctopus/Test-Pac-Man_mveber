using System;
using UnityEngine;
using UnityEngine.AI;

public class GhostBlinky : GhostController
{
    public Vector3 restPosition;
    public Material fearColor;
    NavMeshAgent blinky;
    CharacterController pacman;
    ScoreManager scoreManager;
    Material ghostColor;

    // Start is called before the first frame update
    void Start()
    {
        blinky = GetComponent<NavMeshAgent>();
        pacman = FindObjectOfType<CharacterController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        ghostColor = this.GetComponent<Renderer>().material;
    }

    public override void ChasePacMan()
    {
        blinky.SetDestination(pacman.gameObject.transform.position);
    }

    public override void Scatter()
    {
        blinky.SetDestination(restPosition);
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
