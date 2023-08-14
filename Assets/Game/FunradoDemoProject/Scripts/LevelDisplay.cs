using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    public Transform characterTransform; 
    public float yOffset = 1.5f; 

    void Update()
    {      
        transform.position = characterTransform.position + Vector3.up * yOffset;
    }
}
