using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class P1TestManager : MonoBehaviour
{
    [Header ("PCB and Cover")]
    public M1TooltipActivator tooltipActivator;
    public PCBOnPinBrokenCoverSnapPoint pCBOnPinBrokenCoverSnapPoint;
    public PCBOnPinBrokenCoverSnapPoint pCBOnGoodCoverSnapPoint;
    public NGdrawer nGdrawer;
    public TestP1NGSnapPoint nG1SnapPoint;
    [Header("Cover on Punching ")]
    public GameObject CoverOnPunchingSnapPointObject;
    public SideHandle sideHandle;
    public PuncherHandle puncherHandle;
    public XRGrabInteractable GrabCoverFromPunching;
    //if punching done without side handle close
    public GameObject PinBrokenAfterPunching;
    public GameObject GoodCoverAfterPunching;
    // IF punching not done properly then do next step of making part again(PCB & cover)
    public GameObject GoodCoverOnTray;
    public GameObject GoodPCBOnTray;
    public PCBOnPinBrokenCoverSnapPoint GoodPCBOnGoodCoverSnapPoint;
    public GameObject CoverOnPunchingSnapPointObject2;
    public XRGrabInteractable GrabDefectCoverFromPunching;
    //IF punching done again wrong or good
    public GameObject PinBrokenAfterPunching2;
    public GameObject GoodCoverAfterPunching2;
    public XRGrabInteractable GrabDefectCoverFromPunching2;
    public GameObject GoodCoverOnTray2;
    public GameObject GoodPCBOnTray2;
    public PCBOnPinBrokenCoverSnapPoint GoodPCBOnGoodCoverSnapPoint2;

    public GameObject SolderingSnapPointObject;
    public SolderingMachine SolderingMachine;
    public CoverToSolderingTest coverToSolderingTest;

    private bool LS_ESActivated = false;
    private bool NS_SBActivated = false;
    private bool GoodSnappedToBox = false;
    private bool NGSnappedToBox = false;
    private bool HolderClosed = false;
    private bool HolderOpened = false;
    private bool DoorClosed = false;
    private bool DoorOpened = false;
    private bool GoodCoverFromSolderingActivated = false;
    public XRGrabInteractable LS_EBGrab;
    public XRGrabInteractable GoodFromSolderingGrab;
    public XRGrabInteractable NS_SBGrab;
    public GameObject NGCoverOnBoxSnapPointObject;
    public CoverToBlackBoxTest coverToBackBoxNG;
    public HolderMachine holderMachine;
    public Door1 door1;
    public GameObject DoorDisplayOK;
    public GameObject DoorDisplayNG;
    public XRGrabInteractable GoodCoverFromBoxGrab;
    public XRGrabInteractable NGCoverFromBoxGrab;
    public MagnifyingP1Test Magnifying;
    public UpperCoverOnLowerTestP1 upperCoverOnLowerTestP1;
    public UpperCoverOnLowerTestP1 upperCoverOnNGLowerTestP1;
    public GameObject CoverOnPunching2SnapPointObject;
    public GameObject CongratsMessage;
    private int PunchingCount = 0;
    public string levelName;
    private int lastActivatedIndex = -1;   // 1,2,3
    private int solderingCount = 0;        // how many times soldering completed

    //Objects to track before showing good objects
    [Header("Objects that must be destroyed")]
    public List<GameObject> objectsToTrack = new List<GameObject>();

    private int destroyedCount = 0;
    public int requiredDestroyed = 4;  // You said 4 objects
    //Booleans
    private bool PinBrokenCoverGrabbed = false;
    private bool GoodCoverGrabbed = false;
    private bool GoodCoverGrabbed2 = false;
    private bool CompMissPCBGrabbed = false;
    private bool GoodPCBGrabbed = false;
    private bool GoodPCBGrabbed2 = false;
    private bool SideHandleClose = false;
    private bool CoverPunchingDone = false;
    private bool CoverPunchingDone2 = false;
    private bool SideHandleOpen = false;
    private bool NGcoverAfterPunch = false;

    void Start()
    {
        nGdrawer.onReachedDesired += NGdrawerOpened;
        nGdrawer2.onReachedDesired += NGDrawer2Opened;
        pCBOnPinBrokenCoverSnapPoint.ChipSnapped += PCBsnappedToPinBroken;
        pCBOnGoodCoverSnapPoint.ChipSnapped += PCBsnappedToGoodCover;
        nG1SnapPoint.OnObjectActivated += NGsnappedToNGBox;
        sideHandle.onReachedDesired += SideHandleClosed;
        puncherHandle.onReachedOriginal += OnPunchingDoneDynamic;
        sideHandle.onReachedOriginal += SideHandleOpened;
        GoodPCBOnGoodCoverSnapPoint.ChipSnapped += GoodPCBsnappedGoodCover;
        GoodPCBOnGoodCoverSnapPoint2.ChipSnapped += PCBsnappedToGoodCover;
        SolderingMachine.onProcessComplete += SolderingCompleted;
        coverToSolderingTest.CoversnappedToSoldering += OnCoverSnappedToSolderingEvent;
        coverToBackBoxNG.ChipSnapped += CoverSnappedToBlackBox;
        holderMachine.onReachedDesired += HoldingDone;
        door1.Door1ReachedOriginal += DoorClosingDone;
        door1.Door1ReachedOriginal += DoorOpeningDone;
        holderMachine.onReachedOriginal += HoldingReleased;
        Magnifying.Checked += MagnifyingChecked;
        upperCoverOnLowerTestP1.ChipSnapped += UpperCoversnappedToLowerCover;
        upperCoverOnNGLowerTestP1.ChipSnapped += UpperCoverSnappedToNGLowerCover;
        upperCover2OnLower3Test.ChipSnapped += LowerCover3SnappedToGoodCover2;
        upperCover3OnLower4Test.ChipSnapped += LowerCover4SnappedToGoodCover3;
        upperCover4OnLower5Test.ChipSnapped += LowerCover5SnappedToGoodCover4;
        upperToPuncherSnapped.UpperCoverSnappedToPuncher += UpperCoverSnappedToPuncher;
        nG2SnapPoint.OnObjectActivated += NGsnappedToNGBox2;
        puncherHandle2.onReachedOriginal += PunchingMachine2Done;
        sideHandle2.onReachedDesired += SecondSideHandleClosed;
        sideHandle2.onReachedOriginal += SecondSideHandleOpened;
        upperToBlackBox.CoversnappedToBlackBox += CoverToBlackBox2Snapped;
        wireSnapping.WireSnapped += WireSnapped;
        boxHandle.onReachedDesired += BoxHandleClosed;
        door2.Door2ReachedDesired += DoorClosingDone2;
        door2.Door2ReachedOriginal += DoorOpeningDone2;
        wireSnapping2.WireRemoved += WireResnappedBackToPosition;
        stickerPressingSnapPoint.UpperCoverOnPressing += CoverSnappedOnStickerPressing;
        stickerInDustbin.StickerDumped += NGStickerSnappedToBin;
        stickerSnapPoint.Stickersnapped += StickerSnappedToCover;
        stickerPressing.onReachedDesired += StickerPresserClosed;
        greenButton.ButtonPressed += ButtonPressingDone;
        stickerPressing.onReachedOriginal += StickerPresserOpened;
        marking.MarkingDone += MarkingDone;
        finalStandSnapPoint.DoneLevel += LevelCompleted;



        foreach (GameObject obj in objectsToTrack)
        {
            if (obj != null)
            {
                var notifier = obj.AddComponent<DestroyNotifyer>();
                notifier.OnDestroyed += OnTrackedObjectDestroyed;
            }
        }
    }

    private void OnTrackedObjectDestroyed(GameObject destroyedObj)
    {
        destroyedCount++;
        Debug.Log($"{destroyedObj.name} destroyed. Total destroyed = {destroyedCount}");

        if (destroyedCount >= requiredDestroyed)
        {
            AllRequiredObjectsDestroyed();
        }
    }
    private void AllRequiredObjectsDestroyed()
    {
        Debug.Log("All 4 required objects destroyed! Calling final function...");
        GoodCoverOnTray2.SetActive(true);
        GoodPCBOnTray2.SetActive(true);

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
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }

    public void PinBrokenGrabbedFromTray() { PinBrokenCoverGrabbed = true; }
    public void GoodCoverGrabbedFromTray() { GoodCoverGrabbed = true; }
    public void CompMissPCBGrabbedFromTray() { CompMissPCBGrabbed = true; }
    public void GoodPCBGrabbedFromTray() { GoodPCBGrabbed = true; }

    public void PCBsnappedToPinBroken(string result)
    {
        if (result == "Good" && PinBrokenCoverGrabbed) // pcb good and cover NG
        {
            Debug.Log("PCB good and cover NG ");
            tooltipActivator.ActivateObject(0);
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(-1, levelName, "NG Part Placed");

            }
        }
        else if (result == "Defect" && PinBrokenCoverGrabbed) // PCB NG and Cover NG
        {
            tooltipActivator.ActivateObject(2);
            Debug.Log("Pin broken tooltip show");
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(-1, levelName, "NG Part Placed");

            }
        }
    }
    public void PCBsnappedToGoodCover(string result)
    {
        if (result == "Defect" && GoodCoverGrabbed) // PCB NG and Cover good
        {
            tooltipActivator.ActivateObject(3);
            Debug.Log("Miss Component PCB tooltip show");
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(-1, levelName, "NG Part Placed");

            }

        }
        else if (result == "Good" && GoodCoverGrabbed) // cover good and PCB good
        {
            Debug.Log("Good pcb and good cover");
            CoverOnPunchingSnapPointObject.SetActive(true);
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(1, levelName, "Correctly Placed");

            }
            // Score
        }
    }
    public void NGdrawerOpened()
    {
        nGdrawer.Unlock();

    }
    public void NGDrawer2Opened()
    {
        nGdrawer2.Unlock();

    }
    public void NGsnappedToNGBox(GameObject obj)
    {
        nGdrawer.Unlock();
        if(LS_ESActivated)
        {
            GoodCoverOnSoldering.SetActive(true);

        }
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Correctly Placed");

        }
    }
    public void NGsnappedToNGBox2(GameObject obj)
    {
        nGdrawer2.Unlock();
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Correctly Placed");

        }
    }
    public void SideHandleClosed()
    {
        SideHandleClose = true;
        GrabCoverFromPunching.enabled = false;
        AfterPunching();
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Handle Closed");

        }

    }
    public void SideHandleOpened()
    {
        SideHandleOpen = true;
        GrabCoverFromPunching.enabled = true;
        AfterPunching();
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Handle Opened");

        }
    }
    public void OnPunchingDone()
    {
        PunchingDone();
    }
    public void PunchingDone()
    {
        CoverPunchingDone = true;
        sideHandle.Unlock();
      
        AfterPunching();
       
    }
    public void AfterPunching()
    {
        if(CoverPunchingDone && SideHandleOpen && SideHandleClose)
        {
            puncherHandle.UnlockHandle();
            SideHandleOpen = false;
            SideHandleClose = false;
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(1, levelName, "Punching Done");

            }
            //score
        }
        else if( CoverPunchingDone && !SideHandleOpen && !SideHandleClose) 
        {
            PinBrokenAfterPunching.SetActive(true);
            GoodCoverAfterPunching.SetActive(false);
            tooltipActivator.ActivateObject(4);
            GrabDefectCoverFromPunching.enabled = true;
            GoodCoverOnTray.SetActive(true);
            GoodPCBOnTray.SetActive(true);
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(-1, levelName, "Punching Done Wrongly");

            }

        }
    
    }

    public void NGCoverAfterPunchingGrabbed() { NGcoverAfterPunch = true; }
    public void GoodCoverGrabbedFromTray2() { GoodCoverGrabbed2 = true; }
    public void GoodPCBGrabbedFromTray2() { GoodPCBGrabbed2 = true; }

    public void GoodPCBsnappedGoodCover(string result)
    {
        if (result == "Good" && GoodCoverGrabbed2) // pcb good and cover good
        {
            Debug.Log("PCB good 2 and cover Good 2 ");
            CoverOnPunchingSnapPointObject.SetActive(false);
            CoverOnPunchingSnapPointObject2.SetActive(true);
            Debug.Log("call punching unlock");
            puncherHandle.UnlockHandle();
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(1, levelName, "Punching Done");

            }
        }
       
    }
    public void OnPunchingDone2()
    {

        PunchingDone2();
    }
    public void PunchingDone2()
    {
        Debug.Log("Punching done 2 completed process");
        CoverPunchingDone2 = true;
        sideHandle.Unlock();
        AfterPunching2();
    }
    public void AfterPunching2()
    {
        if (CoverPunchingDone && SideHandleOpen && SideHandleClose)
        {
            puncherHandle.UnlockHandle();
            SideHandleOpen = false;
            SideHandleClose = false;
            Debug.Log("Second punching done correctly");
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(1, levelName, "Punching Done");

            }
            //score
        }
        else if (CoverPunchingDone && !SideHandleOpen && !SideHandleClose)
        {
            Debug.Log("Punching Done again wrong");
            PinBrokenAfterPunching2.SetActive(true);
            GoodCoverAfterPunching2.SetActive(false);
            tooltipActivator.ActivateObject(5);
            GrabDefectCoverFromPunching2.enabled = true;
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(-1, levelName, "Punching Done Wrongly");

            }
        }
    }

    // Machine 2 starts here
    public void GoodPunchedCoverGrabbed()
    {
        SolderingSnapPointObject.SetActive(true);
        SolderingMachine.enabled = true;
    }

    private void OnCoverSnappedToSolderingEvent(CoverSnapEventData data)
    {
        lastActivatedIndex = data.activatedIndex;

        Debug.Log($"Object #{lastActivatedIndex} snapped. Waiting for soldering...");
    }
    public void SolderingCompleted()
    {
        solderingCount++;

        Debug.Log($"Soldering completed count: {solderingCount}");

        switch (solderingCount)
        {
            case 1:
                PerformActionForObject1();
                break;
            case 2:
                PerformActionForObject2();
                break;
            case 3:
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
        //if (lastActivatedIndex == 1)
        //{
        //    PerformActionForObject1();
        //}
        //else if (lastActivatedIndex == 2)
        //{
        //   PerformActionForObject2();
        //}
        //else if (lastActivatedIndex == 3)
        //{
        //    PerformActionForObject3();
        //}
        //else
        //{
        //    Debug.Log("Soldering completed but no valid activation index found.");
        //}
        //lastActivatedIndex = -1; // Reset
    }

    public void PerformActionForObject1()
    {
       LS_ESActivated = true;
        LS_EBGrab.enabled = true;
        NGCoverOnBoxSnapPointObject.SetActive(true);
    }
    public void PerformActionForObject2()
    {
        Debug.Log(" Good object activated ");
        GoodFromSolderingGrab.enabled = true;
        NGCoverOnBoxSnapPointObject.SetActive(true);
    }
    public void PerformActionForObject3()
    {
        NS_SBActivated = true;
        NS_SBGrab.enabled = true;
    }
    public void LS_ESGrabbed()
    {
       
    }
    public void NS_SBGrabbed()
    {
       
    }
    public void CoverSnappedToBlackBox(string result)
    {
        Debug.Log("Cover snapped to black box");
        if (result == "Good") // pcb good and cover good
        {
            Debug.Log("Good snapped to black box ");
            GoodSnappedToBox = true;
           DoorClosingDone();
          //  HoldingReleased();
            DoorDisplayOK.SetActive(true);
            DoorDisplayNG.SetActive(false);
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(1, levelName, "Good Object Snapped");

            }
        }
        else if(result == "Defect")
        {
            Debug.Log("GIL GIL ");
            NGSnappedToBox = true;
            DoorClosingDone();
           // HoldingReleased();
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(-1, levelName, "NG Object Snapped");

            }
        }
    }
    public void HoldingDone()
    {
        HolderClosed = true;
        DoorClosingDone();
    }
    public void DoorClosingDone()
    {
        Debug.Log("Door closing done");
        DoorClosed = true;

        Debug.Log($"Good={GoodSnappedToBox}, NG={NGSnappedToBox}, HolderClosed={HolderClosed}");

        if (GoodSnappedToBox && HolderClosed)
        {
            DoorDisplayOK.SetActive(true);
            DoorDisplayNG.SetActive(false);
        }
        else if(NGSnappedToBox)
        {
            DoorDisplayOK.SetActive(false);
            DoorDisplayNG.SetActive(true);
        }
    }

    public void DoorOpeningDone()
    {
        holderMachine.Unlock();
    }
    public void HoldingReleased()
    {
        if(GoodSnappedToBox)
        {
            GoodCoverFromBoxGrab.enabled = true;
            DoorDisplayNG.SetActive(false);
            DoorDisplayOK.SetActive(false);
            GoodSnappedToBox= false;
            NGSnappedToBox = false;
        }
        else if (NGSnappedToBox )
        {
            NGCoverFromBoxGrab.enabled = true;
            DoorDisplayNG.SetActive(false);
            DoorDisplayOK.SetActive(false);
            NGSnappedToBox = false;
            GoodSnappedToBox = false;
        }
    }
    private bool goodCoverFromBoxGrab = false;
    private bool goodCoverFromBoxGrab2 = false;
    private bool goodCoverFromBoxGrab3 = false;
    private bool goodCoverFromBoxGrab4 = false;
    public GameObject GoodCoverOnSoldering;

    private bool nGCoverFromBoxGrab = false;
    private bool BrokenUpperCoverGrabbed = false;
    private bool GoodUpperCoverGrabbed = false;
    public void GoodCoverFromBoxGrabbed()
    {
        goodCoverFromBoxGrab = true;
    }
    public void NGCoverFromBoxGrabbed()
    {
        nGCoverFromBoxGrab = true;
        GoodCoverOnSoldering.SetActive(true);

    }
    public void FinalGoodOnPunchingGrabbed()
    {
        NGCoverOnBoxSnapPointObject.SetActive(true);
        GoodCoverFromBoxGrab.enabled = true;
    }
    public void MagnifyingChecked()
    {
        if(goodCoverFromBoxGrab)
        {
            // add score
            Debug.Log(" ADD scroe");
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(1, levelName, "Good Object Checking");

            }

        }
        else if (nGCoverFromBoxGrab)
        {
            // negative score 
            Debug.Log(" Negative scre");
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(-1, levelName, "NG Object Checking");

            }
        }
    }
    public void BrokenUpperCoverFromTrayGrabbed()
    {
        BrokenUpperCoverGrabbed = true;
    }
    public void GoodUpperCoverFromTrayGrabbed()
    {
        GoodUpperCoverGrabbed = true;
    }

    public GameObject GoodCover2OnBox;
    public GameObject LowerCover3OnTray;
    public GameObject GoodCover3OnBox;
    public GameObject LowerCover4OnTray;
    public GameObject GoodCover4OnBox;
    public GameObject LowerCover5OnTray;

    public UpperCoverOnLowerTestP1 upperCover2OnLower3Test;
    public UpperCoverOnLowerTestP1 upperCover3OnLower4Test;
    public UpperCoverOnLowerTestP1 upperCover4OnLower5Test;
    public UpperToPuncher upperToPuncherSnapped;
    public TestP1NG2SnapPoint nG2SnapPoint;
    public NGdrawer2 nGdrawer2;

    public void UpperCoversnappedToLowerCover(string result)
    {
        if (result == "Good" ) //  Upper Cover Good and LowerCover Good
        {
            Debug.Log(" Upper Cover Good and LowerCover Good");
            CoverOnPunching2SnapPointObject.SetActive(true);
            //Score
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(1, levelName, "Good Object Placed");

            }
        }
        else if (result == "Defect" ) // upper cover NG and Lower Cover Good
        {
            tooltipActivator.ActivateObject(8);
            HandleGoodCoverActivation();
            Debug.Log("upper cover NG and Lower Cover Good");
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(-1, levelName, "NG Object Placed");

            }
        }
    }
    public void UpperCoverSnappedToNGLowerCover(string result)
    {
        if (result == "Good") // NG
        {
            Debug.Log(" NG ");
            tooltipActivator.ActivateObject(9);
            HandleGoodCoverActivation();
            // negative score
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(-1, levelName, "NG Object Placed");
            }
        }
        else if (result == "Defect") // NG
        {
            tooltipActivator.ActivateObject(10);
            HandleGoodCoverActivation();

            Debug.Log(" NG ");
            if (GameManager.Instance.isTutorial)
            {
            }
            else
            {
                ScoreManager.Instance.AddScore(1, levelName, "Good Object Placed");
            }
        }
    }
    private void HandleGoodCoverActivation()
    {
        if (!GoodCover2OnBox.activeSelf)
        {
            // Step 1 ? Activate Cover 2
            GoodCover2OnBox.SetActive(true);
            return;
        }

        if (!GoodCover3OnBox.activeSelf)
        {
            // Step 2 ? Activate Cover 3
            GoodCover3OnBox.SetActive(true);
            return;
        }

        // Step 3 ? Activate Cover 4
        GoodCover4OnBox.SetActive(true);
    }
    public void GoodCoverFromBoxGrabbed2()
    {
        goodCoverFromBoxGrab2 = true;
        LowerCover3OnTray.SetActive(true);

    }
    public void GoodCoverFromBoxGrabbed3()
    {
        goodCoverFromBoxGrab3 = true;
        LowerCover4OnTray.SetActive(true);

    }
    public void GoodCoverFromBoxGrabbed4()
    {
        goodCoverFromBoxGrab4 = true;
        LowerCover5OnTray.SetActive(true);
    }
    public void LowerCover3SnappedToGoodCover2(string result)
    {
        CoverOnPunching2SnapPointObject.SetActive(true);
    }
    public void LowerCover4SnappedToGoodCover3(string result)
    {
        CoverOnPunching2SnapPointObject.SetActive(true);
    }
    public void LowerCover5SnappedToGoodCover4(string result)
    {
        CoverOnPunching2SnapPointObject.SetActive(true);
    }
    public void UpperCoverSnappedToPuncher()
    {

    }
    private bool SecondSideHandleClose = false;
    private bool SecondSideHandleOpen = false;
    private bool CoverPunching2Done = false;
    public XRGrabInteractable GrabCoverFromPunching2;
    public PuncherHandle2 puncherHandle2;
    public SideHandle2 sideHandle2;
    public void SecondSideHandleClosed()
    {
        SecondSideHandleClose = true;
        GrabCoverFromPunching2.enabled = false;
        AfterPunchingMachine2();
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Side Handle Closed");
        }

    }
    public void SecondSideHandleOpened()
    {
        SecondSideHandleOpen = true;
        GrabCoverFromPunching2.enabled = true;
        AfterPunchingMachine2();
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Side Handle Opened");
        }
    }

    public void PunchingMachine2Done()
    {
        CoverPunching2Done = true;
        sideHandle2.Unlock();
        AfterPunchingMachine2();
    }
    public void AfterPunchingMachine2()
    {
        if (CoverPunching2Done && SecondSideHandleOpen && SecondSideHandleClose)
        {
            puncherHandle2.UnlockHandle();
            SecondSideHandleOpen = false;
            SecondSideHandleClose = false;
            //score
        }
    }
    public GameObject GoodCoverOnBlackBox2SnapPoint;
    public UpperToBlackBox upperToBlackBox;
    public GameObject WireSnapPointOnCover;
    public WireSnapping wireSnapping;
    public BoxHandle boxHandle;
    public Door2 door2;
    private bool BoxHandleClose = false;
    private bool BoxHandleOpen = false;
    public void CoverGrabbedFromPunching2()
    {
        GoodCoverOnBlackBox2SnapPoint.SetActive(true);
    }
    public void CoverToBlackBox2Snapped()
    {
    }
    public void WireGrabbed()
    {
        WireSnapPointOnCover.SetActive(true); 
    }
    public void WireSnapped()
    {
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Wire Snapped");
        }
    }
    private bool DoorClosed2 = false;
    public void BoxHandleClosed()
    {
        BoxHandleClose = true;
    }
  
    public void DoorClosingDone2()
    {
        Debug.Log("Door closing done");
        DoorClosed2 = true;
        StartCoroutine(Box2DisplayOK());
       
    }
    public GameObject StartButton;
    public GameObject InspectingButton;
    public GameObject NGButton;
    public GameObject OKButton;
    public GameObject WireRemovingSnapPoint;
    public WireSnapping2 wireSnapping2;
    public XRGrabInteractable CoverOnBlackBox2Grab;
    public StickerPressingSnapPoint stickerPressingSnapPoint;
    public GameObject GoodSticker;
    public StickerInDustbin stickerInDustbin;
    public stickerSnapPoint stickerSnapPoint;
    public StickerPressing stickerPressing;
    public GreenButton greenButton;
    public Marking marking;
    public XRGrabInteractable CoverOnStickerPressing;
    public FinalStandSnapPoint finalStandSnapPoint;

    public IEnumerator Box2DisplayOK()
    {
        NGButton.SetActive(false);
        StartButton.SetActive(false);
        InspectingButton.SetActive(true);
        yield return new WaitForSeconds(5);
        InspectingButton.SetActive(false);
        StartButton.SetActive(true);
        OKButton.SetActive(true);
        door2.Unlock();


    }
   
    public void DoorOpeningDone2()
    {
        boxHandle.Unlock();
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Door Opened");
        }
    }
    public void BoxHandleOpened()
    {
        BoxHandleOpen = true;
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Door Opened");
        }
    }
    public void CableGrabbedAfterProcess()
    {
        WireRemovingSnapPoint.SetActive(true);
    }
    public void WireResnappedBackToPosition()
    {
        CoverOnBlackBox2Grab.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Wire Snapped");
        }
    }
    public void CoverFromBlackBox2Grabbed()
    {

    }
    public void CoverSnappedOnStickerPressing()
    {
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Cover Snapped To Sticker Presser");
        }
    }
    public void NGStickerGrabbed()
    {
        GoodSticker.SetActive(true);
    }
    public void NGStickerSnappedToBin()
    {
        //score
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "NG Sticker Placed In Bin");
        }
    }
    public void GoodStickerGrabbed()
    {

    }
    public void StickerSnappedToCover()
    {
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Sticker Placed");
        }
    }
    public void StickerPresserClosed()
    {

    }
    public void ButtonPressingDone()
    {
        stickerPressing.Unlock();
    }
    public void StickerPresserOpened()
    {
        CoverOnStickerPressing.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Sticker Presser Opened");
        }
    }
    public void MarkerGrabbed()
    {

    }
    public void MarkingDone()
    {
        if (GameManager.Instance.isTutorial)
        {
        }
        else
        {
            ScoreManager.Instance.AddScore(1, levelName, "Marking Done");
        }
    }
    public void CoverGrabbedFromStickerPressing()
    {

    }
    public void LevelCompleted()
    {
        CongratsMessage.SetActive(true);
        ScoreManager.Instance.SubmitTotalScoreToDB(levelName, ScoreManager.Instance.scoreValue.ToString(), "23");
    }
    public void Nextlevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
