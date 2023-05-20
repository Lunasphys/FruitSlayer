using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Target variable")]
    public GameObject prefab;
    
    [Header("Gameplay")]
    public float interval;
    public float Y;
    
    [Header("Visuals")]
    public Sprite[] sprites;
    
    void Start()
    {
        InvokeRepeating("Spawns", interval, interval);
    }

    private void Spawns()
    {
        // Permet de créer un objet
        GameObject clone = Instantiate(prefab);
        
        // Récupère la position X de l'objet de fond (Background)
        // Récupère la position X de l'objet de fond (Background)
        float minX = 400;
        float maxX = 500;

        // Génère une position X aléatoire entre les positions min et max de X du fond
        float randomX = Random.Range(minX, maxX);
        
        // Permet de positionner l'objet
        clone.transform.position = new Vector3(
            randomX,
            Y,
            260
        );
        clone.transform.SetParent(transform);
            
        // Permet de changer le sprite de l'objet
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        clone.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
