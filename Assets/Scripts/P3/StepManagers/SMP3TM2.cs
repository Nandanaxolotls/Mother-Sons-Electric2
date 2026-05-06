using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP3TM2 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    [Header("NG Punching")]
    public GameObject FrontCoverOnPunchingSnapPointObject;
    public GameObject SphereFrontCoverOnPunching;
    public StepWiseHighlighter HighlightSphereFrontCoverOnPunching;
    public KeyOnPunchingSnapPoint keyOnPunchingSnapPoint;
    public XRGrabInteractable GrabBackCoverFromWaitingTray;
    public StepWiseHighlighter HighlightBackCoverFromWaitingTray;
    public XRGrabInteractable GrabBatteryFromTray;
    public StepWiseHighlighter HighlightBatteryFromTray;
    public GameObject BatterySnapPointObject;
    public GameObject SphereBatteryOnBackCover;
    public StepWiseHighlighter HighlightSphereBatteryOnBackCover;
    public BatteryOnKeySnapPoint batteryOnKeySnapPoint;
    public GameObject TerminalDownwardCanvas;
    public GameObject BatteryFixPointsCanvas;
    public GameObject BackCoverToFrontCoverSnappointObject;
    public GameObject SphereBackCoverToFrontCover;
    public StepWiseHighlighter HighlightSphereBackCoverToFrontCover;
    public BackCoverOnPunchingSnapPoint backCoverOnPunchingSnapPoint;
    public GameObject PunchingMachineScript;
    public PunchingMachieP3 punchingMachieP3;
    public XRGrabInteractable NGKeyFromPunchingGrab;
    public StepWiseHighlighter HighlightNGKeyFromPunchingGrab;
    public GameObject NGdrawer1ScriptObject;
    public GameObject NgSnapPointObject;
    public NGDrawer2P3 nGDrawer1;
    public P3NG2SnapPoint p3NG2SnapPoint;
    [Header(" Knob scratch ")]
    public GameObject NGScratchKeyOnPunching;
    public GameObject AgainCanvasScreenScratch;
    public XRGrabInteractable NGScratchKeyFromPunchingGrab;
    public StepWiseHighlighter HighlightNGScratchKeyFromPunchingGrab;

    public GameObject NGButtonPressedKeyOnPunching;
    public GameObject AgainCanvasScreenButton;
    public XRGrabInteractable NGButtonKeyFromPunchingGrab;
    public StepWiseHighlighter HighlightNGButtonKeyFromPunchingGrab;



    [Header("Good Punching")]
    public GameObject GoodKeyOnPunching;
    public GameObject AgainCanvasScreen;
    public XRGrabInteractable KeyFromPunchingGrab;
    public StepWiseHighlighter HighlightKeyFromPunchingGrab;
    [Header("NG Door")]
    public GameObject NGKeyOnDoorSnapPointObject;
    public GameObject SphereNGKeyOnDoor;
    public StepWiseHighlighter HighlightSphereNGKeyOnDoor;
    public KeyOnDoorSnapPoint keyOnDoorSnapPoint;
    public GameObject ScriptObjectDoor;
    public DrawerP3 drawerP3;
    public XRGrabInteractable NGKeyFromDoorGrab;
    public StepWiseHighlighter HighlightNGKeyFromDoor;
    [Header("Good Door")]
    public GameObject GoodKey2FromPunching;
    public StepWiseHighlighter HighlightGoodKey2FromPunching;
    public GameObject GoodKeyOnDoorSnapPointObject;
    public GoodKeyOnDoorSnapPoint goodKeyOnDoorSnapPoint;
    public XRGrabInteractable GoodKeyOnDoorGrab;

    [Header("UI")]
    public GameObject DoorCheck;
    public GameObject DoorNG;
    public GameObject DoorOK;
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    private int NGOpenCount = 0;
    private int NGCloseCount = 0;
    private int NgSnapCount = 0;
    private int PunchingCount = 0;
    private int DoorCloseCount = 0;
    private int DoorOpenCount = 0;

    public enum TrainingStep
    {
        None,
        KeyFromWaitingGrabbed,
        BatteryGrabbed,
        NGKeyFromPunchGrabbed,
        NGKeyFromPunchGrabbed2,
        NGKeyFromPunchGrabbed3,
        KeyFromPunchGrabbed,
        NGKeyFromDoorGrabbed,
        Key2FromPunchGrabbed,

    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        arrowActivator.ActivateObject(22);
        FrontCoverOnPunchingSnapPointObject.SetActive(true);
        SphereFrontCoverOnPunching.SetActive(true);
        HighlightSphereFrontCoverOnPunching.Highlight();
        keyOnPunchingSnapPoint.KeyOnPunchingSnapped += FrontCoverSnappedToPunching;
        batteryOnKeySnapPoint.BatterySnapped += BatterySnappedToBackCover;
        backCoverOnPunchingSnapPoint.BackSnappedOnPunching += BackCoverSnappedToPunching;
        punchingMachieP3.onReachedOriginal += OnPunchingDoneDynamic;
        nGDrawer1.onReachedDesired += OnNGDrawerOpenedDynamic;
        p3NG2SnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        nGDrawer1.onReachedOriginal += OnNGDrawerClosedDynamic;
        keyOnDoorSnapPoint.KeyOnDoorSnapped += NGKeyToDoorSnapped;
        drawerP3.onReachedDesired += OnDoorClosingDynamic;
        drawerP3.onReachedOriginal += OnDoorOpeningDynamic;
        goodKeyOnDoorSnapPoint.KeyOnDoorSnapped += GoodKeyToDoorSnapped;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 62, subTitletxt); //Now, Go to forth stage which is Assembly Case Upper and fitting to Case Lower. Place Case Upper Sub Assembly on the pressing jig as highlighted
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
                NGdrawerOpeningDone3();
                break;
            case 4:
                NGdrawerOpeningDone4();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
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
                NGdrawerClosingDone3();
                break;
            case 4:
                NGdrawerClosingDone4();
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
                NGKeyFromPunchingSnappedToNGBox(obj);
                break;

            case 2:
                NGButtonKeyFromPunchingSnappedToNGBox(obj);
                break;

            case 3:
                NGScratchKeyFromPunchingSnappedToNGBox(obj);
                break;
            case 4:
                NGKeyFromDoorSnappedToNGBox(obj);
                break;
            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }
    private void OnPunchingDoneDynamic()
    {
        PunchingCount++;

        Debug.Log($"Drawer opened {PunchingCount} times");

        switch (PunchingCount)
        {
            case 1:
                OnPunchingDone();
                break;
            case 2:
                OnPunchingDone2();
                break;
            case 3:
                OnPunchingDone3();
                break;
            case 4:
                OnPunchingDone4();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnDoorClosingDynamic()
    {
        DoorCloseCount++;

        Debug.Log($"Drawer opened {DoorCloseCount} times");

        switch (DoorCloseCount)
        {
            case 1:
                DoorClosingDone();
                break;
            case 2:
                DoorClosingDone2();
                break;
            case 3:
                // NGdrawerOpeningDone3();
                break;

            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    private void OnDoorOpeningDynamic()
    {
        DoorOpenCount++;

        Debug.Log($"Drawer opened {DoorOpenCount} times");

        switch (DoorOpenCount)
        {
            case 1:
                DoorOpeningDone();
                break;
            case 2:
                DoorOpeningDone2();
                break;
            case 3:
                // NGdrawerOpeningDone3();
                break;

            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    public void FrontCoverSnappedToPunching()
    {
        SphereFrontCoverOnPunching.SetActive(false);
        arrowActivator.DeactivateObject(22);
        arrowActivator.ActivateObject(21);
        GrabBackCoverFromWaitingTray.enabled = true;
        HighlightBackCoverFromWaitingTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 63, subTitletxt); //Pick Case Lower Sub Assembly from waiting tray
        }
    }
    public void BackCoverFromWaitingTrayGrabbed()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.KeyFromWaitingGrabbed;
        arrowActivator.DeactivateObject(21);
        arrowActivator.ActivateObject(23);
        GrabBatteryFromTray.enabled = true;
        HighlightBatteryFromTray.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 64, subTitletxt); //Pick Battery from tray
        }
    }

    public void BatteryFromTrayGrabbed()
    {
        if (currentStep != TrainingStep.KeyFromWaitingGrabbed)
            return;

        currentStep = TrainingStep.BatteryGrabbed;
        arrowActivator.DeactivateObject(23);
        BatterySnapPointObject.SetActive(true);
        SphereBatteryOnBackCover.SetActive(true);
        HighlightSphereBatteryOnBackCover.Highlight();
        TerminalDownwardCanvas.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 65, subTitletxt); //Place Battery on the Case Lower Sub Assembly as highlighted
        }
    }
    public void BatterySnappedToBackCover()
    {
        TerminalDownwardCanvas.SetActive(false);
        BatteryFixPointsCanvas.SetActive(true);
        SphereBatteryOnBackCover.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 66, subTitletxt); //Ensure proper installation of the battery to the lower case. Verify that all three locking points are securely engaged
        }
    }
    public void OkAfterFixPointChecked()
    {
        BatteryFixPointsCanvas.SetActive(false);
        arrowActivator.ActivateObject(22);
        BackCoverToFrontCoverSnappointObject.SetActive(true);
        SphereBackCoverToFrontCover.SetActive(true);
        HighlightSphereBackCoverToFrontCover.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 67, subTitletxt); //Go the pressing machine of stage forth and place Case Lower Sub Assembly on the Case Upper Sub Assembly
        }
    }
  
    public void BackCoverSnappedToPunching()
    {
        arrowActivator.DeactivateObject(22);
        SphereBackCoverToFrontCover.SetActive(false);
        PunchingMachineScript.SetActive(true);
        tooltipActivator.ActivateObject(13);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 68, subTitletxt); //Pull the lever to press the Case Lower Sub Assembly into the Case upper Sub Assembly
        }
    }
    private void OnPunchingDone()
    {
        PunchingDone();
    }
    public void PunchingDone()
    {
        tooltipActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(22);
        NGKeyFromPunchingGrab.enabled = true;
        HighlightNGKeyFromPunchingGrab.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 69, subTitletxt); //Pick Transmitter from jig
        }

    }
    public void NGKeyFromPunchingGrabbed()
    {
        if (currentStep != TrainingStep.BatteryGrabbed)
            return;

        currentStep = TrainingStep.NGKeyFromPunchGrabbed;
        PunchingMachineScript.SetActive(false);
        arrowActivator.DeactivateObject(22);
        tooltipActivator.ActivateObject(15);
        tooltipActivator.ActivateObject(14);
        arrowActivator.ActivateObject(25);
        NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 70, subTitletxt); //It is a NG child part so put this Case Upper in the highlighted NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 71, subTitletxt, 4.5f)); //Open the NG box 
        }
    }

    private void NGdrawerOpeningDone()
    {
        NGdrawerOpened();
    }
    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(14);
        arrowActivator.DeactivateObject(25);
        arrowActivator.ActivateObject(24);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 72, subTitletxt); // Place NG Transmitter in the NG box
        }
    }

    public void NGKeyFromPunchingSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(24);
        tooltipActivator.ActivateObject(16);
        nGDrawer1.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 73, subTitletxt); //Close the NG box
        }
    }
    private void NGdrawerClosingDone()
    {
        NGdrawerClosed();
    }

    public void NGdrawerClosed()
    {
        NGdrawer1ScriptObject.SetActive(false);
        NgSnapPointObject.SetActive(false);
        NGScratchKeyOnPunching.SetActive(true);
        AgainCanvasScreenScratch.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 74, subTitletxt); //Do this pressing process again
        }
    }
    public void PressedOkButtonScratch()
    {
        AgainCanvasScreenScratch.SetActive(false);
        PunchingMachineScript.SetActive(true);
        tooltipActivator.ActivateObject(13);
        punchingMachieP3.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 75, subTitletxt); //Pull the lever to press the Case Lower Sub Assembly into the Case upper Sub Assembly
        }
    }
    private void OnPunchingDone2()
    {
        PunchingDone2();
    }
    public void PunchingDone2()
    {
        tooltipActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(22);
        NGScratchKeyFromPunchingGrab.enabled = true;
        HighlightNGScratchKeyFromPunchingGrab.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 76, subTitletxt); //Pick Transmitter from jig
        }
    }
    public void NGScratchKeyFromPunchingGrabbed()
    {
        if (currentStep != TrainingStep.NGKeyFromPunchGrabbed)
            return;

        currentStep = TrainingStep.NGKeyFromPunchGrabbed2;
        PunchingMachineScript.SetActive(false);
        arrowActivator.DeactivateObject(22);
        tooltipActivator.ActivateObject(23);//
        tooltipActivator.ActivateObject(14);
        arrowActivator.ActivateObject(25);
        NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 77, subTitletxt); //It is a NG child part so put this Case Upper in the highlighted NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 78, subTitletxt, 4.5f)); //Open the NG box 
        }

    }
    private void NGdrawerOpeningDone2()
    {
        NGdrawerOpened2();
    }
    public void NGdrawerOpened2()
    {
        tooltipActivator.DeactivateObject(14);
        arrowActivator.DeactivateObject(25);
        arrowActivator.ActivateObject(24);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 79, subTitletxt); //Place NG Transmitter in the NG box
        }
    }
    public void NGScratchKeyFromPunchingSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(24);
        tooltipActivator.ActivateObject(16);
        nGDrawer1.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 80, subTitletxt); //Close the NG box
        }
    }
    private void NGdrawerClosingDone2()
    {
        NGdrawerClosed2();
    }

    public void NGdrawerClosed2()
    {

        NGdrawer1ScriptObject.SetActive(false);
        NgSnapPointObject.SetActive(false);
        NGButtonPressedKeyOnPunching.SetActive(true);
        AgainCanvasScreenButton.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 81, subTitletxt); //Do this pressing process again
        }
    }
    public void PressedOkButtonButtonDeformation()
    {
        AgainCanvasScreenButton.SetActive(false);
        PunchingMachineScript.SetActive(true);
        tooltipActivator.ActivateObject(13);
        punchingMachieP3.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 82, subTitletxt); //Pull the lever to press the Case Lower Sub Assembly into the Case upper Sub Assembly
        }
    }
    private void OnPunchingDone3()
    {
        PunchingDone3();
    }
    public void PunchingDone3()
    {
        tooltipActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(22);
        NGButtonKeyFromPunchingGrab.enabled = true;
        HighlightNGButtonKeyFromPunchingGrab.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 83, subTitletxt); //Pick Transmitter from jig
        }
    }
    public void NGButtonKeyFromPunchingGrabbed()
    {
        if (currentStep != TrainingStep.NGKeyFromPunchGrabbed2)
            return;

        currentStep = TrainingStep.NGKeyFromPunchGrabbed3;
        PunchingMachineScript.SetActive(false);
        arrowActivator.DeactivateObject(22);
        tooltipActivator.ActivateObject(24);//
        tooltipActivator.ActivateObject(14);
        arrowActivator.ActivateObject(25);
        NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 84, subTitletxt); //It is a NG child part so put this Case Upper in the highlighted NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 85, subTitletxt, 4.5f)); //Open the NG box 
        }
    }
    private void NGdrawerOpeningDone3()
    {
        NGdrawerOpened3();
    }
    public void NGdrawerOpened3()
    {
        tooltipActivator.DeactivateObject(14);
        arrowActivator.DeactivateObject(25);
        arrowActivator.ActivateObject(24);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 86, subTitletxt); //Place NG Transmitter in the NG box
        }
    }
    public void NGButtonKeyFromPunchingSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(24);
        tooltipActivator.ActivateObject(16);
        nGDrawer1.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 87, subTitletxt); //Close the NG box
        }
    }
    private void NGdrawerClosingDone3()
    {
        NGdrawerClosed3();
    }

    public void NGdrawerClosed3()
    {

        NGdrawer1ScriptObject.SetActive(false);
        NgSnapPointObject.SetActive(false);
        GoodKeyOnPunching.SetActive(true);
        AgainCanvasScreen.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 88, subTitletxt); //Do this pressing process again
        }
    }

    public void PressedOkButton()
    {
        AgainCanvasScreen.SetActive(false );
        PunchingMachineScript.SetActive(true);
        tooltipActivator.ActivateObject(13);
        punchingMachieP3.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 89, subTitletxt); //Pull the lever to press the Case Lower Sub Assembly into the Case upper Sub Assembly
        }
    }
    private void OnPunchingDone4()
    {
        PunchingDone4();
    }
    public void PunchingDone4()
    {
        tooltipActivator.DeactivateObject(13);
        arrowActivator.ActivateObject(22);
        KeyFromPunchingGrab.enabled = true;
        HighlightKeyFromPunchingGrab.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 90, subTitletxt); //Pick Transmitter from jig
        }
    }

    public void KeyFromPunchingGrabbed()
    {
        if (currentStep != TrainingStep.NGKeyFromPunchGrabbed3)
            return;

        currentStep = TrainingStep.KeyFromPunchGrabbed;
        tooltipActivator.ActivateObject(21);
        arrowActivator.DeactivateObject(22);
        arrowActivator.ActivateObject(26);
        NGKeyOnDoorSnapPointObject.SetActive(true );
        SphereNGKeyOnDoor.SetActive(true);
        HighlightSphereNGKeyOnDoor.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 91, subTitletxt); //Now, Go to fifth stage which is Function Checker. Place Transmitter on the Function Checker as highlighted
        }
    }

    public void NGKeyToDoorSnapped()
    {
        tooltipActivator.DeactivateObject(21);
        arrowActivator.DeactivateObject(26);
        SphereNGKeyOnDoor.SetActive(false);
        tooltipActivator.ActivateObject(17);
        ScriptObjectDoor.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 92, subTitletxt); //Close the door 
        }
    }
    private void DoorClosingDone()
    {
        DoorClosed();
    }
    public void DoorClosed()
    {
        tooltipActivator.DeactivateObject(17);
        StartCoroutine(DoorDisplayNG());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 93, subTitletxt); //Wait for the Result on monitor screen
        }
    }

    public IEnumerator DoorDisplayNG()
    {
        DoorCheck.SetActive(true);
        yield return new WaitForSeconds(4);
        DoorCheck.SetActive(false);
        DoorNG.SetActive(true);
        drawerP3.Unlock();
        tooltipActivator.ActivateObject(18);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 94, subTitletxt); //Open the door
        }
    }
    private void DoorOpeningDone()
    {
        DoorOpened();
    }

    public void DoorOpened()
    {
        tooltipActivator.DeactivateObject(18);
        arrowActivator.ActivateObject(26);
        NGKeyFromDoorGrab.enabled = true;
        HighlightNGKeyFromDoor.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 95, subTitletxt); // Pick Transmitter from Function Checker
        }
    }
    public void NGKeyFromDoorGrabbed()
    {
        if (currentStep != TrainingStep.KeyFromPunchGrabbed)
            return;

        currentStep = TrainingStep.NGKeyFromDoorGrabbed;
        ScriptObjectDoor.SetActive(false);
        arrowActivator.DeactivateObject(26);
        tooltipActivator.ActivateObject(14);
        arrowActivator.ActivateObject(25);
        NGdrawer1ScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 96, subTitletxt); //It is a NG child part so put this Case Upper in the highlighted NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(5, 97, subTitletxt, 4.5f)); //Open the NG box 
        }

    }

    private void NGdrawerOpeningDone4()
    {
        NGdrawerOpened4();
    }
    public void NGdrawerOpened4()
    {
        tooltipActivator.DeactivateObject(14);
        arrowActivator.DeactivateObject(25);
        arrowActivator.ActivateObject(24);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 98, subTitletxt); //Place NG Transmitter in the NG box
        }
    }
    public void NGKeyFromDoorSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(24);
        tooltipActivator.ActivateObject(16);
        nGDrawer1.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 99, subTitletxt); //Close the NG box
        }
    }
    private void NGdrawerClosingDone4()
    {
        NGdrawerClosed4();
    }

    public void NGdrawerClosed4()
    {
        NGdrawer1ScriptObject.SetActive(false);
        NgSnapPointObject.SetActive(false);
        GoodKey2FromPunching.SetActive(true);
        arrowActivator.ActivateObject(22);
        HighlightGoodKey2FromPunching.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 100, subTitletxt); //Go to the pressing machine of stage forth and pick Transmitter   
        }
    }
    public void Key2OnPunchingGrabbed()
    {
        if (currentStep != TrainingStep.NGKeyFromDoorGrabbed)
            return;

        currentStep = TrainingStep.Key2FromPunchGrabbed;
        arrowActivator.DeactivateObject(22);
        arrowActivator.ActivateObject(26);
        GoodKeyOnDoorSnapPointObject.SetActive(true);
        SphereNGKeyOnDoor.SetActive(true);
        HighlightSphereNGKeyOnDoor.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 101, subTitletxt); //  Place Transmitter on the Function Checker as highlighted
        }
    }
    public void GoodKeyToDoorSnapped()
    {
        arrowActivator.DeactivateObject(26);
        SphereNGKeyOnDoor.SetActive(false);
        tooltipActivator.ActivateObject(17);
        ScriptObjectDoor.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 102, subTitletxt); //Close the door 
        }
    }
    private void DoorClosingDone2()
    {
        DoorClosed2();
    }
    public void DoorClosed2()
    {
        tooltipActivator.DeactivateObject(17);
        StartCoroutine(DoorDisplayOK());
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 103, subTitletxt); //Wait for the Result on monitor screen
        }
    }
    public IEnumerator DoorDisplayOK()
    {
        DoorNG.SetActive(false );
        DoorCheck.SetActive(true);
        yield return new WaitForSeconds(4);
        DoorCheck.SetActive(false);
        DoorOK.SetActive(true);
        drawerP3.Unlock();
        tooltipActivator.ActivateObject(18);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 104, subTitletxt); //Open the door
        }
    }
    private void DoorOpeningDone2()
    {
        DoorOpened2();
    }
  
    public void DoorOpened2()
    {
        tooltipActivator.DeactivateObject(18);
        arrowActivator.ActivateObject(26);
        GoodKeyOnDoorGrab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(5, 105, subTitletxt); // Pick Transmitter from Function Checker
        }
    }
    public void GoodKeyFromDoorGrabbed()
    {
        arrowActivator.DeactivateObject(26);

    }

}
