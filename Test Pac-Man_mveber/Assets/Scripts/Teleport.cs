using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // This is the Gameobject where the Pac-Man will reappear once triggering the Teleport GameObject
    public GameObject destination;
    // This offset enables shifting the destination position on the x axis to ensure PacMan reappears outside of the collision box; it can be modified in the console for easier adjustments
    public float x_offset;
    // This offset enables shifting the destination position on the z axis to ensure PacMan reappears outside of the collision box; it can be modified in the console for easier adjustments
    public float z_offset; // It is not necessary now but could become so later

    public void TeleportPacMan(GameObject pacman)
    {
        // Here we calculate the teleportation coordinates from the destination and offset
        Vector3 newTeleportedPosition = new Vector3(destination.transform.position.x + x_offset, pacman.transform.position.y, destination.transform.position.z + z_offset);
        // Then PacMan is teleported to the calculated coordinates 
        pacman.transform.position = newTeleportedPosition;
    }
}
