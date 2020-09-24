using System;
using UnityEngine;
using UnityEngine.AI;

public class GhostBlinky : MonoBehaviour, IGhostController
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

    // Update is called once per frame
    void Update()
    {
        if (!scoreManager.IsFear())
        {
            ChasePacMan();
        }
        else
        {
            Frighten();
        }
        
    }

    public void ChasePacMan()
    {
        blinky.SetDestination(pacman.gameObject.transform.position);
    }

    public void Scatter()
    {
        blinky.SetDestination(restPosition);
    }

    public void Frighten()
    {
        Scatter();
    }

    public void SetFearColor()
    {
        this.GetComponent<Renderer>().material = fearColor;
    }

    public void SetRegularColor()
    {
        this.GetComponent<Renderer>().material = ghostColor;
    }
}
