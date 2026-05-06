using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using static SolderingMachine;

public class SMP1TM1 : MonoBehaviour
{
    [Header("Pin Defect")]
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    public StepWiseHighlighter HighlightBrokenPinCoverOnTray;
    public NGdrawer nGdrawer;
    public GameObject NGDefectSnapPointObject;
    public NG1SnapPoint NG1SnapPoint;

    [Header("Chip Component Missing")]
    public StepWiseHighlighter HighlightGoodCoverOnTray;
    public XRGrabInteractable GrabGoodCoverFromTray;
    public XRGrabInteractable ComponentMissChip;
    public StepWiseHighlighter HighlightComponentMissChip;
    public Collider DefectChipCollider;
    public GameObject GoodCover1Destroy;

    [Header("Check chip is placed on 5 Pins")]
    public StepWiseHighlighter GoodCover2FromTray;
    public XRGrabInteractable GrabGoodCover2FromTray;
    public Collider GoodChipCollider;
    public StepWiseHighlighter HighlightGoodChipFromTray;
    public XRGrabInteractable GrabGoodChipFromTray;
    public GameObject SphereChipObject;
    public GameObject ChipSnapPointObject; // object which has snappoint script on good cover
    public ChipToCover chipToCover;

    [Header("Handle Should Be closed & Punching defect")]
    public GameObject PuncherSnapPointObject;
    public GameObject SphereObjectCoverOnPuncher;
    public CoverToPuncher coverToPuncher;
    public GameObject LockingHandleScriptObject;
    public SideHandle sideHandle;
    public GameObject PunchingHandleScriptObject;
    public PuncherHandle puncherHandle;
    public XRGrabInteractable GrabCoverFromPunching;

    [Header("Good Immobilizer")]
    public StepWiseHighlighter GoodCover3FromTray;
    public XRGrabInteractable GrabGoodCover3FromTray;
    public Collider GoodChipCollider2;
    public StepWiseHighlighter HighlightGoodChip2FromTray;
    public XRGrabInteractable GrabGoodChip2FromTray;
    public GameObject SphereChipObject2;
    public GameObject ChipSnapPointObject2; // object which has snappoint script on good cover
    public ChipToCover2 chipToCover2;
    public GameObject PuncherSnapPointObject2;
    public CoverToPuncher2 coverToPuncher2;
    public GameObject LockingHandleScriptObject2;
    public GameObject PunchingHandleScriptObject2;
    public M1SideHandle2 sideHandle2;
    public M1PuncherHandle2 m1PuncherHandle2;
    public XRGrabInteractable GrabCoverFromPunching2;
    public StepWiseHighlighter HighlightCover2AfterPunching;

    public GameObject NGBOXdeactivate;
    [Header(" Level ")]
    public TMP_Text subTitletxt;
    public string levelName;

    private int drawerOpenCount = 0;
    private int drawerCloseCount = 0;
    private int activationCount = 0;
    public enum TrainingStep
    {
        None,
        NGCoverGrabbed,
        GoodCoverGrabbed,
        MisCompChipGrabbed,
        GoodCoverGrabbed2,
        GoodChipGrabbed,
        CoverFromPunchGrabbed,
        GoodCoverGrabbed3,
        GoodChipGrabbed2
    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        HighlightBrokenPinCoverOnTray.Highlight();
        nGdrawer.onReachedDesired += OnDrawerOpenedDynamic;
        NG1SnapPoint.OnObjectActivated += OnDefectSnappedToNGDynamic;
        nGdrawer.onReachedOriginal += OnDrawerClosedDynamic;
        chipToCover.Chipsnapped += GoodChipSnappedToGoodCover;
        coverToPuncher.Coversnapped += CoverSnappedToPuncher;
        sideHandle.onReachedDesired += SideHandleClosed;
        puncherHandle.onReachedOriginal += PunchingDone;
        sideHandle.onReachedOriginal += SideHandleOpened;
        chipToCover2.Chipsnapped += GoodChip2SnappedToGoodCover3;
        coverToPuncher2.CoversnappedToPunching += Cover3SnappedToPunching;
        sideHandle2.onReachedDesired += SideHandleClosed2;
        m1PuncherHandle2.onReachedOriginal += PunchingDone2;
        sideHandle2.onReachedOriginal += SideHandleOpened2;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 0, subTitletxt); //Welcome to the Immobilizer Line simulation tutorial
            StartCoroutine(SoundManager.instance.PlayDelayedSound(1, 1, subTitletxt, 4f)); // Go to first stage which is manual insertion and Pick antenna sub assembly from tray using left hand
        }
    }
    private void OnDrawerOpenedDynamic()
    {
        drawerOpenCount++;

        Debug.Log($"Drawer opened {drawerOpenCount} times");

        switch (drawerOpenCount)
        {
            case 1:
                FirstDrawerOpen();
                break;
            case 2:
                SecondDrawerOpen();
                break;
            case 3:
                ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDrawerClosedDynamic()
    {
        drawerCloseCount++;
        switch (drawerCloseCount)
        {
            case 1:
                FirstDrawerClosed();
                break;
            case 2:
                SecondDrawerClosed();
                break;
            case 3:
                ThirdDrawerClosed();
                break;
            default:
                Debug.Log("Drawer closed again, beyond the third time.");
                break;


        }
    }

    private void OnDefectSnappedToNGDynamic(GameObject obj)
    {
        activationCount++;
        Debug.Log($"[{activationCount}] Received event: {obj.name} just activated!");

        switch (activationCount)
        {
            case 1:
                PinDefectSnappedToNGBox(obj);
                break;

            case 2:
                MissComponentChipSnappedToNGBox(obj);
                break;

            case 3:
                PinBentAfterPunching(obj);
                break;

            default:
                Debug.Log("Additional activations beyond the third.");
                break;
        }
    }

    public void CoverGrabbedFromTray()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.NGCoverGrabbed;
        arrowActivator.DeactivateObject(0);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(0);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 2, subTitletxt); //It is a NG child part so put this antenna sub assembly in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(1, 3, subTitletxt, 4.5f)); //Open the NG box 
        }
    }
    private void FirstDrawerOpen()
    {
        Debug.Log("First drawer open — NGdrawerOpened logic");
        // call your existing function here
        NGdrawerOpened();
    }
    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(0);
        arrowActivator.DeactivateObject(1);
        arrowActivator.ActivateObject(2);
        NGDefectSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 4, subTitletxt); // Place NG antenna sub assembly in the NG box
        }       
    }
    public void PinDefectSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(2);
        tooltipActivator.ActivateObject(1);
        nGdrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 5, subTitletxt); //Close the NG box
        }
    }
    private void FirstDrawerClosed()
    {
        Debug.Log("First drawer open — NGdrawerClosed logic");
        // call your existing function here
        NGdrawerClosed();
    }
    public void NGdrawerClosed()
    {
        HighlightGoodCoverOnTray.Highlight();
        arrowActivator.ActivateObject(3);
        GrabGoodCoverFromTray.enabled = true;
        NGDefectSnapPointObject.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1,6, subTitletxt); //Now take another antenna sub assembly from tray using left hand
        }
    }
    public void GoodCoverGrabbedFromTray()
    {
        if (currentStep != TrainingStep.NGCoverGrabbed)
            return;

        currentStep = TrainingStep.GoodCoverGrabbed;
        tooltipActivator.ActivateObject(41);
        arrowActivator.DeactivateObject(3);
        arrowActivator.ActivateObject(4);
        ComponentMissChip.enabled = true;
        HighlightComponentMissChip.Highlight();
        DefectChipCollider.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 7, subTitletxt); //Now Pick circuit assembly from tray using right hand
        }
    }
    public void MissComponentChipGrabbedFromTray()
    {
        
        if (currentStep != TrainingStep.GoodCoverGrabbed)
            return;
        currentStep = TrainingStep.MisCompChipGrabbed;
        tooltipActivator.DeactivateObject(41);
        arrowActivator.DeactivateObject(4);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 8, subTitletxt); // It is a NG circuit assembly so put this child part in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(1, 9, subTitletxt, 4.5f)); //Release Good antenna from hand
        }
        //write in voice over that release the cover part 
    }
    public void GoodCoverReleasedFromHand()
    {
        arrowActivator.ActivateObject(1); // arrow at NGbox for all (1)
        tooltipActivator.ActivateObject(0); // tooltip at NGbox for all (0)
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 10, subTitletxt); // Open the NG box 
        }

    }
    public void SecondDrawerOpen()
    {

        NGdrawerOpened2();
    }
    public void NGdrawerOpened2()
    {
        arrowActivator.DeactivateObject(1); // arrow at NGbox for all (1)
        tooltipActivator.DeactivateObject(0); // tooltip at NGbox for all (0)
        arrowActivator.ActivateObject(2); // arrow at NGbox placing part (2)
        NGDefectSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 11, subTitletxt); // Place NG circuit assembly in the NG box
        }
    }
    public void MissComponentChipSnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(2);
        nGdrawer.Unlock();
        tooltipActivator.ActivateObject(1); // tooltip to close the NG drawer
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 12, subTitletxt); //Close the NG box
        }

    }
    private void SecondDrawerClosed()
    {
        NGdrawerClosed2();
    }
    public void NGdrawerClosed2()
    {
        GoodCover1Destroy.SetActive(false);
        tooltipActivator.DeactivateObject(1); // tooltip to close the NG drawer
        NGDefectSnapPointObject.SetActive(false);
        GoodCover2FromTray.Highlight();
        GrabGoodCover2FromTray.enabled = true;
       // GoodChipCollider.enabled = true;
        arrowActivator.ActivateObject(5);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 13, subTitletxt); //Now take another antenna sub assembly from tray using left hand
        }
    }
    public void GoodCover2GrabbedFromTray()
    {
        if (currentStep != TrainingStep.MisCompChipGrabbed)
            return;
        currentStep = TrainingStep.GoodCoverGrabbed2;
        tooltipActivator.ActivateObject(41);
        arrowActivator.DeactivateObject(5);
        GoodChipCollider.enabled = true;
        arrowActivator.ActivateObject(6);
        HighlightGoodChipFromTray.Highlight();
        GrabGoodChipFromTray.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 14, subTitletxt); //Now Pick circuit assembly from tray using right hand
        }
    }
    public void GoodChipGrabbedFromTray()
    {
        if (currentStep != TrainingStep.GoodCoverGrabbed2)
            return;
        currentStep = TrainingStep.GoodChipGrabbed;
        tooltipActivator.DeactivateObject(41);
        tooltipActivator.ActivateObject(42);
        arrowActivator.DeactivateObject(6);
        SphereChipObject.SetActive(true);
        ChipSnapPointObject.SetActive(true );
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 15, subTitletxt); //Place circuit assembly on the antenna sub assembly same as highlighted
        }
    }
    public void GoodChipSnappedToGoodCover()
    {
        tooltipActivator.DeactivateObject(42);
        SphereChipObject.SetActive(false);
        tooltipActivator.ActivateObject(2);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 16, subTitletxt); // Ensure before pressing that the 5 pins of antenna sub assembly are temporary set on PCB holes
        }
    }
    public void CloseTooltipAfterChecked()
    {
        tooltipActivator.DeactivateObject(2);
        PuncherSnapPointObject.SetActive(true);
        SphereObjectCoverOnPuncher.SetActive(true);
        arrowActivator.ActivateObject(7);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 17, subTitletxt); // Go to the manual punching machine and place the antenna sub assembly on the jig as highlighted
        }
    }
    public void CoverSnappedToPuncher()
    {
        arrowActivator.DeactivateObject(7);
        SphereObjectCoverOnPuncher.SetActive(false);
        LockingHandleScriptObject.SetActive(true);
        tooltipActivator.ActivateObject(3);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 18, subTitletxt); //After placing antenna sub assembly on jig , now close the toggle clamp

        }
    }
    public void SideHandleClosed()
    {
        tooltipActivator.DeactivateObject(3);
        tooltipActivator.ActivateObject(4);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 19, subTitletxt); //Always remember to close the toggle clamp
        }

    }
    public void OkButtonForToggleClampChecking()
    {
        tooltipActivator.DeactivateObject(4);
        PunchingHandleScriptObject.SetActive(true);
        tooltipActivator.ActivateObject(5);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 20, subTitletxt); //Pull the lever to press the circuit assembly into the antenna sub assembly
        }
    }
    public void PunchingDone()
    {
        tooltipActivator.ActivateObject(6);
        sideHandle.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 21, subTitletxt); //Open the toggle clamp

        }
    }
    public void SideHandleOpened()
    {
        tooltipActivator.DeactivateObject(6);
        GrabCoverFromPunching.enabled = true;
        arrowActivator.ActivateObject(8);
        sideHandle.PermanantlyLock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 22, subTitletxt); //Pick antenna sub assembly from manual punching machine
        }
    }
    public void CoverGrabbedFromPunching()
    {
        if (currentStep != TrainingStep.GoodChipGrabbed)
            return;
        currentStep = TrainingStep.CoverFromPunchGrabbed;
        arrowActivator.DeactivateObject(8);
        tooltipActivator.ActivateObject(7);
        arrowActivator.ActivateObject(1);
        tooltipActivator.ActivateObject(0);
        LockingHandleScriptObject.SetActive(false);
        PunchingHandleScriptObject.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 23, subTitletxt); // Pin is damaged while pressing
            StartCoroutine(SoundManager.instance.PlayDelayedSound(1, 24, subTitletxt, 3.5f)); // Open the NG box 
        }

    }
    public void ThirdDrawerOpen()
    {
        NGdrawerOpened3();
    }
    public void NGdrawerOpened3()
    {
        NGDefectSnapPointObject.SetActive(true);
        arrowActivator.DeactivateObject(1);
        tooltipActivator.DeactivateObject(0);
        arrowActivator.ActivateObject(2);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 25, subTitletxt); //Place NG antenna sub assembly in the NG box
        }

    }
    public void PinBentAfterPunching(GameObject obj)
    {
        arrowActivator.DeactivateObject(2);
        nGdrawer.Unlock();
        tooltipActivator.ActivateObject(1); // tooltip to close the NG drawer
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 26, subTitletxt); //Close the NG box
        }
    }
    private void ThirdDrawerClosed()
    {
        NGdrawerClosed3();
    }
    public void NGdrawerClosed3()
    {
        tooltipActivator.DeactivateObject(1); // tooltip to close the NG drawer
        NGDefectSnapPointObject.SetActive(false);
        arrowActivator.ActivateObject(9);
        GoodCover3FromTray.Highlight();
        GrabGoodCover3FromTray.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 27, subTitletxt); // Now take another antenna sub assembly from tray using left hand
        }
    }
    public void GoodCover3GrabbedFromTray()
    {
        if (currentStep != TrainingStep.CoverFromPunchGrabbed)
            return;
        currentStep = TrainingStep.GoodCoverGrabbed3;
        tooltipActivator.ActivateObject(41);
        arrowActivator.DeactivateObject(9);
        arrowActivator.ActivateObject(10);
        GoodChipCollider2.enabled = true;
        HighlightGoodChip2FromTray.Highlight();
        GrabGoodChip2FromTray.enabled=true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 28, subTitletxt); //Now Pick circuit assembly from tray using right hand
        }
    }
    public void GoodChip2GrabbedFromTray()
    {
        if (currentStep != TrainingStep.GoodCoverGrabbed3)
            return;
        currentStep = TrainingStep.GoodChipGrabbed2;
        tooltipActivator.DeactivateObject(41);
        tooltipActivator.ActivateObject(42);
        arrowActivator.DeactivateObject(10);
        SphereChipObject2.SetActive(true);
        ChipSnapPointObject2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 29, subTitletxt); //Place circuit assembly on the antenna sub assembly same as highlighted
        }
    }
    public void GoodChip2SnappedToGoodCover3()
    {
        tooltipActivator.DeactivateObject(42);

        SphereChipObject2.SetActive(false);
        PuncherSnapPointObject2.SetActive(true);
        SphereObjectCoverOnPuncher.SetActive(true);
        arrowActivator.ActivateObject(11);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 30, subTitletxt); // Go to the manual pressing machine and place the antenna sub assembly on the jig as highlighted
        }

    }
    public void Cover3SnappedToPunching()
    {
        arrowActivator.DeactivateObject(11);
        SphereObjectCoverOnPuncher.SetActive(false);
        LockingHandleScriptObject2.SetActive(true);
        tooltipActivator.ActivateObject(3);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 31, subTitletxt); // After placing antenna sub assembly on jig , now close the toggle clamp
        }
    }

    // use new script
    public void SideHandleClosed2()
    {
        tooltipActivator.DeactivateObject(3);
        tooltipActivator.ActivateObject(5);
        PunchingHandleScriptObject2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 32, subTitletxt); // Pull the lever to press the circuit assembly into the antenna sub assembly
        }
    }
    //public void OkButtonForToggleClampChecking2()
    //{
    //    tooltipActivator.DeactivateObject(4);
    //    PunchingHandleScriptObject2.SetActive(true);
    //    tooltipActivator.ActivateObject(5);
    //}
    public void PunchingDone2()
    {
        tooltipActivator.ActivateObject(6);
        sideHandle2.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 33, subTitletxt); // Open the toggle clamp
        }
    }
    public void SideHandleOpened2()
    {
        tooltipActivator.DeactivateObject(6);
        GrabCoverFromPunching2.enabled = true;
        arrowActivator.ActivateObject(8);
        sideHandle2.PermanantlyLock();
        HighlightCover2AfterPunching.Highlight();
        NGBOXdeactivate.SetActive(false );
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(1, 34, subTitletxt); // Pick antenna sub assembly from manual pressing machine
        }
    }
    public void GoodCoverGrabbedFromPunching()
    {
        arrowActivator.DeactivateObject(8);
        tooltipActivator.ActivateObject(41);
    }


}
