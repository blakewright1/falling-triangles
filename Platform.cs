using UnityEngine;

public class Platform : MonoBehaviour
{
    private float stayAliveTime = 10f;
    private float elapsed;
    private Renderer rend;
    public Color altColor = Color.green;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        altColor.g += .4f;
    }
    private void FixedUpdate()
    {
        //change the color
        altColor.a -= (float).001;
        altColor.r += (float).001;
        rend.material.color = altColor;
        //kill
        elapsed += Time.deltaTime;
        if (elapsed > stayAliveTime)
        {
            Destroy(gameObject);
        }
    }
}
