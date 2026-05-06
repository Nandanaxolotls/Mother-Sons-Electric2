using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP2TM6 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    public GameObject SphereObjectRemoteOnBox;
    public StepWiseHighlighter HighlightSphereObjectRemoteOnBox;
    public GameObject RemoteKeySnapPointOnBox;
    public RemoteKeyInBoxSnapPoint remoteKeyInBoxSnapPoint;
    public GameObject ScriptObjectBoxDoor;
    public BoxDoorMovement boxDoorMovement;
    public XRGrabInteractable RemoteGrabFromBox;
    public StepWiseHighlighter KeyInRemote;
    public XRGrabInteractable KeyGrabbedFromRemote;
    public Collider KeyColliderOfRemote;

    public GameObject SphereKeyOnTable;
    public StepWiseHighlighter HighlightSphereKeyOnTable;

    public GameObject ScriptObjectKeyOnTableSnapPoint;
    public GameObject FinalKeyOnTraySnapPoint;
    public KeyOnTableSnapPoint keyOnTableSnapPoint;
    public GameObject ScriptObjectNGBox;
    public GameObject NgSnapPointObject;
    public NGDrawer6P2 nGDrawer;
    public P2NG6SnapPoint p2NG6SnapPoint;
    public GameObject KeyOnTable;

    public GameObject GoodKeyOnLaser;
    public XRGrabInteractable GrabGoodKeyFromLaser;
    public StepWiseHighlighter HighlightGoodKeyOnLaser;
    public GameObject RemoteKeySnapPointOnBox2;
    public RemoteKeyInBoxSnapPoint2 remoteKeyInBoxSnapPoint2;
    public XRGrabInteractable RemoteGrabFromBox2;
    public StepWiseHighlighter KeyInRemote2;
    public XRGrabInteractable KeyGrabbedFromRemote2;
    public Collider KeyColliderOfRemote2;
    public GameObject ScriptObjectKeyOnTableSnapPoint2;
    public KeyOnTableSnapPoint2 keyOnTableSnapPoint2;


    public FinalKeyInBoxSnapPoint finalKeyInBoxSnapPoint;
    public GameObject CongratsMessage;
    public GameObject Button7;
    public GameObject Button8NG;
    public GameObject Button8Ok;
    [Header(" Level ")]
    public TMP_Text subTitletxt;

    private int DoorCloseCount = 0;
    private int DoorOpenCount = 0;
    public enum TrainingStep
    {
        None,
        RemoteFromBoxGrabbed,
        KeyGrabbed,
        GoodKeyFromLaserGrabbed,
        RemoteFromBoxGrabbed2,
        KeyGrabbed2,
    }

    public TrainingStep currentStep = TrainingStep.None;

    void Start()
    {
        arrowActivator.ActivateObject(29);
        SphereObjectRemoteOnBox.SetActive(true);
        HighlightSphereObjectRemoteOnBox.Highlight();
        RemoteKeySnapPointOnBox.SetActive(true);
        remoteKeyInBoxSnapPoint.RemoteKeySnappedToBox += RemoteKeySnappedToBox;
        boxDoorMovement.onReachedDesired += OnDoorClosedDynamic;
        boxDoorMovement.onReachedOriginal += OnDoorOpenedDynamic;
        keyOnTableSnapPoint.KeySnappedToTable += KeySnappedToTable;
        nGDrawer.onReachedDesired += NGdrawerOpened;
        p2NG6SnapPoint.OnObjectActivated += NGKeySnappedToNGBox;
        nGDrawer.onReachedOriginal += NGdrawerClosed;
        remoteKeyInBoxSnapPoint2.RemoteKeySnappedToBox += RemoteKeySnappedToBox2;
        keyOnTableSnapPoint2.KeySnappedToTable += KeySnappedToTable2;
        finalKeyInBoxSnapPoint.FinalKeySnapped += FinalKeySnappedToBox;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 128, subTitletxt); //Now, Move to Stage 7 which is LF Reception sensitivity check. Align and place the Remocon onto the jig as highlighted
        }
    }
    private void OnDoorClosedDynamic()
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
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDoorOpenedDynamic()
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
                //ThirdDrawerOpen();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    public void RemoteKeySnappedToBox()
    {
        arrowActivator.DeactivateObject(29);
        SphereObjectRemoteOnBox.SetActive(false);
        tooltipActivator.ActivateObject(27);
        ScriptObjectBoxDoor.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 129, subTitletxt); //Close the door and Wait for the Result on monitor screen
        }
    }
    private void DoorClosingDone()
    {
        BoxDoorClosed();
    }
    public void BoxDoorClosed()
    {
        StartCoroutine(DisplayCheckingStartNG());   
    }
    public IEnumerator DisplayCheckingStartNG()
    {
        Button7.SetActive(true);
        yield return new WaitForSeconds(5);
        Button7.SetActive(false);
        Button8NG.SetActive(true);
        boxDoorMovement.Unlock();
        tooltipActivator.ActivateObject(28);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 130, subTitletxt); //Open the door
        }
    }
    private void DoorOpeningDone()
    {
        BoxDoorOpened();
    }
    public void BoxDoorOpened()
    {
        tooltipActivator.DeactivateObject(28);
        RemoteGrabFromBox.enabled = true;
        arrowActivator.ActivateObject(30);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 131, subTitletxt); //Pick Remocon from LF Reception sensitivity check using left hand
        }
    }
    public void GrabbedRemoteKeyFromBox()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.RemoteFromBoxGrabbed;
        arrowActivator.DeactivateObject(30);
        KeyInRemote.Highlight();
        KeyGrabbedFromRemote.enabled = true;
        KeyColliderOfRemote.enabled = true;
        tooltipActivator.ActivateObject(29);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 132, subTitletxt); //It is a NG part so put this Remocon in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 133, subTitletxt, 4.2f)); // Before puting Remocon in the NG box first remove emergency key from Remocon 
        }
    }
    public void KeyGrabFromRemote()
    {
        if (currentStep != TrainingStep.RemoteFromBoxGrabbed)
            return;

        currentStep = TrainingStep.KeyGrabbed;
        arrowActivator.ActivateObject(31);
        tooltipActivator.DeactivateObject(29);
        //  KeyInRemoteAfterRemoved.SetActive(false);
        ScriptObjectKeyOnTableSnapPoint.SetActive(true);
        SphereKeyOnTable.SetActive(true);
        HighlightSphereKeyOnTable.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 134, subTitletxt); //Place Emergency key on the table as highlighted
        }
    }
    public void KeySnappedToTable()
    {
        SphereKeyOnTable.SetActive(false);
        arrowActivator.DeactivateObject(31);
        arrowActivator.ActivateObject(37);
        tooltipActivator.ActivateObject(34);
        ScriptObjectNGBox.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 135, subTitletxt); //Open the NG box
        }
    }
    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(34);
        arrowActivator.DeactivateObject(37);
        arrowActivator.ActivateObject(38);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 136, subTitletxt); //Place NG Remocon in the NG box
        }
    }
    public void NGKeySnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(38);
        tooltipActivator.ActivateObject(35);
        nGDrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 137, subTitletxt); //Close the NG box
        }
    }
    public void NGdrawerClosed()
    {
        tooltipActivator.DeactivateObject(35);
        arrowActivator.ActivateObject(28);
        GoodKeyOnLaser.SetActive(true);
        GrabGoodKeyFromLaser.enabled = true;
        HighlightGoodKeyOnLaser.Highlight();
        KeyOnTable.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 138, subTitletxt); //Now pick another final Remocon from Immobi communication checker jig using left hand
        }
    }
    public void GoodKeyGrabbedFromLaser()
    {
        if (currentStep != TrainingStep.KeyGrabbed)
            return;

        currentStep = TrainingStep.GoodKeyFromLaserGrabbed;
        arrowActivator.DeactivateObject(28);
        arrowActivator.ActivateObject(29);
        arrowActivator.ActivateObject(30);
        SphereObjectRemoteOnBox.SetActive(true);
        HighlightSphereObjectRemoteOnBox.Highlight();
        RemoteKeySnapPointOnBox2.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 139, subTitletxt); //Now, Move to Stage 7 which is LF Reception sensitivity check. Align and place the Remocon onto the jig as highlighted
        }
    }
    public void RemoteKeySnappedToBox2()
    {
        arrowActivator.DeactivateObject(29);
        arrowActivator.DeactivateObject(30);
        SphereObjectRemoteOnBox.SetActive(false);
        tooltipActivator.ActivateObject(27);
        ScriptObjectBoxDoor.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 140, subTitletxt); //Close the door and Wait for the Result on monitor screen
        }
    }
    private void DoorClosingDone2()
    {
        BoxDoorClosed2();
    }
    public void BoxDoorClosed2()
    {
        StartCoroutine(DisplayCheckingStartOK());

    }
    public IEnumerator DisplayCheckingStartOK()
    {
        Button8NG.SetActive(false);
        Button7.SetActive(true);
        yield return new WaitForSeconds(5);
        Button7.SetActive(false);
        Button8Ok.SetActive(true);
        boxDoorMovement.Unlock();
        tooltipActivator.ActivateObject(28);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 141, subTitletxt); //Open the door
        }
    }
    private void DoorOpeningDone2()
    {
        BoxDoorOpened2();
    }
    public void BoxDoorOpened2()
    {
        tooltipActivator.DeactivateObject(28);
        RemoteGrabFromBox2.enabled = true;
        arrowActivator.ActivateObject(30);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 142, subTitletxt); //Pick Remocon from LF Reception sensitivity check using left hand
        }
    }
    public void GrabbedRemoteKey2FromBox()
    {
        if (currentStep != TrainingStep.GoodKeyFromLaserGrabbed)
            return;

        currentStep = TrainingStep.RemoteFromBoxGrabbed2;
        arrowActivator.DeactivateObject(30);
        KeyInRemote2.Highlight();
        KeyGrabbedFromRemote2.enabled = true;
        KeyColliderOfRemote2.enabled = true;
        tooltipActivator.ActivateObject(36);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 143, subTitletxt); // Remove the Emergency Key from the Remocon by grabbing it with the right hand
        }
    }
    public void Key2GrabFromRemote()
    {
        if (currentStep != TrainingStep.RemoteFromBoxGrabbed2)
            return;

        currentStep = TrainingStep.KeyGrabbed2;
        arrowActivator.ActivateObject(31);
        tooltipActivator.DeactivateObject(36);
        //  KeyInRemoteAfterRemoved.SetActive(false);
        ScriptObjectKeyOnTableSnapPoint2.SetActive(true);
        SphereKeyOnTable.SetActive(true);
        HighlightSphereKeyOnTable.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 144, subTitletxt); // Place Emergency key on the table as highlighted
        }
    }
    public void KeySnappedToTable2()
    {
        SphereKeyOnTable.SetActive(false);
        arrowActivator.DeactivateObject(31);
        FinalKeyOnTraySnapPoint.SetActive(true);
        arrowActivator.ActivateObject(32);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 145, subTitletxt); //  Now, Move to Stage 8 which is packing and place Remocon in the tray
        }
    }
    public void FinalKeySnappedToBox()
    {
        arrowActivator.DeactivateObject(32);
        CongratsMessage.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 146, subTitletxt); //Congratulations!
        }
    }

}