using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostPinky : MonoBehaviour, IGhostController
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
        // Check user input to determine where pinky's offset is
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 offset = new Vector3(horizontal, 0, vertical);

        // offset pinky by 4 in the direction Pac-Man is going, so by 4 in the direction the user is inputing
        pinky.SetDestination(pacman.gameObject.transform.position + 4 * offset);
    }

    public void Scatter()
    {
        pinky.SetDestination(restPosition);
    }

    public void Frighten()
    {
        Scatter();
    }

    public void SetGhostFearState(bool fearStatus)
    {
        if (fearStatus)
        {
            this.GetComponent<Renderer>().material = fearColor;
        }
        else
        {
            this.GetComponent<Renderer>().material = ghostColor;
        }
    }
}
