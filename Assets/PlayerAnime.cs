using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum P_Anime
{
    Default1,
    Default2,
    Jump,
    Zyaku1,
    Zyaku2,
}

public class PlayerAnime : StateMachineBehaviour {
    bool Activated;
    P_Anime p_anime;

    GameObject player;
    TestPlayer player_ins;

    int p_state;
    void TestFunc(bool _boolen)
    {
        Activated = _boolen;
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        player = GameObject.Find("TestPlayer");
        player_ins = player.GetComponent<TestPlayer>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //プレイヤー側のChangeAnimeFlagを監視してOnになったらAnimatorの数値を弄る
        if(player_ins.ChangeAnimeFlag)
        {
            animator.SetInteger("Status", player_ins.ChangeAnimeState);
            //p_state = player_ins.ChangeAnimeState;
            player_ins.ChangeAnimeFlag = false;
        }
    }
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
    //
    //}

    // OnStateMachineExit is called when exiting a statemachine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
    //
    //}
}
