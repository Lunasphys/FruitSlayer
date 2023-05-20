using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FruitPosition : MonoBehaviour
{
    // Permet de positionner l'objet 2D Par rapport au fond sur l'axe Z
    
    public Transform Background;
    void Start()
    {
        if (Background != null)
        {
            Vector3 position = transform.position;
            position.z = Background.position.z; 
            transform.position = position;
            
        }
        else
        {
            Debug.LogWarning("Aucun objet de fond n'est attribué au script PositionSprite.");
        }
    }

    
}
