using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Triangle : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D triangleCollider;

    private float stayAliveTime = 10f;
    private float elapsed;
    private Renderer rend;
    public Color altColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        //change the color
        altColor.a -= (float).001;
        altColor.g += (float).01;
        altColor.b += (float).01;
        rend.material.color = altColor;
        //kill
        elapsed += Time.deltaTime;
        if (elapsed > stayAliveTime)
        {
            Destroy(gameObject);
        }
    }
}
