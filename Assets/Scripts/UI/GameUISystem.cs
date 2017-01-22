using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUISystem : MonoBehaviour {

    public static GameUISystem uiSystem;

    public enum UIState { BRIEF, HUD, WIN, LOSE, PAUSE };

    public GameObject HUDObject;
    public GameObject PauseUIObject;
    public GameObject WinUIObject;
    public GameObject LoseUIObject;
    public GameObject BriefGameObject;

    UIState state = UIState.HUD;
    GameObject currentUI;

	// Use this for initialization
	void Start () {
        uiSystem = this;
        if(HUDObject) HUDObject.SetActive(false);
        if(PauseUIObject) PauseUIObject.SetActive(false);
        if(WinUIObject) WinUIObject.SetActive(false);
        if(LoseUIObject) LoseUIObject.SetActive(false);
        if (BriefGameObject) BriefGameObject.SetActive(false);
        ChangeState(state);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeState(UIState _state)
    {
        state = _state;

        if (currentUI) currentUI.SetActive(false);

        switch(state)
        {
            case UIState.BRIEF:
                if (BriefGameObject) BriefGameObject.SetActive(true);
                currentUI = BriefGameObject;
                break;
            case UIState.HUD:
                if (HUDObject) HUDObject.SetActive(true);
                currentUI = HUDObject;
                break;
            case UIState.WIN:
                if (WinUIObject) WinUIObject.SetActive(true);
                currentUI = WinUIObject;
                Fade(1);
                break;
            case UIState.LOSE:
                if (LoseUIObject) LoseUIObject.SetActive(true);
                currentUI = LoseUIObject;
                Fade(0);
                break;
            case UIState.PAUSE:
                if (PauseUIObject) PauseUIObject.SetActive(true);
                currentUI = PauseUIObject;
                break;
        }
    }

    void Fade(int isWin)
    {
        Component[] comps;
        if (isWin == 1)
        {
            comps = WinUIObject.GetComponentsInChildren<Component>();
        }
        else
        {
            comps = LoseUIObject.GetComponentsInChildren<Component>();
        }

        foreach (Component c in comps)
        {
            if (c is Graphic)
            {
                (c as Graphic).CrossFadeAlpha(0, 1, true);
            }
        }
    }
}
