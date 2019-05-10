// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

/**************
* Demo07_JS class
* This class handles "Demo07_JS (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

class Demo07_JS extends MonoBehaviour {

	// Canvas
	 var m_Canvas : Canvas;
	
	// GUIAnim objects of title text
	 var m_Title1 : GUIAnim;
	 var m_Title2 : GUIAnim;
	
	// GUIAnim objects of top and bottom bars
	 var m_TopBar : GUIAnim;
	 var m_BottomBar : GUIAnim;
	
	// GUIAnim object of dialogs
	 var m_Dialog : GUIAnim;
	 var m_DialogButtons : GUIAnim;
	
	// GUIAnim objects of buttons
	 var m_Button1 : GUIAnim;
	 var m_Button2 : GUIAnim;
	 var m_Button3 : GUIAnim;
	 var m_Button4 : GUIAnim;
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################
	
	// Use this for initialization
	function Awake () : void {
		//////////////////////////////////////////////////////////////////////
		// If you want to control all GUIAnim elements in the scene via scripts, you have to call these line in Awake function.
		// Otherwise, GUIAnimSystem will run all GUIAnim elements automatically.
		//
		// If you disable this component by uncheck it from the GameObject that it is attached,
		// the GUIAnimSystem will control all animations in the scene according to selected animations in Auto Animation of GUIAnimSystem.
		//////////////////////////////////////////////////////////////////////
		if(enabled)
		{
			// Use this script to control all animations in the scene instead of GUIAnimSystem auto test.
			GUIAnimSystem.Instance.m_AutoAnimation = false;
		}
	}
	
	// Use this for initialization
	function Start () : void {
		// MoveIn m_TopBar and m_BottomBar
		m_TopBar.MoveIn(eGUIMove.SelfAndChildren);
		m_BottomBar.MoveIn(eGUIMove.SelfAndChildren);
		
		// MoveIn m_Title1 and m_Title2
		StartCoroutine(MoveInTitleGameObjects());
		
		// Disable all scene switch buttons
		GUIAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, false);
	}
	
	// Update is called once per frame
	function Update () : void {
		
	}
	
	// ######################################################################
	// MoveIn/MoveOut functions
	// ######################################################################
	
	// MoveIn m_Title1 and m_Title2
	function MoveInTitleGameObjects () : IEnumerator {
		yield  WaitForSeconds(1.0f);
		
		// MoveIn m_Title1 and m_Title2
		m_Title1.MoveIn(eGUIMove.Self);
		m_Title2.MoveIn(eGUIMove.Self);
		
		// MoveIn all dialogs and buttons
		StartCoroutine(MoveInPrimaryButtons());
	}
	
	// MoveIn all dialogs and buttons
	function MoveInPrimaryButtons () : IEnumerator {
		yield  WaitForSeconds(1.0f);
		
		// MoveIn all dialogs
		m_Dialog.MoveIn(eGUIMove.SelfAndChildren);
		m_DialogButtons.MoveIn(eGUIMove.SelfAndChildren);
		
		// MoveIn all buttons
		m_Button1.MoveIn(eGUIMove.SelfAndChildren);	
		m_Button2.MoveIn(eGUIMove.SelfAndChildren);	
		m_Button3.MoveIn(eGUIMove.SelfAndChildren);	
		m_Button4.MoveIn(eGUIMove.SelfAndChildren);
		
		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}
	
	// MoveOut all dialogs and buttons
	function HideAllGUIs () : void {
		// MoveOut all dialogs
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		m_DialogButtons.MoveOut(eGUIMove.SelfAndChildren);
		
		// MoveOut all buttons
		m_Button1.MoveOut(eGUIMove.SelfAndChildren);
		m_Button2.MoveOut(eGUIMove.SelfAndChildren);
		m_Button3.MoveOut(eGUIMove.SelfAndChildren);
		m_Button4.MoveOut(eGUIMove.SelfAndChildren);
		
		// MoveOut m_Title1 and m_Title2
		StartCoroutine(HideTitleTextMeshes());
	}
	
	// MoveOut m_Title1 and m_Title2
	function HideTitleTextMeshes () : IEnumerator {
		yield  WaitForSeconds(1.0f);
		
		// MoveOut m_Title1 and m_Title2
		m_Title1.MoveOut(eGUIMove.Self);
		m_Title2.MoveOut(eGUIMove.Self);
		
		// MoveOut m_TopBar and m_BottomBar
		m_TopBar.MoveOut(eGUIMove.SelfAndChildren);
		m_BottomBar.MoveOut(eGUIMove.SelfAndChildren);
	}
	
	// ######################################################################
	// Enable/Disable button functions
	// ######################################################################
	
	// Enable/Disable all scene switch Coroutine
	function EnableAllDemoButtons () : IEnumerator {
		yield  WaitForSeconds(1.0f);
		
		// Enable all scene switch buttons
		GUIAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, true);
	}

	// Disable all buttons for a few seconds
	function DisableButtonForSeconds ( GO : GameObject ,   DisableTime : float  ) : IEnumerator {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableButton(GO.transform, false);
		
		yield  WaitForSeconds(DisableTime);
		
		// Enable all buttons
		GUIAnimSystem.Instance.EnableButton(GO.transform, true);
	}
	
	// ######################################################################
	// Button handler functions
	// ######################################################################

	function OnButton_1 () : void {
		// MoveOut m_Button1
		MoveButtonsOut();
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));

		// Set next move in of m_Button1 to new position
		StartCoroutine(SetButtonMove(ePosMove.UpperScreenEdge, ePosMove.UpperScreenEdge));
	}
	
	function OnButton_2 () : void {
		// MoveOut m_Button2
		MoveButtonsOut();
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));
		
		// Set next move in of m_Button2 to new position
		StartCoroutine(SetButtonMove(ePosMove.LeftScreenEdge, ePosMove.LeftScreenEdge));
	}
	
	function OnButton_3 () : void {
		// MoveOut m_Button3
		MoveButtonsOut();
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));

		// Set next move in of m_Button3 to new position
		StartCoroutine(SetButtonMove(ePosMove.RightScreenEdge, ePosMove.RightScreenEdge));
	}
	
	function OnButton_4 () : void {
		// MoveOut m_Button4
		MoveButtonsOut();
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));
		
		// Set next move in of m_Button3 to new position
		StartCoroutine(SetButtonMove(ePosMove.BottomScreenEdge, ePosMove.BottomScreenEdge));
	}
	
	function OnDialogButton () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		m_DialogButtons.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_DialogButtons for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_DialogButtons.gameObject, 2.0f));

		// Moves m_Dialog back to screen
		StartCoroutine(DialogMoveIn());
	}
	
	// ######################################################################
	// Move Dialog/Button functions
	// ######################################################################
	
	// MoveOut all buttons
	function MoveButtonsOut () : void {
		m_Button1.MoveOut(eGUIMove.SelfAndChildren);
		m_Button2.MoveOut(eGUIMove.SelfAndChildren);
		m_Button3.MoveOut(eGUIMove.SelfAndChildren);
		m_Button4.MoveOut(eGUIMove.SelfAndChildren);
	}
	
	// Set next move in of all buttons to new position
	function SetButtonMove ( PosMoveIn : ePosMove ,   PosMoveOut : ePosMove  ) : IEnumerator {
		yield  WaitForSeconds(2.0f);
		
		// Set next MoveIn position of m_Button1 to PosMoveIn
		m_Button1.m_MoveIn.MoveFrom = PosMoveIn;
		// Reset m_Button1
		m_Button1.Reset();
		// MoveIn m_Button1
		m_Button1.MoveIn(eGUIMove.SelfAndChildren);
		
		// Set next MoveIn position of m_Button2 to PosMoveIn
		m_Button2.m_MoveIn.MoveFrom = PosMoveIn;
		// Reset m_Button2
		m_Button2.Reset();
		// MoveIn m_Button2
		m_Button2.MoveIn(eGUIMove.SelfAndChildren);
		
		// Set next MoveIn position of m_Button3 to PosMoveIn
		m_Button3.m_MoveIn.MoveFrom = PosMoveIn;
		// Reset m_Button3
		m_Button3.Reset();
		// MoveIn m_Button3
		m_Button3.MoveIn(eGUIMove.SelfAndChildren);
		
		// Set next MoveIn position of m_Button4 to PosMoveIn
		m_Button4.m_MoveIn.MoveFrom = PosMoveIn;
		// Reset m_Button4
		m_Button4.Reset();
		// MoveIn m_Button4
		m_Button4.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	// Moves m_Dialog back to screen
	function DialogMoveIn () : IEnumerator {
		yield  WaitForSeconds(1.5f);
		
		m_Dialog.MoveIn(eGUIMove.SelfAndChildren);
		m_DialogButtons.MoveIn(eGUIMove.SelfAndChildren);
	}
}
