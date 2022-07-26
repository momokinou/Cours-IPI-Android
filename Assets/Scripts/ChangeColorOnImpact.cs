using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnImpact : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Change Color");

        SpriteRenderer otherObjectRenderer = collision.collider.GetComponent<SpriteRenderer>();
        SpriteRenderer selfRenderer = this.GetComponent<SpriteRenderer>();
        selfRenderer.color = otherObjectRenderer.color;
    }

}
