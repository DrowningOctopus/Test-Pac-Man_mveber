using System.Collections;
using UnityEngine;

public class PacManController : MonoBehaviour
{
    public float Speed = 2f;
    CharacterController PacManCharacter;

    // Start is called before the first frame update
    void Start()
    {
        // PacMan is initialized as the controllable character
        PacManCharacter = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Retrieving the user inputs
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horizontal, 0, vertical);

        // Moving PacMan according to user inputs
        PacManCharacter.Move(move * Time.deltaTime * Speed);
    }

    // OnTriggerEnter is called when Pac-Man enters the space of a bloc with the isTrigger property, the collider
    void OnTriggerEnter(Collider otherObject)
    {
        // Here we get the GameObject that was collided
        GameObject collider = otherObject.gameObject;

        // If the collider contains a IConsumable component, we consume the object using the IsConsumed() function of the IConsumable
        if (collider.GetComponent(typeof(IConsumable)) != null) 
        {
            IConsumable consumed = collider.GetComponent(typeof(IConsumable)) as IConsumable;
            consumed.IsConsumed(collider);
        }
        // If the collider contains a Teleport component, we teleport Pac-Man using the IsTeleported() function of the Teleport
        else if (collider.GetComponent(typeof(Teleport)) != null)
        {
            Teleport teleportPortal = collider.GetComponent(typeof(Teleport)) as Teleport;
            teleportPortal.TeleportPacMan(PacManCharacter.gameObject);
        }
    }
}
