using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StepManagerP3 : MonoBehaviour
{
    [Header("Main Parts")]
    [Header("Machine1")]
    public GameObject ChipChecker1SnapPointObject;
    public GameObject ChipChecker1Script;
    public ChipCheckerSnapPoint1 checkerSnapPoint1;
    public ChipChecker1Machine chipChecker1Machine;
    public XRGrabInteractable FrontCoverGrab;
    public XRGrabInteractable ButtonsGrab;
    public GameObject ButtonSnapPointObject;
    public ButtonSnapPoint buttonSnapPoint;
    public XRGrabInteractable RubberCoverGrab;
    public GameObject RubberSnapPointObject;
    public RubberCoverSnapPoint rubberCoverSnapPoint;
    public GameObject WaitingTraySnapPointObject;
    public WaitingTraySnapPoint waitingTraySnapPoint;
    public XRGrabInteractable ChipOnChecker1Grab;
     


    [Header("Highlighter")]
    [Header("Machine1")]
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Tooltip1;
    public StepWiseHighlighter ChipInRack;
    public GameObject SphereObjectChipInChecker1;
    public StepWiseHighlighter SphereHighlightChipInChecker1;
    public StepWiseHighlighter FrontCoverInRackHighlight;
    public GameObject Arrow3;
    public GameObject Arrow4;
    public StepWiseHighlighter ButtonInRackHighlight;
    public GameObject SphereObjectButtonInFrontCover;
    public StepWiseHighlighter SphereHighlightButtonInFrontCover;
    public GameObject Arrow5;
    public StepWiseHighlighter RubberCoverInRackHighlight;
    public GameObject SphereObjectRubberInFrontCover;
    public StepWiseHighlighter SphereHighlightRubberInFrontCover;
    public GameObject Arrow6;
    public GameObject Arrow7;
    public GameObject Tooltip2;
    public StepWiseHighlighter ChipOnChecker1Highlight;
    public GameObject Arrow8;


    void Start()
    {
        ChipInRack.Highlight();
        checkerSnapPoint1.ChipSnapped += ChipSnappedToChecker1;
        chipChecker1Machine.onReachedDesired += Checker1Closed;
        buttonSnapPoint.ButtonSnapped += ButtonSnapped;
        rubberCoverSnapPoint.RubberCoverSnapped += RubberCoverSnapped;
        waitingTraySnapPoint.KeyOnWaitingTraySnapped += KeySnappedToWaitingTray;
        chipChecker1Machine.onReachedOriginal += Checker1Opened;
    }
    public void ChipGrabbedFromRack()
    {
        Arrow1.SetActive(false);
        Arrow2.SetActive(true);
        ChipChecker1SnapPointObject.SetActive(true); // chip on checker1 snappoint script attached object
        SphereObjectChipInChecker1.SetActive(true); // Chip place highlighter object 
        SphereHighlightChipInChecker1.Highlight();
    }
    public void ChipSnappedToChecker1()
    {
        Arrow2.SetActive(false);
        Tooltip1.SetActive(true);
        SphereObjectChipInChecker1.SetActive(false);
        ChipChecker1Script.SetActive(true); // checker 1 moving handle script
    }
    public void Checker1Closed()
    {
        Arrow3.SetActive(true);
        Tooltip1.SetActive(false);
        FrontCoverInRackHighlight.Highlight();
        FrontCoverGrab.enabled = true;
    }
    public void FrontCoverGrabbed()
    {
        Arrow3.SetActive(false);
        Arrow4.SetActive(true);
        ButtonInRackHighlight.Highlight();
        ButtonsGrab.enabled = true;
    }
    public void ButtonGrabbed()
    {
        Arrow4.SetActive(false);
        SphereObjectButtonInFrontCover.SetActive(true);
        SphereHighlightButtonInFrontCover.Highlight();
        ButtonSnapPointObject.SetActive(true);
    }
    public void ButtonSnapped()
    {
        SphereObjectButtonInFrontCover.SetActive(false);
        Arrow5.SetActive(true);
        RubberCoverInRackHighlight.Highlight();
        RubberCoverGrab.enabled = true;
    }
    public void RubberCoverGrabbed()
    {
        Arrow5.SetActive(false);
        SphereObjectRubberInFrontCover.SetActive(true);
        SphereHighlightRubberInFrontCover.Highlight();
        RubberSnapPointObject.SetActive(true );
    }
    public void RubberCoverSnapped()
    {
        SphereObjectRubberInFrontCover.SetActive(false);
        Arrow6.SetActive(true);
        WaitingTraySnapPointObject.SetActive(true);
    }
    public void KeySnappedToWaitingTray()
    {
        Arrow6.SetActive(false);
        chipChecker1Machine.Unlock();
        Tooltip2.SetActive(true);
        Arrow7.SetActive(true);
    }
    public void Checker1Opened()
    {
       
        Tooltip2.SetActive(false);
        ChipOnChecker1Grab.enabled = true;
        ChipOnChecker1Highlight.Highlight();
    }
    public void ChipOnChecker1Grabbed()
    {
        Arrow7.SetActive(false);
        Arrow8.SetActive(true);
    }
}
