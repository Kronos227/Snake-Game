using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    void Start()
    {
        RandomizePosition();

    }

    // Update is called once per frame
    void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        //this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        transform.position = new Vector2(x, y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Head")
        {
            RandomizePosition();
        }
    }
}
