// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

/**************
* Demo02_JS class
* This class handles "Demo02_JS (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

class Demo02_JS extends MonoBehaviour {

	// Canvas
	var m_Canvas : Canvas;
	
	// GUIAnim objects of Title text
	 var m_Title1 : GUIAnim;
	 var m_Title2 : GUIAnim;
	
	// GUIAnim objects of Top and bottom
	 var m_TopBar : GUIAnim;
	 var m_BottomBar : GUIAnim;
	
	// GUIAnim object of Dialog
	 var m_Dialog : GUIAnim;
	
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
		
		// MoveIn m_Dialog
		StartCoroutine(ShowDialog());
	}
	
	// MoveIn m_Dialog
	function ShowDialog () : IEnumerator {
		yield  WaitForSeconds(1.0f);
		
		// MoveIn m_Dialog
		m_Dialog.MoveIn(eGUIMove.SelfAndChildren);
		
		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}
	
	// MoveOut m_Dialog
	function HideAllGUIs () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
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
	function DisableAllButtonsForSeconds ( DisableTime : float  ) : IEnumerator {
		// Disable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(false);
		
		yield  WaitForSeconds(DisableTime);
		
		// Enable all buttons
		GUIAnimSystem.Instance.EnableAllButtons(true);
	}
	
	// ######################################################################
	// Button handler functions
	// ######################################################################

	function OnButton_UpperEdge () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);

		// MoveIn m_Dialog from top
		StartCoroutine(DialogMoveIn(ePosMove.UpperScreenEdge));
	}
	
	function OnButton_LeftEdge () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// MoveIn m_Dialog from left
		StartCoroutine(DialogMoveIn(ePosMove.LeftScreenEdge));
	}
	
	function OnButton_RightEdge () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from right
		StartCoroutine(DialogMoveIn(ePosMove.RightScreenEdge));
	}
	
	function OnButton_BottomEdge () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from bottom
		StartCoroutine(DialogMoveIn(ePosMove.BottomScreenEdge));
	}
	
	function OnButton_UpperLeft () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from upper left
		StartCoroutine(DialogMoveIn(ePosMove.UpperLeft));
	}
	
	function OnButton_UpperRight () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from upper right
		StartCoroutine(DialogMoveIn(ePosMove.UpperRight));
	}
	
	function OnButton_BottomLeft () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from bottom left
		StartCoroutine(DialogMoveIn(ePosMove.BottomLeft));
	}
	
	function OnButton_BottomRight () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from bottom right
		StartCoroutine(DialogMoveIn(ePosMove.BottomRight));
	}
	
	function OnButton_Center () : void {
		// MoveOut m_Dialog
		m_Dialog.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
		// MoveIn m_Dialog from center of screen
		StartCoroutine(DialogMoveIn(ePosMove.MiddleCenter));
	}
	
	// ######################################################################
	// Move dialog functions
	// ######################################################################

	// MoveIn m_Dialog by position
	function DialogMoveIn ( PosMoveIn : ePosMove  ) : IEnumerator {
		yield  WaitForSeconds(1.5f);
		
		//Debug.Log("PosMoveIn="+PosMoveIn);
		switch(PosMoveIn)
		{
			// Set m_Dialog to move in from upper
			case ePosMove.UpperScreenEdge:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.UpperScreenEdge;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from left
			case ePosMove.LeftScreenEdge:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.LeftScreenEdge;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from right
			case ePosMove.RightScreenEdge:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.RightScreenEdge;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from bottom
			case ePosMove.BottomScreenEdge:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.BottomScreenEdge;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from upper left
			case ePosMove.UpperLeft:	
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.UpperLeft;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from upper right
			case ePosMove.UpperRight:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.UpperRight;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from bottom left
			case ePosMove.BottomLeft:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.BottomLeft;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from bottom right
			case ePosMove.BottomRight:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.BottomRight;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			// Set m_Dialog to move in from center
			case ePosMove.MiddleCenter:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.MiddleCenter;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
			default:
				m_Dialog.m_MoveIn.MoveFrom = ePosMove.MiddleCenter;
				m_Dialog.m_MoveOut.MoveTo = ePosMove.MiddleCenter;
				break;
		}

		// Reset m_Dialog
		m_Dialog.Reset();

		// MoveIn m_Dialog by position
		m_Dialog.MoveIn(eGUIMove.SelfAndChildren);
	}
	
}