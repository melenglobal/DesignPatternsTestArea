using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject Actor;

    private Animator anim;

    private Command keyQ, keyA, keyE,keyP,keyK,upArrow;

    private List<Command> OldCommands = new List<Command>();

    private Coroutine replayCoroutine;
    
    private bool shouldStartdReplay;
    
    private bool isReplaying;

    // Start is called before the first frame update
    void Start()
    {
        anim = Actor.GetComponent<Animator>();
        Camera.main.GetComponent<CameraFollow360>().player = Actor.transform;
        upArrow = new MoveForward();
        keyQ = new PerformJump();
        keyA = new DoNothing();
        keyE = new DoNothing();
        keyP = new PerformPunch();
        keyK = new PerformKick();
    }

    // Update is called once per frame
    void Update()
    {   
        // Get Input
        if (!isReplaying)
        {
            HandleInput();
        }

        StartReplay();
    }
    
    #region Animation Command Inputs
    private void HandleInput()
    {
        //PerformJump
        if (Input.GetKeyDown(KeyCode.Q))
        {
            keyQ.Execute(anim,true);
            OldCommands.Add(keyQ);
        }
        //Do nothing
        else if (Input.GetKeyDown(KeyCode.A))
        {
            keyE.Execute(anim,true);
            OldCommands.Add(keyE);
        }
        //Do nothing
        else if (Input.GetKeyDown(KeyCode.E))
        {
            keyA.Execute(anim,true);
            OldCommands.Add(keyA);
        }
        //Perform Punch
        else if (Input.GetKeyDown((KeyCode.P)))
        {
            keyP.Execute(anim,true);
            OldCommands.Add(keyP);
        }
        // Perform Kick
        else if (Input.GetKeyDown(KeyCode.K))
        {
            keyK.Execute(anim,true);
            OldCommands.Add(keyK);
        }
        else if (Input.GetKey((KeyCode.UpArrow)))
        {
            upArrow.Execute(anim,true);
            OldCommands.Add(upArrow);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldStartdReplay = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastCommand();
        }
        
    }
    #endregion

    private void UndoLastCommand()
    {
        if (OldCommands.Count > 0)
        {
            Command c = OldCommands[OldCommands.Count - 1];
            c.Execute(anim,false);
            OldCommands.RemoveAt(OldCommands.Count - 1);
        }
    }
    private void StartReplay()
    {
        if(shouldStartdReplay && OldCommands.Count > 0)
        {
            shouldStartdReplay = false;
            
            if (replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }

            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    IEnumerator ReplayCommands()
    {
        isReplaying = true;
        
        for (int i = 0; i < OldCommands.Count; i++)
        {
            OldCommands[i].Execute(anim,true);
            yield return new WaitForSeconds(1f);
        }

        isReplaying = false;
    }
}
