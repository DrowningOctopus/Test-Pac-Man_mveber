using UnityEngine;

// This script handles teleporting Pac-Man
public class Teleport : MonoBehaviour
{
    
    public GameObject destination;      // Gameobject where the Pac-Man will reappear upon teleport
    public float x_offset;              // Offset to shifting destination position on the x axis to ensure PacMan reappears outside of the collision box; it can be modified in the console for easier adjustments
    public float z_offset;              // Same for the z axis ; it is not necessary now but could become so later

    // Teleports Pac-Man
    public void TeleportPacMan(GameObject pacman)
    {
        // The teleportation coordinates are calculated from the destination and offset
        Vector3 newTeleportedPosition = new Vector3(destination.transform.position.x + x_offset, pacman.transform.position.y, destination.transform.position.z + z_offset);
        
        // PacMan is teleported to the calculated coordinates 
        pacman.transform.position = newTeleportedPosition;
    }
}
