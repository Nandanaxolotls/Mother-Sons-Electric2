using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMP2TM4 : MonoBehaviour
{
    public ObjectActivator arrowActivator;
    public M1TooltipActivator tooltipActivator;
    public StepWiseHighlighter HighlightKey;
    public XRGrabInteractable GrabKey;
    public GameObject ScriptObjectKeySnapPoint;
    public GameObject SphereKey;
    public StepWiseHighlighter HighlightSphereKey;
    public KeySnapPoint keySnapPoint;
    public GameObject ScriptObjectKeyOnDrawerSnapPoint;
    public GameObject SphereKeyOnDrawer;
    public StepWiseHighlighter HighlightSphereKeyOnDrawer;
    public RemoteKeySnapPoint remoteKeySnapPoint;
    public GameObject DrawerScriptObject;
    public Drawer2 Drawer;
    public XRGrabInteractable GrabMainKeyFromDrawer;
    public GameObject KeyInDrawer;
    public XRGrabInteractable KeyGrabFromRemoteKey;
    public Collider KeyColliderGrabFromRemoteKey;
    public StepWiseHighlighter HighlightKeyFromRemote;
    public GameObject KeyOnTableSnapPointObject;
    public KeyOnTableP2M4SnapPoint KeyOnTableP2M4SnapPoint;

    public GameObject ScriptObjectNGBox;
    public GameObject NgSnapPointObject;
    public NGDrawer4P2 nGDrawer;
    public P2NG4SnapPoint p2NG4SnapPoint;
    public GameObject GoodKeyOnAssembly;
    public XRGrabInteractable GrabGoodKeyFromAssembly;
    public StepWiseHighlighter HighlightKey2;
    public XRGrabInteractable GrabKey2;
    public GameObject ScriptObjectKeySnapPoint2;
    public GameObject SphereKey2;
    public StepWiseHighlighter HighlightSphereKey2;
    public KeySnapPoint2 keySnapPoint2;
    public GameObject ScriptObjectKeyOnDrawerSnapPoint2;

    public RemoteKeySnapPoint2 remoteKeySnapPoint2;
    public XRGrabInteractable GrabMainKeyFromDrawer2;
    [Header(" Level ")]
    public TMP_Text subTitletxt;


    private int DrawerCloseCount = 0;
    private int DrawerOpenCount = 0;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public enum TrainingStep
    {
        None,
        KeyGrabbed,
        RemoteKeyGrabbed,
        KeyFromRemoteGrabbed,
        KeyFromAssyGrabbed,
        KeyGrabbed2,

    }

    public TrainingStep currentStep = TrainingStep.None;


    void Start()
    {
        arrowActivator.ActivateObject(26);
        HighlightKey.Highlight();
        GrabKey.enabled = true;
        keySnapPoint.KeySnapped += KeySnappedToKey;
        remoteKeySnapPoint.RemoteKeySnapped += KeySnappedToDrawer;
        Drawer.onReachedDesired += OnDrawerClosedDynamic;
        Drawer.onReachedOriginal += OnDrawerOpenedDynamic;
        KeyOnTableP2M4SnapPoint.KeySnappedToTable += KeySnappedToTable;
        nGDrawer.onReachedDesired += NGdrawerOpened;
        p2NG4SnapPoint.OnObjectActivated += NGKeySnappedToNGBox;
        nGDrawer.onReachedOriginal += NGDrawerClosed;
        keySnapPoint2.KeySnapped += Key2SnappedToKey;
        remoteKeySnapPoint2.RemoteKeySnapped += KeySnappedToDrawer2;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 96, subTitletxt); //Pick Emergency key from tray using right hand

        }
    }

    private void OnDrawerClosedDynamic()
    {
        DrawerCloseCount++;

        Debug.Log($"Drawer opened {DrawerCloseCount} times");

        switch (DrawerCloseCount)
        {
            case 1:
                DrawerClosingDone();
                break;
            case 2:
                DrawerClosingDone2();
                break;
            case 3:
               // NGdrawerOpeningDone3();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }
    private void OnDrawerOpenedDynamic()
    {
        DrawerOpenCount++;

        Debug.Log($"Drawer opened {DrawerOpenCount} times");

        switch (DrawerOpenCount)
        {
            case 1:
                DrawerOpeningDone();
                break;
            case 2:
                DrawerOpeningDone2();
                break;
            case 3:
                // NGdrawerOpeningDone3();
                break;
            default:
                Debug.Log("Drawer opened again, beyond the third time.");
                break;
        }
    }



    public void GrabbedKeyFromTray()
    {
        if (currentStep != TrainingStep.None)
            return;

        currentStep = TrainingStep.KeyGrabbed;
        arrowActivator.DeactivateObject(26);
        ScriptObjectKeySnapPoint.SetActive(true);
        SphereKey.SetActive(true);
        HighlightSphereKey.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 97, subTitletxt); //Insert Emergency key in the Remocon as highlighted
        }
    }
    public void KeySnappedToKey()
    {
        SphereKey.SetActive(false);
        arrowActivator.ActivateObject(27);
        ScriptObjectKeyOnDrawerSnapPoint.SetActive(true);
        SphereKeyOnDrawer.SetActive(true);
        HighlightSphereKeyOnDrawer.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 98, subTitletxt); //Go to Stage 5 which is Function Checker. Align and place the Remocon in the Function Checker as highlighted
        }
    }
    public void KeySnappedToDrawer()
    {
        SphereKeyOnDrawer.SetActive(false);
        arrowActivator.DeactivateObject(27);
        DrawerScriptObject.SetActive(true);
        tooltipActivator.ActivateObject(25);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 99, subTitletxt); //Close the door and Wait for the Result on monitor screen
        }
    }
    private void DrawerClosingDone()
    {
        DrawerClosed();
    }
    public void DrawerClosed()
    {
        //tooltipActivator.DeactivateObject(25);
        StartCoroutine(DisplayOfDrawerNG());
    }
    public IEnumerator DisplayOfDrawerNG()
    {
        Button1.SetActive(true);
        yield return new WaitForSeconds(5);
        Button1.SetActive(false);
        Button2.SetActive(true);
        Drawer.Unlock();
        tooltipActivator.ActivateObject(26);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 100, subTitletxt); //Open the door
        }
    }
    private void DrawerOpeningDone()
    {
        DrawerOpened();
    }
    public void DrawerOpened()
    {
        GrabMainKeyFromDrawer.enabled = true;
        arrowActivator.ActivateObject(27);
        KeyInDrawer.SetActive(true);
        Button2.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 101, subTitletxt); // Pick Remocon from Function Checker using left hand
        }
    }

    public void GrabbedKeyFromDrawer()
    {
        if (currentStep != TrainingStep.KeyGrabbed)
            return;

        currentStep = TrainingStep.RemoteKeyGrabbed;
        arrowActivator.DeactivateObject(27);
        KeyGrabFromRemoteKey.enabled = true;
        HighlightKeyFromRemote.Highlight();
        KeyColliderGrabFromRemoteKey.enabled=true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 102, subTitletxt); //It is a NG part so put this Remocon in the NG box
            StartCoroutine(SoundManager.instance.PlayDelayedSound(3, 103, subTitletxt, 4.2f)); // Before puting Remocon in the NG box first remove emergency key from Remocon 
        }
    }
    public void GrabbedKeyFromRemote()
    {
        if (currentStep != TrainingStep.RemoteKeyGrabbed)
            return;

        currentStep = TrainingStep.KeyFromRemoteGrabbed;
        KeyOnTableSnapPointObject.SetActive(true);
        arrowActivator.ActivateObject(26);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 104, subTitletxt); //Place Emergency key on the table as highlighted
        }
    }
    public void KeySnappedToTable()
    {
        arrowActivator.DeactivateObject(26);
        arrowActivator.ActivateObject(33);
        tooltipActivator.ActivateObject(30);
        ScriptObjectNGBox.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 105, subTitletxt); // Open the NG box
        }
    }

    public void NGdrawerOpened()
    {
        tooltipActivator.DeactivateObject(30);
        arrowActivator.DeactivateObject(33);
        arrowActivator.ActivateObject(34);
        NgSnapPointObject.SetActive(true);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 106, subTitletxt); //Place NG Remocon in the NG box
        }
    }
    public void NGKeySnappedToNGBox(GameObject obj)
    {
        arrowActivator.DeactivateObject(34);
        tooltipActivator.ActivateObject(31);
        nGDrawer.Unlock();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 107, subTitletxt); //Close the NG box
        }
    }
   
    
    public void NGDrawerClosed()
    {
        tooltipActivator.DeactivateObject(31);
        arrowActivator.ActivateObject(19);
        GoodKeyOnAssembly.SetActive(true);
        GrabGoodKeyFromAssembly.enabled=true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 108, subTitletxt); //Now pick another final Remocon of stage 4 from jig using left hand
        }

    }
    public void GrabbedGoodKeyFromAssembly()
    {
        if (currentStep != TrainingStep.KeyFromRemoteGrabbed)
            return;

        currentStep = TrainingStep.KeyFromAssyGrabbed;
        arrowActivator.DeactivateObject(19);
        arrowActivator.ActivateObject(26);
        HighlightKey2.Highlight();
        GrabKey2.enabled = true;
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 109, subTitletxt); //Pick Emergency key from tray using right hand
        }
    }
    public void GrabbedKey2FromTray()
    {
        if (currentStep != TrainingStep.KeyFromAssyGrabbed)
            return;

        currentStep = TrainingStep.KeyGrabbed2;
        arrowActivator.DeactivateObject(26);
        ScriptObjectKeySnapPoint2.SetActive(true);
        SphereKey2.SetActive(true);
        HighlightSphereKey2.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 110, subTitletxt); //Insert Emergency key in the Remocon as highlighted
        }
    }
    public void Key2SnappedToKey()
    {
        SphereKey2.SetActive(false);
        arrowActivator.ActivateObject(27);
        ScriptObjectKeyOnDrawerSnapPoint2.SetActive(true);
        SphereKeyOnDrawer.SetActive(true);
        HighlightSphereKeyOnDrawer.Highlight();
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 111, subTitletxt); //Go to Stage 5 which is Function Checker. Align and place the Remocon in the Function Checker as highlighted
        }
    }
    public void KeySnappedToDrawer2()
    {
        SphereKeyOnDrawer.SetActive(false);
        arrowActivator.DeactivateObject(27);
        tooltipActivator.ActivateObject(25);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 112, subTitletxt); //Close the door and Wait for the Result on monitor screen
        }
    }
    private void DrawerClosingDone2()
    {
        DrawerClosed2();
    }
    public void DrawerClosed2()
    {
        //tooltipActivator.DeactivateObject(25);
        StartCoroutine(DisplayOfDrawerOK());
    }
    public IEnumerator DisplayOfDrawerOK()
    {
        Button1.SetActive(true);
        yield return new WaitForSeconds(5);
        Button1.SetActive(false);
        Button3.SetActive(true);
        Drawer.Unlock();
        tooltipActivator.ActivateObject(26);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 113, subTitletxt); //Open the door
        }
    }
    private void DrawerOpeningDone2()
    {
        DrawerOpened2();
    }
    public void DrawerOpened2()
    {
        GrabMainKeyFromDrawer2.enabled = true;
        arrowActivator.ActivateObject(27);
        Button3.SetActive(false);
        if (GameManager.Instance.isTutorial)
        {
            SoundManager.instance.PlayVoiceOver(3, 114, subTitletxt); // Pick Remocon from Function Checker using left hand
        }
    }
    public void Key2GrabbedFromDrawer()
    {
        arrowActivator.DeactivateObject(27);

    }




    //Drawer2 closed 

}
