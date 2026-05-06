using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;
using static Microsoft.MixedReality.Toolkit.Experimental.UI.KeyboardKeyFunc;
using static UnityEngine.InputSystem.Controls.AxisControl;
using static UnityEngine.Rendering.DebugUI.Table;

public class StepManagerP1 : MonoBehaviour
{
    [Header("Scene Settings")]
    public string nextSceneName = "NextScene"; // assign your next scene name in Inspector
    public int maxReloadCount = 7;             // how many times to reload before switching scene

    private string reloadKey;



    [Header("Machine1")]
    public ChipToCover chipToCoverSnappoint;
    public GameObject CoverToPuncherSnapPoint;// SnapPoint
    public CoverToPuncher coverToPuncher;
    public SideHandle sideHandle; //Side Handle Send Invoke
    public GameObject SideHandle; // GameObject
    public PuncherHandle PuncherHandle; // script calling
    public GameObject PunchersHandle; // GameObject
    public XRGrabInteractable CoverAfterPunched;
    [Header("Machine2")]
    public GameObject SolderingSnapPoint;
    public CoverToSoldering coverToSolderingSnapPoint;
    public SolderingMachine solderingMachine;
    public XRGrabInteractable CoverAfterSoldered;
    [Header("Machine3")]
    public GameObject BlackBoxSnapPoint;
    public GameObject SphereBlackBoxSnapPoint;
    public CoverToBackBox coverToBackBox;
    public HolderMachine holderMachine;
    public Door1 door1;
    public ComputerDisplay computerDisplay;
    public GameObject DisplayCanvas;
    public XRGrabInteractable CoverInBlackBox;
    [Header("Machine4")]
    public GameObject UpperSnappingPoint;
    public UpperCoverToMain UpperSnappingScript; // script calling after snapped
    public GameObject UpperOnPuncherSnapPoint; // upper on puncher snappoint
    public UpperToPuncher UpperToPuncherSnapped;
    public GameObject SideHandle2;
    public GameObject Handle2;
    public SideHandle2 sideHandle2;
    public PuncherHandle2 puncherHandle2;
    public XRGrabInteractable UpperCoverAfterPunched;
    [Header("Machine5")]
    public UpperToBlackBox upperToBlackBox; // SnapPoint for snapping upper to black box2
    public GameObject UpperSnapPoint; // snappoint object
    public GameObject wireSnappingGameObject; //snappoint gameobject
    public WireSnapping wireSnapping;
    public XRGrabInteractable WireGrabbing;
    public GameObject ButtonTrigger;
    public BoxHandle boxHandle;
    public Door2 door2;
    public ComputerDisplay2 computerDisplay2;
    public GameObject DisplayCanvas2;
    public XRGrabInteractable CoverInBlackBox2;
    [Header("Machine6")]
    public GameObject StickerPressingSnapPoint;
    public StickerPressingSnapPoint StickerPressing;
    public GameObject PressingTrigger; // pressing machine mechainsm game object 
    public StickerPressing stickerPressingTrigger; //Pressing script calling after closing
    public GameObject Sticker;
    public GameObject StickerSnapPoint;
    public stickerSnapPoint stickerSnapPoint;
    public GameObject GreenButtonScriptObject;
    public GreenButton greenButton;
    public XRGrabInteractable Marker;
    public GameObject MarkingPoint;
    public Marking marking;
    public XRGrabInteractable UpperAfterStickerAttached;
    public GameObject FinalStandSnapPoint;
    public FinalStandSnapPoint FinalStandScript;
    public List<XRGrabInteractable> grabObjectsToEnable = new List<XRGrabInteractable>();


    [Header("Highlights")]
    [Header("Machine1")]
    public StepWiseHighlighter CoverHighlighter;
    public GameObject Arrow1;
    public StepWiseHighlighter ChipHighlighter;
    public GameObject Arrow2;
    public GameObject SphereOnCover;
    public GameObject Arrow3;
    public GameObject SphereOnPuncher;
    public StepWiseHighlighter CoverOnPuncher;
    public GameObject Tooltip; // side handle highlighter
    public GameObject Tooltip2; // Puncher highlighter
    public GameObject Tooltip3; // Puncher highlighter close
    public GameObject Tooltip4; // Side Handle CLose (original position)
    public StepWiseHighlighter CoverOnPuncherPick;
    [Header("Machine2")]
    public GameObject Arrow4;
    public GameObject SphereOnSoldering; // sphere which highlights the soldering area for snapping cover 
    public StepWiseHighlighter SolderingSnappointHighlight;
    public GameObject Tooltip5;
    public StepWiseHighlighter CoverAfterSolderedHighlight;
    [Header("Machine3")]
    public GameObject Arrow5;
    public StepWiseHighlighter CoverOnBlackBox;
    public GameObject Tooltip6;
    public GameObject Arrow6;
    public GameObject Tooltip7;
    public GameObject Tooltip8;
    public GameObject Tooltip9;
    public StepWiseHighlighter CoverBlackBoxHighlighter;
    public GameObject Tooltip10;
    [Header("Machine4")]
    public GameObject Arrow7;
    public GameObject Arrow8;
    // public StepWiseHighlighter UpperHighlightSphere;
    public GameObject UpperCoverSphere;
    public GameObject Arrow9;
    public GameObject SnapHighlighterInPuncher; // Snappoint highlighter on puncher
    public StepWiseHighlighter UpperOnPuncherHighlighter;
    public GameObject Tooltip11;
    public GameObject Tooltip12;
    public GameObject Tooltip13;
    public GameObject Tooltip14;
    public StepWiseHighlighter UpperCoverOnPuncherPick2;
    [Header("Machine5")]
    public GameObject Arrow10;
    public GameObject SphereUpperOnBoxHighlighter2; // highlighter object for placing upper on black box 2
    public StepWiseHighlighter UpperOnBoxHighlighter2;
    public GameObject Tooltip15;
    public StepWiseHighlighter wirePlugHighlight;
    public GameObject WireSphere;
    public GameObject Tooltip16;
    public GameObject Arrow11;
    public GameObject Tooltip17;
    public GameObject Tooltip18;
    public GameObject Tooltip19;
    public GameObject Tooltip20;
    public StepWiseHighlighter CoverBlackBox2Highlighter;
    public GameObject Arrow12;
    public GameObject Tooltip21;
    public GameObject Arrow13;
    public GameObject Tooltip22;
    public GameObject Tooltip23;
    public GameObject Tooltip24;
    public GameObject Arrow14;
    public StepWiseHighlighter UpperAfterSticker;
    public GameObject Arrow15;
    public GameObject Arrow16;
    public GameObject Arrow17; // after soldering arrow
    public GameObject Arrow18;
    public GameObject SphereMarkingPoint;
    public StepWiseHighlighter SphereHighlightMarkingPoint;
    public GameObject Arrow19;
    [Header(" Level ")]
    public TMP_Text subTitletxt;
    public string levelName;
    public enum TrainingStep
    {
        None,
        CoverGrabbed,
        ChipGrabbed,
        StickerGrabbed,
        MarkerGrabbed,
        FinalGrabbed
    }

    public TrainingStep currentStep = TrainingStep.None;

    void Awake()
    {
        // Use the scene name as a unique key for saving reload count
        reloadKey = SceneManager.GetActiveScene().name + "_ReloadCount";
    }


    void Start()
    {
        levelName = GameManager.Instance.levelDatas[0].LevelName;
        CoverHighlighter.Highlight();
        chipToCoverSnappoint.Chipsnapped += ChipSnappedToCover;
        coverToPuncher.Coversnapped += CoverSnappedToPuncher;
        sideHandle.onReachedDesired += SideHandlePlaced;
        PuncherHandle.onReachedOriginal += PunchingDone;
        sideHandle.onReachedOriginal += SideHandleToOriginal;
        SolderingSnapPoint.SetActive(false);
        coverToSolderingSnapPoint.CoversnappedToSoldering += CoverSnappedToSolder;
        solderingMachine.enabled = false;
        solderingMachine.onProcessStart += SolderingStarted;
        solderingMachine.onProcessComplete += SolderingDone;
        coverToBackBox.CoversnappedToBlackBox += CoverSnappedToBlackBox;
        holderMachine.onReachedDesired += BlackBoxHolded;
        door1.Door1ReachedDesired += DoorClosed;
        // computerDisplay.enabled = false;
        computerDisplay.onProcessCompleted += DoorProcessCompleted;
        door1.Door1ReachedOriginal += DoorOpened;
        holderMachine.onReachedOriginal += BlackBoxHolderOpened;
        UpperSnappingScript.UpperCoverSnappedToCover += UpperSnappedToCover;
        UpperToPuncherSnapped.UpperCoverSnappedToPuncher += UpperSnappedToPuncher;
        sideHandle2.onReachedDesired += SideHandlePlaced2;
        puncherHandle2.onReachedOriginal += PunchingDone2;
        sideHandle2.onReachedOriginal += SideHandleToOriginal2;
        upperToBlackBox.CoversnappedToBlackBox += UpperSnappedToBox;
        wireSnapping.WireSnapped += WireDoneSnapping;
        boxHandle.onReachedDesired += BoxHandleHolded;
        door2.Door2ReachedDesired += DoorClosed2;
        computerDisplay2.onProcessCompleted += FunctionCheckProcessCompleted;
        door2.Door2ReachedOriginal += DoorOpened2;
        boxHandle.onReachedOriginal += BoxHandleReleased;
        StickerPressing.UpperCoverOnPressing += UpperCoverSnappedToPressing;
        stickerSnapPoint.Stickersnapped += StickerSnapped;
        stickerPressingTrigger.onReachedDesired += StickerPressingClosed;
        greenButton.ButtonPressed += GreenButtonPressed;
        stickerPressingTrigger.onReachedOriginal += StickerPressingOpened;
        marking.MarkingDone += MarkingDone;
        FinalStandScript.DoneLevel += DoneFinal;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 0, subTitletxt); //Welcome to the Immobilizer Line simulation tutorial

            StartCoroutine(SoundManager.instance.PlayDelayedSound(0, 1, subTitletxt, 3f)); // Go to first stage which is manual insertion and Pick antenna sub assembly from tray using left hand

        }




    }
    //Machine 1
    public void CoverGrabbed()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.CoverGrabbed;
        Debug.Log("Cover Grabbed");
        ChipHighlighter.Highlight();
        Arrow1.SetActive(false);
        Arrow2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 2, subTitletxt); // Now Pick circuit assembly from tray using right hand
        }
    }

    public void ChipGrabbed()
    {
        if (currentStep != TrainingStep.CoverGrabbed)
            return;

        currentStep = TrainingStep.ChipGrabbed;
        Debug.Log("Chip Grabbed");
        Arrow2.SetActive(false);
        SphereOnCover.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 3, subTitletxt);  //Place circuit assembly on the antenna sub assembly same as highlighted
        }   
    }

    public void ChipSnappedToCover()
    {
        Debug.Log("Chip Snapped");
        CoverToPuncherSnapPoint.SetActive(true);
        SphereOnCover.SetActive(false);
        Arrow3.SetActive(true);
        SphereOnPuncher.SetActive(true);
        CoverOnPuncher.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 4, subTitletxt); //Go to the manual punching machine and place the antenna sub assembly on the jig as highlighted

        }

    }
    public void CoverSnappedToPuncher()
    {
        Debug.Log("Cover Snapped To Puncher");
        SideHandle.SetActive(true);
        CoverAfterPunched.enabled = false;
        Arrow3.SetActive(false);
        SphereOnPuncher.SetActive(false);
        Tooltip.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 5, subTitletxt); //After placing antenna sub assembly on jig , now close the toggle clamp

        }

    }
    public void SideHandlePlaced()
    {
        Debug.Log("Side Handle Placed");
        PunchersHandle.SetActive(true);
        Tooltip.SetActive(false);
        Tooltip2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 6, subTitletxt); //// Pull the lever to press the circuit assembly into the antenna sub assembly

        }
    }
    public void PunchingDone()
    {
        Debug.Log("PunchingDone");
        sideHandle.Unlock();
        Tooltip3.SetActive(false);
        Tooltip4.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 7, subTitletxt); //Open the toggle clamp
        }       
    }
    public void SideHandleToOriginal()
    {
        Debug.Log("Side Handle To Original");
        sideHandle.PermanantlyLock();
        Tooltip4.SetActive(false);
        CoverAfterPunched.enabled = true;
        SolderingSnapPoint.SetActive(true);
        CoverOnPuncherPick.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 8, subTitletxt); //Pick antenna sub assembly from manual punching machine and go to next stage which is terminal robot soldering and place it on the jig as highlighted
        }

    }
    public void CoverGrabbedFromPuncher() // cover grabbed from puncher
    {
        SphereOnSoldering.SetActive(true);
        Arrow4.SetActive(true);
        SolderingSnappointHighlight.Highlight();
       
    }

    // Machine 2
    public void CoverSnappedToSolder() // cover snapped to soldering machine
    {
        Arrow4.SetActive(false);
        SphereOnSoldering.SetActive(false);
        Tooltip5.SetActive(true);
        solderingMachine.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 9, subTitletxt); //Press green button to start soldering
        }

    }
    public void SolderingStarted()
    {
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 10, subTitletxt); // Wait for the soldering process to complete
        }
    }

    public void SolderingDone()
    {
        CoverAfterSoldered.enabled = true;
        Arrow17.SetActive(true);
        CoverAfterSolderedHighlight.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 11, subTitletxt);  //Pick antenna sub assembly from soldering machine and go to next stage which is AOI and place it on the jig as highlighted
        }
    }

    public void CoverGrabbedAfterSoldering()
    {
        BlackBoxSnapPoint.SetActive(true);
        Arrow17.SetActive(false);
        Arrow5.SetActive(true);
        SphereBlackBoxSnapPoint.SetActive(true);
        CoverOnBlackBox.Highlight();
    }

    //Machine 3
    public void CoverSnappedToBlackBox()
    {
        Arrow5.SetActive(false);
        SphereBlackBoxSnapPoint.SetActive(false);
        Tooltip6.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 12, subTitletxt);  // Close the toggle clamp

        }
    }

    public void BlackBoxHolded() // holder holded cover in black box
    {
        Tooltip6.SetActive(false);
        Tooltip7.SetActive(true);
        Arrow6.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 13, subTitletxt);  // Close the door of AOI 
        }
    }
    public void DoorClosed()
    {
        Debug.Log("Door closed");
        computerDisplay.enabled = true;
        Tooltip8.SetActive(true);
        DisplayCanvas.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 14, subTitletxt); //Click the start button to start the process and Wait for the Result on monitor screen
        }
    }
    public void DoorProcessCompleted()
    {
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 15, subTitletxt); //Open the door of AOI
        }  
    }
    public void DoorOpened()
    {
        door1.PermanantlyLock();
        Tooltip9.SetActive(true);
        holderMachine.Unlock();
        Tooltip10.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 16, subTitletxt); // Open the toggle clamp
        }
    }
    public void BlackBoxHolderOpened() // holder opened of black box
    {
        holderMachine.PermanantlyLock();
        CoverInBlackBox.enabled = true;
        CoverBlackBoxHighlighter.Highlight();
        Tooltip9.SetActive(false);
        Arrow18.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 17, subTitletxt); //Pick antenna sub assembly from AOI jig and go the next stage which is ANT cover assembly and start visual check for any defect under the magnifying glass
        }
    }
    private bool grabbed = false;
    public void CoverGrabbedFromBlackBox() // cover grabbed from black box after process completes
    {
        if (!grabbed)
        {
            Debug.Log("pakad liya");
            Arrow7.SetActive(true);
            Arrow18.SetActive(false);
            grabbed = true;
        }
    }

    public void MagnifyingChecked()
    {
        Arrow7.SetActive(false);
        Arrow8.SetActive(true); // pick coverupper from bin
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 18, subTitletxt); //Pick antenna cover from tray using right hand
        }   
    }
    private bool grabbed2 = false;
    public void UpperCoverBlackBox() // Upper cover grabbed from bin
    {
        if (!grabbed2)
        {
            Arrow8.SetActive(false);
            grabbed2 = true;
            UpperSnappingPoint.SetActive(true);
            UpperCoverSphere.SetActive(true);
            //UpperHighlightSphere.Highlight();
            if (GameManager.Instance.isTutorial)
            {
                SoundManager.instance.PlayVoiceOver(0, 19, subTitletxt); //Place antenna cover on the antenna sub assembly
            }
        }
    }

    public void UpperSnappedToCover()
    {
        UpperCoverSphere.SetActive(false);
        Arrow9.SetActive(true);
        SnapHighlighterInPuncher.SetActive(true);
        UpperOnPuncherHighlighter.Highlight();
        UpperOnPuncherSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 20, subTitletxt); //Now place antenna sub assembly on the manual punching machine jig as highlighted
        }  
    }

    public void UpperSnappedToPuncher()
    {
        Arrow9.SetActive(false);
        SnapHighlighterInPuncher.SetActive(false);
        Tooltip11.SetActive(true);
        SideHandle2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 21, subTitletxt); //After placing antenna sub assembly on jig , now close the toggle clamp
        }
    }
    public void SideHandlePlaced2()
    {
        Handle2.SetActive(true);
        Tooltip11.SetActive(false);
        Tooltip12.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 22, subTitletxt);  //Pull the lever to press the antenna cover into the antenna sub assembly
        }
    }
    public void PunchingDone2()
    {
        sideHandle2.Unlock();
        Tooltip13.SetActive(false);
        Tooltip14.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 23, subTitletxt);  // Open the toggle clamp
        }
    }

    public void SideHandleToOriginal2()
    {
        Debug.Log("Side Handle To Original");
        sideHandle2.PermanantlyLock();
        Tooltip14.SetActive(false);
        UpperCoverAfterPunched.enabled = true;
        // SolderingSnapPoint.SetActive(true);
        UpperCoverOnPuncherPick2.Highlight();

        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 24, subTitletxt);  // // Pick antenna sub assembly from manual punching machine and go to next stage which is function checker and place it on the jig as highlighted
        }
    }
    private bool grabbed3 = false;
    public void UpperGrabbedFromPuncher2() // upper cover grabbed from puncher 2
    {
        if (!grabbed3)
        {
            grabbed3 = true;
            Arrow10.SetActive(true);
            SphereUpperOnBoxHighlighter2.SetActive(true);
            UpperOnBoxHighlighter2.Highlight();
            UpperSnapPoint.SetActive(true);
            UpperCoverOnPuncherPick2.Unhighlight();

        }
    }

    public void UpperSnappedToBox()
    {
        Arrow10.SetActive(false);
        SphereUpperOnBoxHighlighter2.SetActive(false);
        Tooltip15.SetActive(true);
        wirePlugHighlight.Highlight();
        WireGrabbing.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 25, subTitletxt);  // // Now grab the plug and securely connect it to the highlighted port of the antenna sub assembly
        }
    }

    public void WireGrabbed()
    {
        Tooltip15.SetActive(false);
        WireSphere.SetActive(true);
        wireSnappingGameObject.SetActive(true);
    }

    public void WireDoneSnapping()
    {
        WireSphere.SetActive(false);
        ButtonTrigger.SetActive(true);
        Tooltip16.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 26, subTitletxt);  // Close the toggle clamp
        }    
    }
    public void BoxHandleHolded()
    {
        Tooltip16.SetActive(false);
        Arrow11.SetActive(true);
        Tooltip17.SetActive(true);
        door2.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 27, subTitletxt);  //Close the door of function checker using right hand
        }
    }
    public void DoorClosed2()
    {
        Debug.Log("Door closed");
        computerDisplay2.enabled = true;
        Tooltip18.SetActive(true);
        DisplayCanvas2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 28, subTitletxt);  //Click the start button to start the process and Wait for the Result on monitor screen
        }
    }
    public void FunctionCheckProcessCompleted()
    {
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 29, subTitletxt);  //Open the door of function checker using right hand
        }   
    }
    public void DoorOpened2()
    {
        door2.PermanantlyLock();
        boxHandle.Unlock();
        Tooltip19.SetActive(false);
        Tooltip20.SetActive(true); // holder of black box2 opening tooltip
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 30, subTitletxt);  // Open the toggle clamp
        }
    }
    public void BoxHandleReleased()
    {
        boxHandle.PermanantlyLock();
        Tooltip20.SetActive(false);
        CoverInBlackBox2.enabled = true;
        CoverBlackBox2Highlighter.Highlight();

        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 31, subTitletxt);  //Pick antenna sub assembly from Function checker jig and go the next stage which is Label pasting and place it on the jig as highlighted
        }
    }
    public void UpperGrabbedFromBox2()
    {
        StickerPressingSnapPoint.SetActive(true);
        CoverBlackBox2Highlighter.Unhighlight();

        Arrow12.SetActive(true);
    }
    public void UpperCoverSnappedToPressing()
    {
        Arrow12.SetActive(false);
        Arrow19.SetActive(true);
        Tooltip21.SetActive(true); //take sticker
        Sticker.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 32, subTitletxt);  // Grab label from label printing machine
        }


    }
    public void StickerGrabbed()
    {
        if (currentStep != TrainingStep.ChipGrabbed)
        return;

        currentStep = TrainingStep.StickerGrabbed;
        Tooltip21.SetActive(false);
        Arrow13.SetActive(true);
        Arrow19.SetActive(false);
        StickerSnapPoint.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 33, subTitletxt);  // Stick label on the antenna sub assembly as highlighted
        }      
    }
    public void StickerSnapped()
    {
        Arrow13.SetActive(false);
        PressingTrigger.SetActive(true);
        Tooltip22.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 34, subTitletxt);  // Close the flap using left hand
        }
    }

    public void StickerPressingClosed()
    {
        Tooltip22.SetActive(false);
        Tooltip23.SetActive(true);
        GreenButtonScriptObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 35, subTitletxt);  // Press green button
        }
    }
    public void GreenButtonPressed()
    {
        Tooltip23.SetActive(false);
        stickerPressingTrigger.Unlock();
        Tooltip24.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 36, subTitletxt);  //Open the flap using left hand
        }
    }
    public void StickerPressingOpened()
    {
        Tooltip24.SetActive(false);
        stickerPressingTrigger.PermanantlyLock();
        Arrow14.SetActive(true); // for marker
        Marker.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 37, subTitletxt);  // Grab the marker
        }
    }
    public void MarkerGrabbed()
    {


        if (currentStep != TrainingStep.StickerGrabbed)
            return;

        currentStep = TrainingStep.MarkerGrabbed;
        Arrow14.SetActive(false); // for marker
        Arrow15.SetActive(true);
        MarkingPoint.SetActive(true);
        SphereMarkingPoint.SetActive(true );
        SphereHighlightMarkingPoint.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 38, subTitletxt);  //Make marking on antenna sub assembly as highlighted
        }   
    }
    public void MarkingDone()
    {
        SphereMarkingPoint.SetActive(false);

        Arrow15.SetActive(false);
        UpperAfterSticker.Highlight();
        UpperAfterStickerAttached.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 39, subTitletxt);  // Leave marker on table and pick antenna sub assembly from label pasting jig
        }
    }
    public void UpperGrabbedAfterSticker()
    {
        
        if (currentStep != TrainingStep.MarkerGrabbed)
            return;

        currentStep = TrainingStep.FinalGrabbed;
        Arrow16.SetActive(true); //final position arrow 
        UpperAfterSticker.Unhighlight();

        FinalStandSnapPoint.SetActive(true);
        foreach (var obj in grabObjectsToEnable)
        {
            if (obj != null)
            {
                obj.enabled = true;          // make grabbable
                obj.gameObject.SetActive(true); // ensure visible
                Debug.Log($"XRGrabInteractable enabled: {obj.name}");
            }
        }
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 40, subTitletxt);  // Now place the antenna sub assembly into the packing box and pack 12 antenna sub assembly at once in a row
        }
    }
    public void DoneFinal()
    {
        Debug.Log("ALL DONE MASTTTT");
        Arrow16.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(0, 41, subTitletxt);  //  Congratulation!
            StartCoroutine(ReloadAfterDelay(3f));
        }
    }

    private IEnumerator ReloadAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HandleReloadLogic();
    }
    private void HandleReloadLogic()
    {
        int reloadCount = PlayerPrefs.GetInt(reloadKey, 0);

        reloadCount++;
        PlayerPrefs.SetInt(reloadKey, reloadCount);
        PlayerPrefs.Save();

        Debug.Log($"Scene reload count: {reloadCount}");

        if (reloadCount < maxReloadCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            PlayerPrefs.SetInt(reloadKey, 0);
            PlayerPrefs.Save();
            Debug.Log("Reached max reloads — loading next scene!");
            SceneManager.LoadScene("P1TNG");
        }
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
