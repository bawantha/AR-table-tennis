// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

/**************
* Demo04_JS class
* This class handles "Demo04_JS (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

class Demo04_JS extends MonoBehaviour {

	// Canvas
	 var m_Canvas : Canvas;
	
	// GUIAnim objects of title text
	 var m_Title1 : GUIAnim;
	 var m_Title2 : GUIAnim;
	
	// GUIAnim objects of top and bottom bars
	 var m_TopBar : GUIAnim;
	 var m_BottomBar : GUIAnim;
	
	// GUIAnim object of dialogs
	 var m_Dialog1 : GUIAnim;
	 var m_Dialog2 : GUIAnim;
	 var m_Dialog3 : GUIAnim;
	 var m_Dialog4 : GUIAnim;
	
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
		
		// MoveIn m_Title1 m_Title2
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
	
	// Move In m_Title1 and m_Title2
	function MoveInTitleGameObjects () : IEnumerator {
		yield  WaitForSeconds(1.0f);
		
		// Move In m_Title1 and m_Title2
		m_Title1.MoveIn(eGUIMove.Self);
		m_Title2.MoveIn(eGUIMove.Self);
		
		// MoveIn dialogs
		StartCoroutine(MoveInPrimaryButtons());
	}
	
	// MoveIn dialogs
	function MoveInPrimaryButtons () : IEnumerator {
		yield  WaitForSeconds(1.0f);
		
		// MoveIn dialogs
		m_Dialog1.MoveIn(eGUIMove.SelfAndChildren);		
		m_Dialog2.MoveIn(eGUIMove.SelfAndChildren);		
		m_Dialog3.MoveIn(eGUIMove.SelfAndChildren);		
		m_Dialog4.MoveIn(eGUIMove.SelfAndChildren);
		
		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}
	
	function HideAllGUIs () : void {
		// MoveOut dialogs
		m_Dialog1.MoveOut(eGUIMove.SelfAndChildren);
		m_Dialog2.MoveOut(eGUIMove.SelfAndChildren);
		m_Dialog3.MoveOut(eGUIMove.SelfAndChildren);
		m_Dialog4.MoveOut(eGUIMove.SelfAndChildren);
		
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

	// Disable a button for a few seconds
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
	
	function OnButton_Dialog1 () : void {
		// MoveOut m_Dialog1
		m_Dialog1.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_Dialog1 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog1.gameObject, 2.0f));
		
		// Moves m_Dialog1 back to screen
		StartCoroutine(Dialog1_MoveIn());
	}
	
	function OnButton_Dialog2 () : void {
		// MoveOut m_Dialog2
		m_Dialog2.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_Dialog2 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog2.gameObject, 2.0f));
		
		// Moves m_Dialog2 back to screen
		StartCoroutine(Dialog2_MoveIn());
	}
	
	function OnButton_Dialog3 () : void {
		// MoveOut m_Dialog3
		m_Dialog3.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_Dialog3 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog3.gameObject, 2.0f));
		
		// Moves m_Dialog3 back to screen
		StartCoroutine(Dialog3_MoveIn());
	}
	
	function OnButton_Dialog4 () : void {
		// MoveOut m_Dialog4
		m_Dialog4.MoveOut(eGUIMove.SelfAndChildren);
		
		// Disable m_Dialog4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog4.gameObject, 2.0f));
		
		// Moves m_Dialog4 back to screen
		StartCoroutine(Dialog4_MoveIn());
	}
	
	function OnButton_MoveOutAllDialogs () : void {
		
		// Disable m_Dialog1, m_Dialog2, m_Dialog3, m_Dialog4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Dialog1.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Dialog2.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Dialog3.gameObject, 2.0f));
		StartCoroutine(DisableButtonForSeconds(m_Dialog4.gameObject, 2.0f));

		if(m_Dialog1.m_MoveOut.Began==false && m_Dialog1.m_MoveOut.Done==false)
		{
			// Move m_Dialog1 out
			m_Dialog1.MoveOut(eGUIMove.SelfAndChildren);
			// Move m_Dialog1 back to screen with Coroutines
			StartCoroutine(Dialog1_MoveIn());
		}
		if(m_Dialog2.m_MoveOut.Began==false && m_Dialog2.m_MoveOut.Done==false)
		{
			// Move m_Dialog2 out
			m_Dialog2.MoveOut(eGUIMove.SelfAndChildren);
			// Move m_Dialog2 back to screen with Coroutines
			StartCoroutine(Dialog2_MoveIn());
		}
		if(m_Dialog3.m_MoveOut.Began==false && m_Dialog3.m_MoveOut.Done==false)
		{
			// Move m_Dialog3 out
			m_Dialog3.MoveOut(eGUIMove.SelfAndChildren);
			// Move m_Dialog3 back to screen with Coroutines
			StartCoroutine(Dialog3_MoveIn());
		}
		if(m_Dialog4.m_MoveOut.Began==false && m_Dialog4.m_MoveOut.Done==false)
		{
			// Move m_Dialog4 out
			m_Dialog4.MoveOut(eGUIMove.SelfAndChildren);
			// Move m_Dialog4 back to screen with Coroutines
			StartCoroutine(Dialog4_MoveIn());
		}
	}
	
	// ######################################################################
	// Move dialog functions
	// ######################################################################
	
	// MoveIn m_Dialog1
	function Dialog1_MoveIn () : IEnumerator {
		yield  WaitForSeconds(1.5f);
		
		// Reset children of m_Dialog1
		m_Dialog1.ResetAllChildren();
		
		// Moves m_Dialog1 back to screen
		m_Dialog1.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	// MoveIn m_Dialog2
	function Dialog2_MoveIn () : IEnumerator {
		yield  WaitForSeconds(1.5f);
		
		// Reset children of m_Dialog2
		m_Dialog2.ResetAllChildren();
		
		// Moves m_Dialog1 back to screen
		m_Dialog2.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	// MoveIn m_Dialog3
	function Dialog3_MoveIn () : IEnumerator {
		yield  WaitForSeconds(1.5f);
		
		// Reset children of m_Dialog3
		m_Dialog3.ResetAllChildren();
		
		// Moves m_Dialog1 back to screen
		m_Dialog3.MoveIn(eGUIMove.SelfAndChildren);
	}
	
	// MoveIn m_Dialog4
	function Dialog4_MoveIn () : IEnumerator {
		yield  WaitForSeconds(1.5f);
		
		// Reset children of m_Dialog4
		m_Dialog4.ResetAllChildren();
		
		// Moves m_Dialog1 back to screen to screen
		m_Dialog4.MoveIn(eGUIMove.SelfAndChildren);
	}
}
