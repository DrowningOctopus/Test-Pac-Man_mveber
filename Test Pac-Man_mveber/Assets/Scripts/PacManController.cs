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

        // Moving PacMan according to user inputs
        Vector3 move = new Vector3(horizontal, 0, vertical);
        PacManCharacter.Move(move * Time.deltaTime * Speed);
    }

    void OnTriggerEnter(Collider otherObject)
    {
        GameObject collider = otherObject.gameObject;
        if (collider.GetComponent(typeof(FoodConsumable)) != null) {
            FoodConsumable foodConsumed = collider.GetComponent(typeof(FoodConsumable)) as FoodConsumable;
            foodConsumed.IsConsumed(collider);
        } 
        else if (collider.GetComponent(typeof(CapsuleConsumable)) != null)
        {
            CapsuleConsumable capsuleConsumed = collider.GetComponent(typeof(CapsuleConsumable)) as CapsuleConsumable;
            capsuleConsumed.IsConsumed(collider);
        }
    }
}
