// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

/**************
* Demo01_JS class
* This class handles "Demo01_JS (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

class Demo01_JS extends MonoBehaviour {

	// Canvas
	 var m_Canvas : Canvas;

	// GUIAnim objects of title text
	 var m_Title1 : GUIAnim;
	 var m_Title2 : GUIAnim;
	
	// GUIAnim objects of top and bottom bars
	 var m_TopBar : GUIAnim;
	 var m_BottomBar : GUIAnim;
	
	// GUIAnim objects of TopLeft buttons
	 var m_TopLeft_A : GUIAnim;
	 var m_TopLeft_B : GUIAnim;
	
	// GUIAnim objects of BottomLeft buttons
	 var m_BottomLeft_A : GUIAnim;
	 var m_BottomLeft_B : GUIAnim;
	
	// GUIAnim objects of RightBar buttons
	 var m_RightBar_A : GUIAnim;
	 var m_RightBar_B : GUIAnim;
	 var m_RightBar_C : GUIAnim;

	// Toggle state of TopLeft, BottomLeft and BottomLeft buttons
	 protected var m_TopLeft_IsOn : boolean= false;
	 protected var m_BottomLeft_IsOn : boolean= false;
	 protected var m_RightBar_IsOn : boolean= false;
		
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
		yield WaitForSeconds(1.0f);

		// MoveIn m_Title1 and m_Title2
		m_Title1.MoveIn(eGUIMove.Self);
		m_Title2.MoveIn(eGUIMove.Self);
		
		// MoveIn all primary buttons
		StartCoroutine(MoveInPrimaryButtons());
	}
	
	// MoveIn all primary buttons
	function MoveInPrimaryButtons () : IEnumerator {
		yield  WaitForSeconds(1.0f);

		// MoveIn all primary buttons
		m_TopLeft_A.MoveIn(eGUIMove.Self);
		m_BottomLeft_A.MoveIn(eGUIMove.Self);
		m_RightBar_A.MoveIn(eGUIMove.Self);

		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}

	// MoveOut all primary buttons
	function HideAllGUIs () : void {
		m_TopLeft_A.MoveOut(eGUIMove.SelfAndChildren);
		m_BottomLeft_A.MoveOut(eGUIMove.SelfAndChildren);
		m_RightBar_A.MoveOut(eGUIMove.Self);
		
		if(m_TopLeft_IsOn == true)
			m_TopLeft_B.MoveOut(eGUIMove.SelfAndChildren);
		if(m_BottomLeft_IsOn == true)
			m_BottomLeft_B.MoveOut(eGUIMove.SelfAndChildren);
		if(m_RightBar_IsOn == true)
			m_RightBar_B.MoveOut(eGUIMove.SelfAndChildren);
		
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
	
	function OnButton_TopLeft () : void {
		// Disable m_TopLeft_A, m_RightBar_A, m_RightBar_C, m_BottomLeft_A for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_TopLeft_A.gameObject, 0.3f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_A.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_C.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_BottomLeft_A.gameObject, 0.3f));

		// Toggle m_TopLeft
		ToggleTopLeft();

		// Toggle other buttons
		if(m_BottomLeft_IsOn==true)
		{
			ToggleBottomLeft();
		}
		if(m_RightBar_IsOn==true)
		{
			ToggleRightBar();
		}
	}

	function OnButton_BottomLeft () : void {
		// Disable m_TopLeft_A, m_RightBar_A, m_RightBar_C, m_BottomLeft_A for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_TopLeft_A.gameObject, 0.3f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_A.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_C.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_BottomLeft_A.gameObject, 0.3f));

		// Toggle m_BottomLeft
		ToggleBottomLeft();
		
		// Toggle other buttons
		if(m_TopLeft_IsOn==true)
		{
			ToggleTopLeft();
		}
		if(m_RightBar_IsOn==true)
		{
			ToggleRightBar();
		}
		
	}
	
	function OnButton_RightBar () : void {
		// Disable m_TopLeft_A, m_RightBar_A, m_RightBar_C, m_BottomLeft_A for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_TopLeft_A.gameObject, 0.3f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_A.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_RightBar_C.gameObject, 0.6f));
		StartCoroutine(DisableButtonForSeconds(m_BottomLeft_A.gameObject, 0.3f));

		// Toggle m_RightBar
		ToggleRightBar();
		
		// Toggle other buttons
		if(m_TopLeft_IsOn==true)
		{
			ToggleTopLeft();
		}
		if(m_BottomLeft_IsOn==true)
		{
			ToggleBottomLeft();
		}

	}
		
	// ######################################################################
	// Toggle button functions
	// ######################################################################
	
	// Toggle TopLeft buttons
	function ToggleTopLeft () : void {
		m_TopLeft_IsOn = !m_TopLeft_IsOn;
		if(m_TopLeft_IsOn==true)
		{
			// m_TopLeft_B moves in
			m_TopLeft_B.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_TopLeft_B moves out
			m_TopLeft_B.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle BottomLeft buttons
	function ToggleBottomLeft () : void {
		m_BottomLeft_IsOn = !m_BottomLeft_IsOn;
		if(m_BottomLeft_IsOn==true)
		{
			// m_BottomLeft_B moves in
			m_BottomLeft_B.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_BottomLeft_B moves out
			m_BottomLeft_B.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle RightBar buttons
	function ToggleRightBar () : void {
		m_RightBar_IsOn = !m_RightBar_IsOn;
		if(m_RightBar_IsOn==true)
		{
			// m_RightBar_A moves out
			m_RightBar_A.MoveOut(eGUIMove.SelfAndChildren);
			// m_RightBar_B moves in
			m_RightBar_B.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_RightBar_A moves in
			m_RightBar_A.MoveIn(eGUIMove.SelfAndChildren);
			// m_RightBar_B moves out
			m_RightBar_B.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
}