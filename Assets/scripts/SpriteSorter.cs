using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public int sortingOrderBase = 5000;
    public int offset = 0;
    public bool runOnlyOnce = false;

    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y * 10 - offset);
        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
