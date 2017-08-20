using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface OnClickListener {
    void onClick();
}

/*
** Put this Object on the vive left and/or right controller then set the InputController interface implementation.
*/
public class AnyClick : MonoBehaviour
{
    private static ulong TRIGGER = SteamVR_Controller.ButtonMask.Trigger;
    private static ulong GRIPS = SteamVR_Controller.ButtonMask.Grip;
    private static ulong TOUCHPAD = SteamVR_Controller.ButtonMask.Touchpad;

    public GameObject clickListenerWrapper;
    public SteamVR_TrackedObject viveController;
    private OnClickListener clickListener;
    private SteamVR_Controller.Device device;

    private void Start()
    {
        clickListener = clickListenerWrapper.GetComponent<OnClickListener>();
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)viveController.index);
        handleGrips();
        handleTriggers();
        handleTouchpads();
    }

    private void handleGrips()
    {
        if (device.GetPress(GRIPS))
        {
            clickListener.onClick();
        }
    }

    private void handleTriggers()
    {
        if (device.GetPressUp(TRIGGER))
        {
            clickListener.onClick();
        }
    }

    //Either navigation or menu activation
    private void handleTouchpads()
    {
        if (device.GetTouch(TOUCHPAD))
        {
           // clickListener.onClick();
        }
    }

    //Collision detection with some objects
    void OnTriggerEnter(Collider collider)
    {
        InteractableBase collidingItem = collider.GetComponent<InteractableBase>();
        if (collidingItem)
        {
            clickListener.onClick();
        }
    }
 
}
