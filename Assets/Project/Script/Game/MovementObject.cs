using UnityEngine;

public class MovementObject : MonoBehaviour
{
    [Header("Speed variable")]
    public float minXSpeed;
    public float maxXSpeed;
    public float minYSpeed;
    public float maxYSpeed;

    private bool isVisible;

    void Start()
    {
        // Permet de propulser les fruits
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(minXSpeed, maxXSpeed), Random.Range(minYSpeed, maxYSpeed));

        // Vérifie si l'objet est visible à l'écran
        isVisible = CheckVisibility();
    }

    void Update()
    {
        // Si l'objet est invisible et devenu visible, met à jour le statut
        if (!isVisible && CheckVisibility())
        {
            isVisible = true;
        }

        // Si l'objet est visible et complètement sorti de l'écran, détruit le GameObject
        if (isVisible && IsFullyOutside())
        {
            Destroy(gameObject);
        }
    }

    bool CheckVisibility()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        float margin = 0.1f; // Marge pour éviter une destruction prématurée

        return (viewportPosition.x >= -margin && viewportPosition.x <= 1 + margin && viewportPosition.y >= -margin && viewportPosition.y <= 1 + margin);
    }

    bool IsFullyOutside()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        float margin = 0.1f; // Marge pour éviter une destruction prématurée

        return (viewportPosition.x < -margin || viewportPosition.x > 1 + margin || viewportPosition.y < -margin || viewportPosition.y > 1 + margin);
    }
}