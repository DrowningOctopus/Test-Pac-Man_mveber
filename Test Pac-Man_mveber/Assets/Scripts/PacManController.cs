using UnityEngine;

// This script regulates the behaviour of the PacManCharacter that is controlled by the player using the gaming arrows or the keyboard QWERTY controls
public class PacManController : MonoBehaviour
{
    public float speed = 2f;                        // Pac-Man's speed
    CharacterController pacmanCharacter;            // Pac-Man's CharacterController

    // Start is called before the first frame update
    void Start()
    {
        // PacMan is initialized as the controllable character
        pacmanCharacter = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Retrieving the user inputs
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horizontal, 0, vertical);

        // Moving PacMan according to user inputs
        pacmanCharacter.Move(move * Time.deltaTime * speed);
    }

    // OnTriggerEnter is called when Pac-Man enters the space of a bloc with the isTrigger property, the collider
    void OnTriggerEnter(Collider otherObject)
    {
        // Getting the GameObject that was collided
        GameObject collider = otherObject.gameObject;

        // Checking the nature of the collider to determine Pac-Man'behaviour
        if (collider.GetComponent(typeof(GhostController)))
        {
            GhostController collidedGhost = collider.GetComponent(typeof(GhostController)) as GhostController;
            CollideWithGhost(collidedGhost);
        }
        if (collider.GetComponent(typeof(Consumable)) != null) 
        {
            Consumable consumed = collider.GetComponent(typeof(Consumable)) as Consumable;
            CollideWithConsumable(consumed);
        }
        if (collider.GetComponent(typeof(Teleport)) != null)
        {
            Teleport teleportPortal = collider.GetComponent(typeof(Teleport)) as Teleport;
            CollideWithTeleport(teleportPortal);
        }
    }

    // When collided with a GhostController component, we try to catch PacMan using the CatchPacMan() function of the GhostController
    void CollideWithGhost(GhostController ghost)
    {
        ghost.CatchPacMan();
    }

    // When collided with a Consumable component, we consume the object using the IsConsumed() function of the Consumable
    void CollideWithConsumable(Consumable consumed)
    {
        Behaviour checkActiveStatus = (Behaviour)consumed;
        if (checkActiveStatus.enabled)
        {
            consumed.IsConsumed();
        }
    }

    // When collided with a Teleport component, we teleport Pac-Man using the TeleportPacMAn() function of the Teleport
    void CollideWithTeleport(Teleport portal)
    {
        portal.TeleportPacMan(pacmanCharacter.gameObject);
    }
}
