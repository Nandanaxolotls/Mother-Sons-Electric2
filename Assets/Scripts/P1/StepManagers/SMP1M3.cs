using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP1M3 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;

    public GameObject CoverInBoxSnapPointObject;
    public GameObject CoverOutBoxSphereObject;
    public StepWiseHighlighter HighlightCoverOutBoxSphereObject;
    public CoverToBackBox coverToBackBox;
    public GameObject HolderScriptObject;
    public HolderMachine holderMachine;
    public GameObject DoorScriptObject;
    public Door1 door1;
   
    public GameObject DisplayCanvasNG;
    public XRGrabInteractable GrabNGCoverFromBox;
    public GameObject NGboxSnapPointobject;
    public NGdrawer nGdrawer;
    public NG3SnapPoint nG3SnapPoint;


    void Start()
    {
        arrowActivator.ActivateObject(12);
        CoverInBoxSnapPointObject.SetActive(true);
        CoverOutBoxSphereObject.SetActive(true);
        HighlightCoverOutBoxSphereObject.Highlight();
        coverToBackBox.CoversnappedToBlackBox += CoverSnappedToBox;
        holderMachine.onReachedDesired += CoverHolded;
        door1.Door1ReachedDesired += DoorClosed;
        door1.Door1ReachedOriginal += DoorOpened;
        holderMachine.onReachedOriginal += CoverReleased;
        nGdrawer.onReachedDesired += NGBoxOpened;
        nG3SnapPoint.OnObjectActivated += NGdefectSnapped;
    }

    public void CoverSnappedToBox()
    {
        arrowActivator.DeactivateObject(12);
        CoverOutBoxSphereObject.SetActive(false);
        tooltipActivator.ActivateObject(8);
        HolderScriptObject.SetActive(true);
    }
    public void CoverHolded()
    {
        tooltipActivator.DeactivateObject(8);
        tooltipActivator.ActivateObject(9);
        arrowActivator.ActivateObject(13);
        DoorScriptObject.SetActive(true);
        DisplayCanvasNG.SetActive(true);

    }
    public void DoorClosed()
    {
        tooltipActivator.ActivateObject(10);
    }
    public void DoorOpened()
    {
        tooltipActivator.DeactivateObject(11);
        holderMachine.Unlock();
        tooltipActivator.ActivateObject(12);
    }
    public void CoverReleased()
    {
        tooltipActivator.DeactivateObject(12);
        arrowActivator.ActivateObject(14);
        GrabNGCoverFromBox.enabled = true;
    }
    public void NGCoverGrabbedFromBox()
    {
        arrowActivator.DeactivateObject(14);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(0); 
    }
    public void NGBoxOpened()
    {
        NGboxSnapPointobject.SetActive(true);
        tooltipActivator.DeactivateObject(0);
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(2);
    }
    public void NGdefectSnapped(GameObject obj)
    {
        arrowActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(1);
        nGdrawer.Unlock();
    }
    public void NGBoxClosed()
    {
        tooltipActivator.DeactivateObject(1);

    }
}

