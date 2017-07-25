using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteractable : InteractableWrappedItem
{
    public GameObject playerHead;
    public GameObject platform;
    public GameObject explanation1;

    private Bounds platformBounds;
    private Vector3 playerPosition;

    new void Start()
    {
        base.Start();
        platformBounds = platform.GetComponent<BoxCollider>().bounds;
        playerPosition = playerHead.transform.position;
    }

    public override void onGrabbedBy(GameObject anchorObject, Material grabbedMaterial)
    {
        base.onGrabbedBy(anchorObject, grabbedMaterial);
    }

    public override void onDroppedBy(GameObject anchorObject)
    {
        base.onDroppedBy(anchorObject);
    }

    private void showExplanation()
    {
        explanation1.SetActive(true);
    }

    private void hideExplanation()
    {
        explanation1.SetActive(false);
    }
}
