using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP2TM3 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    [Header("NG BackCover")]
    public GameObject ScriptObjectMainOnPunching2SnapPoint;
    public GameObject SphereMainOnPunching2;
    public StepWiseHighlighter HighlightSphereMainOnPunching2;
    public BackCoverOnAssembly backCoverOnAssembly;
    public XRGrabInteractable GrabFrontCoverFromTray;
    public StepWiseHighlighter HighlightFrontCoverOnTray;
    public GameObject ScriptObjectNGBox;
    public NGDrawer3P2 nGDrawer;
    public GameObject NgSnapPointObject;
    public P2NG3SnapPoint p2NG3SnapPoint;
    [Header("Good BackCover ( punching defect )")]
    public XRGrabInteractable GrabGoodFrontCoverFromTray;
    public StepWiseHighlighter HighlightGoodFrontCoverOnTray;
    public GameObject FrontCoverSnapPointObjectOnPunching;
    public FrontCoverOnAssembly frontCoverOnAssembly;
    public GameObject FrontCoverCheckButton;
    public GreenButtonP2 greenButtonP2;
    public XRGrabInteractable GrabGoodFrontCoverFromAssembly;
    public GameObject SphereFrontCoverOnBackCover;
    public StepWiseHighlighter HighlightSphereFrontCoverOnBackCover;
    public GameObject ScriptObjectFrontCoverOnBackCoverSnapPoint;
    public FrontOnBackSnapPoint frontOnBackSnapPoint;
    public GameObject ScriptObjectPunchingMachineSlide;
    public PunchingSlidingScript punchingSlidingScript;
    public GameObject ScriptObjectPunchingMachineHandle;
    public PunchingMachine2 punchingMachine;
    public XRGrabInteractable GrabNGPunchedKeyFromAssembly;
    public GameObject Camera1Button;
    public GameObject Camera2Button;
    public GameObject FittingButton;
    [Header("Good 2 ")]
    public GameObject BackCoverFromMachine2;
    public XRGrabInteractable GrabBackCoverFromMachine2;
    public StepWiseHighlighter HighlightBackCoverFromMachine2;
    public GameObject ScriptObjectMainOnPunching2SnapPoint2;
    public BackCoverOnAssembly2 backCoverOnAssembly2;
    public XRGrabInteractable GrabFrontCoverFromTray2;
    public StepWiseHighlighter HighlightFrontCoverOnTray2;
    public GameObject FrontCoverSnapPointObjectOnPunching2;
    public FrontCoverOnAssembly2 frontCoverOnAssembly2;
    public XRGrabInteractable GrabGoodFrontCoverFromAssembly2;
    public GameObject ScriptObjectFrontCoverOnBackCoverSnapPoint2;
    public FrontOnBackSnapPoint2 frontOnBackSnapPoint2;
    public XRGrabInteractable GrabGoodPunchedKeyFromAssembly;
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    private int NGOpenCount = 0;
    private int NGCloseCount = 0;
    private int NgSnapCount = 0;
    private int CoverCheckerCount = 0;
    private int SliderPushed = 0;
    private int SliderPulled = 0;
    private int PunchingCount = 0;

    public enum TrainingStep
    {
        None,
        NGFrontGrabbed,
        GoodFrontGrabbed,
        FrontFromAssyGrabbed,
        RemoteFromPunchGrabbed,
        BackCoverGrabbed,
        GoodFrontGrabbed2,
        FrontFromAssyGrabbed2,
    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        arrowActivator.ActivateObject(19);
        tooltipActivator.ActivateObject(17);
        ScriptObjectMainOnPunching2SnapPoint.SetActive(true);
        SphereMainOnPunching2.SetActive(true);
        HighlightSphereMainOnPunching2.Highlight();
        backCoverOnAssembly.BackOnMachineSnapped += BackSnappedToAssembly;
        nGDrawer.onReachedDesired += OnNGDrawerOpenedDynamic;
        p2NG3SnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        nGDrawer.onReachedOriginal += OnNGDrawerClosedDynamic;
        frontCoverOnAssembly.FrontOnMachineSnapped += FrontCoverSnappedToAssebly;
        greenButtonP2.CameraChecked += OnFrontCoverCheckedDynamic;
        frontOnBackSnapPoint.FrontOnBackSnapped += FrontCoverSnappedOnBackCover;
        punchingSlidingScript.onReachedDesired += OnSliderPushedDynamic;
        punchingMachine.onReachedOriginal += OnPunchingDynamic;
        punchingSlidingScript.onReachedOriginal += OnSliderPulledDynamic;
        backCoverOnAssembly2.BackOnMachineSnapped += Back2SnappedToAssembly;
        frontCoverOnAssembly2.FrontOnMachineSnapped += FrontCoverSnappedToAssebly2;
        frontOnBackSnapPoint2.FrontOnBackSnapped += FrontCoverSnappedOnBackCover2;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 66, subTitletxt); //Now, Move to Stage 4 which is Case fitting. Align and place the Case Upper Sub Assembly onto the highlighted jig
        }
    }
    private void OnNGDrawerOpenedDynamic()
    {
        NGOpenCount++;

        Debug.Log($"Drawer opened {NGOpenCount} times");

        switch (NGOpenCount)
        {
            case 1:
                NGdrawerOpeningDone();
                break;
            case 2:
                NGdrawerOpeningDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDefectSnappedToNGDynamic(GameObject obj)
    {
        NgSnapCount++;
        Debug.Log($"[{NgSnapCount}] Received event: {obj.name} just activated!");

        switch (NgSnapCount)
        {
            case 1:
                ScratchedFrontCoverSnappedToNGBox(obj);
                break;

            case 2:
                NotFittedCorrectlyMainKeySnappedToNGBox(obj);
                break;

            case 3:
                //PinBentAfterPunching(obj);
                break;

            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    private void OnNGDrawerClosedDynamic()
    {
        NGCloseCount++;

        Debug.Log($"Drawer opened {NGCloseCount} times");

        switch (NGCloseCount)
        {
            case 1:
                NGdrawerClosingDone();
                break;
            case 2:
                NGdrawerClosingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnFrontCoverCheckedDynamic()
    {
        CoverCheckerCount++;

        Debug.Log($"Drawer opened {CoverCheckerCount} times");

        switch (CoverCheckerCount)
        {
            case 1:
                GreenButtonPressingDone();
                break;
            case 2:
                GreenButtonPressingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnSliderPushedDynamic()
    {
        SliderPushed++;

        Debug.Log($"Drawer opened {SliderPushed} times");

        switch (SliderPushed)
        {
            case 1:
                SlidingDone();
                break;
            case 2:
                SlidingDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnSliderPulledDynamic()
    {
        SliderPulled++;

        Debug.Log($"Drawer opened {SliderPulled} times");

        switch (SliderPulled)
        {
            case 1:
                SlidingOutDone();
                break;
            case 2:
                SlidingOutDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnPunchingDynamic()
    {
        PunchingCount++;

        Debug.Log($"Drawer opened {PunchingCount} times");

        switch (PunchingCount)
        {
            case 1:
                PunchingProcessDone();
                break;
            case 2:
                PunchingProcessDone2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    public void BackSnappedToAssembly()
    {
        arrowActivator.DeactivateObject(19);
        tooltipActivator.DeactivateObject(17);
        SphereMainOnPunching2.SetActive(false);
        arrowActivator.ActivateObject(20);
        GrabFrontCoverFromTray.enabled = true;
        HighlightFrontCoverOnTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 67, subTitletxt); //Pick Case Lower Sub Assembly from tray using left hand
        }
    }
    public void GrabbedFrontCoverFromTray()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.NGFrontGrabbed;
        arrowActivator.DeactivateObject(20);
        tooltipActivator.ActivateObject(18);
        tooltipActivator.ActivateObject(19);
        arrowActivator.ActivateObject(21);
        ScriptObjectNGBox.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 68, subTitletxt); //It is a NG child part so put this Case Upper Sub Assembly in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 69, subTitletxt, 4.2f)); // Open the NG box
        }
    }
    private void NGdrawerOpeningDone()
    {
        NGdrawerOpened();
    }
    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(19);
        arrowActivator.DeactivateObject(21);
        arrowActivator.ActivateObject(22);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 70, subTitletxt); //Place NG Case Upper Sub Assembly in the NG box
        }

    }
    public void ScratchedFrontCoverSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(22);
        tooltipActivator.ActivateObject(20);
        nGDrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 71, subTitletxt); //Close the NG box
        }
    }
    private void NGdrawerClosingDone()
    {
        NGdrawerClosed();
    }
    public void NGdrawerClosed()
    {
        arrowActivator.ActivateObject(23);
        NgSnapPointObject.SetActive(false);
        GrabGoodFrontCoverFromTray.enabled = true;
        HighlightGoodFrontCoverOnTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 72, subTitletxt); //Now pick another Case Lower Sub Assembly from tray using left hand
        }
    }
    public void GrabbedGoodFrontCoverFromTray()
    {
        if (currentStep != TrainingStep.NGFrontGrabbed)
            return;

        currentStep = TrainingStep.GoodFrontGrabbed;
        arrowActivator.DeactivateObject(23);
        tooltipActivator.ActivateObject(39);
        arrowActivator.ActivateObject(24);
        FrontCoverSnapPointObjectOnPunching.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 73, subTitletxt); //Place it on the jig as highlighted
        }

    }
    public void FrontCoverSnappedToAssebly()
    {
        tooltipActivator.DeactivateObject(39);
        arrowActivator.DeactivateObject(24);
        tooltipActivator.ActivateObject(22);
        FrontCoverCheckButton.SetActive(true);
        greenButtonP2.FrontCoverSnapped();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 74, subTitletxt); //Press the button on right to start the process and Wait for the Result on monitor screen
        }
    }
    private void GreenButtonPressingDone()
    {
        GreenButtonPressed();
    }
    public void GreenButtonPressed()
    {
        tooltipActivator.DeactivateObject(22);
        GrabGoodFrontCoverFromAssembly.enabled = true;
        arrowActivator.ActivateObject(24);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 75, subTitletxt); //Pick Case Lower Sub Assembly from jig 
        }

    }
    public void GrabbedFrontCoverFromAssmbly()
    {
        if (currentStep != TrainingStep.GoodFrontGrabbed)
            return;

        currentStep = TrainingStep.FrontFromAssyGrabbed;
        arrowActivator.DeactivateObject(24);
        SphereFrontCoverOnBackCover.SetActive(true);
        HighlightSphereFrontCoverOnBackCover.Highlight();
        ScriptObjectFrontCoverOnBackCoverSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 76, subTitletxt); //Place it on the Case Upper Sub Assembly as highlighted
        }
    }
    public void FrontCoverSnappedOnBackCover()
    {
        SphereFrontCoverOnBackCover.SetActive(false);
        tooltipActivator.ActivateObject(37);
        ScriptObjectPunchingMachineSlide.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 77, subTitletxt); //Push the jig forward
        }
    }
    private void SlidingDone()
    {
        SliderReached();
    }
    public void SliderReached()
    {
        tooltipActivator.DeactivateObject(37);
        ScriptObjectPunchingMachineHandle.SetActive(true);
        tooltipActivator.ActivateObject(23);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 78, subTitletxt); //Pull the lever to press the Case Lower Sub Assy into the Case Upper Sub Assy
        }
    }

    private void PunchingProcessDone()
    {
        PunchingDone();
    }
    public void PunchingDone()
    {
        tooltipActivator.DeactivateObject(23);
        tooltipActivator.ActivateObject(38);
        punchingSlidingScript.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 79, subTitletxt); //Pull the jig outward
        }
    }
    private void SlidingOutDone()
    {
        SliderPulledOut();
    }
    public void SliderPulledOut()
    {
        tooltipActivator.DeactivateObject(38);
        GrabNGPunchedKeyFromAssembly.enabled = true;
        arrowActivator.ActivateObject(19);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 80, subTitletxt); //Pick Remocon from jig using left hand
        }
    }

    public void GrabbedMainKeyFromAssembly()
    {
        if (currentStep != TrainingStep.FrontFromAssyGrabbed)
            return;

        currentStep = TrainingStep.RemoteFromPunchGrabbed;
        arrowActivator.DeactivateObject(19);
        tooltipActivator.ActivateObject(24);
        tooltipActivator.ActivateObject(19);
        arrowActivator.ActivateObject(21);
        ScriptObjectNGBox.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 81, subTitletxt); //It is a NG child part so put this Remocon in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 82, subTitletxt, 4.2f)); // Open the NG box
        }
    }
    private void NGdrawerOpeningDone2()
    {
        NGdrawerOpened2();
    }
    public void NGdrawerOpened2()
    {
        tooltipActivator.DeactivateObject(19);
        arrowActivator.DeactivateObject(21);
        arrowActivator.ActivateObject(22);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 83, subTitletxt); //Place NG Remocon in the NG box
        }
    }
    public void NotFittedCorrectlyMainKeySnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(22);
        tooltipActivator.ActivateObject(20);
        nGDrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 84, subTitletxt); //Close the NG box
        }
    }
    private void NGdrawerClosingDone2()
    {
        NGdrawerClosed2();
    }
    public void NGdrawerClosed2()
    {
        arrowActivator.ActivateObject(16);
        BackCoverFromMachine2.SetActive(true);
        GrabBackCoverFromMachine2.enabled = true;
        HighlightBackCoverFromMachine2.Highlight();
        FittingButton.SetActive(false);
        Camera1Button.SetActive(false);
        Camera2Button.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 85, subTitletxt); //Now pick another final Case Upper Sub Assembly child part of stage 3 on pressing machine using left hand
        }
    }
    public void GrabbedBackCoverFromMachine2()
    {
        if (currentStep != TrainingStep.RemoteFromPunchGrabbed)
            return;

        currentStep = TrainingStep.BackCoverGrabbed;
        arrowActivator.DeactivateObject(16);
        arrowActivator.ActivateObject(19);
        tooltipActivator.ActivateObject(17);
        ScriptObjectMainOnPunching2SnapPoint2.SetActive(true);
        SphereMainOnPunching2.SetActive(true);
        HighlightSphereMainOnPunching2.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 86, subTitletxt); //Now, Move to Stage 4 which is Case fitting. Align and place the Case Upper Sub Assembly onto the highlighted jig
        }
    }
    public void Back2SnappedToAssembly()
    {
        arrowActivator.DeactivateObject(19);
        tooltipActivator.DeactivateObject(17);
        SphereMainOnPunching2.SetActive(false);
        arrowActivator.ActivateObject(25);
        GrabFrontCoverFromTray2.enabled = true;
        HighlightFrontCoverOnTray2.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 87, subTitletxt); //Pick Case Lower Sub Assembly from tray using left hand
        }
    }
    public void GrabbedFrontCoverFromTray2()
    {
        if (currentStep != TrainingStep.BackCoverGrabbed)
            return;

        currentStep = TrainingStep.GoodFrontGrabbed2;
        tooltipActivator.ActivateObject(39);
        arrowActivator.DeactivateObject(25);
        arrowActivator.ActivateObject(24);
        FrontCoverSnapPointObjectOnPunching2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 88, subTitletxt); //Place it on the jig as highlighted
        }

    }
    public void FrontCoverSnappedToAssebly2()
    {
        tooltipActivator.DeactivateObject(39);
        arrowActivator.DeactivateObject(24);
        tooltipActivator.ActivateObject(22);
        FrontCoverCheckButton.SetActive(true);
        greenButtonP2.FrontCoverSnapped();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 89, subTitletxt); //Press the button on right to start the process and Wait for the Result on monitor screen
        }
    }
    private void GreenButtonPressingDone2()
    {
        GreenButtonPressed2();
    }
    public void GreenButtonPressed2()
    {
        tooltipActivator.DeactivateObject(22);
        GrabGoodFrontCoverFromAssembly2.enabled = true;
        arrowActivator.ActivateObject(24);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 90, subTitletxt); //Pick Case Lower Sub Assembly from jig
        }

    }
    public void GrabbedFrontCoverFromAssmbly2()
    {
        if (currentStep != TrainingStep.GoodFrontGrabbed2)
            return;

        currentStep = TrainingStep.FrontFromAssyGrabbed2;
        arrowActivator.DeactivateObject(24);
        SphereFrontCoverOnBackCover.SetActive(true);
        HighlightSphereFrontCoverOnBackCover.Highlight();
        ScriptObjectFrontCoverOnBackCoverSnapPoint2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 91, subTitletxt); // Place it on the Case Upper Sub Assembly as highlighted
        }
    }
    public void FrontCoverSnappedOnBackCover2()
    {
        SphereFrontCoverOnBackCover.SetActive(false);
        tooltipActivator.ActivateObject(37);
        ScriptObjectPunchingMachineSlide.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 92, subTitletxt); //Push the jig forward
        }
    }
    private void SlidingDone2()
    {
        SliderReached2();
    }
    public void SliderReached2()
    {
        tooltipActivator.DeactivateObject(37);
        ScriptObjectPunchingMachineHandle.SetActive(true);
        punchingMachine.Unlock();
        tooltipActivator.ActivateObject(23);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 93, subTitletxt); //Pull the lever to press the Case Lower Sub Assy into the Case Upper Sub Assy
        }
    }

    private void PunchingProcessDone2()
    {
        PunchingDone2();
    }
    public void PunchingDone2()
    {
        tooltipActivator.DeactivateObject(23);
        tooltipActivator.ActivateObject(38);
        punchingSlidingScript.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 94, subTitletxt); //Pull the jig outward
        }
    }  
private void SlidingOutDone2()
{
    SliderPulledOut2();
}
public void SliderPulledOut2()
{
    tooltipActivator.DeactivateObject(38);
    GrabGoodPunchedKeyFromAssembly.enabled = true;
    arrowActivator.ActivateObject(19);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 95, subTitletxt); //Pick Remocon from jig using left hand
        }
    }

public void GrabbedMainKeyFromAssembly2()
    {
        arrowActivator.DeactivateObject(19);

    }
}
