// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

/**************
* Demo08_JS class
* This class handles "Demo08_JS (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

class Demo08_JS extends MonoBehaviour {

	// Canvas
	 var m_Canvas : Canvas;
	
	// GUIAnim objects of title text
	 var m_Title1 : GUIAnim;
	 var m_Title2 : GUIAnim;
	
	// GUIAnim objects of top and bottom bars
	 var m_TopBar : GUIAnim;
	 var m_BottomBar : GUIAnim;
	
	// GUIAnim objects of 4 primary buttons
	 var m_CenterButtons : GUIAnim;
	
	// GUIAnim objects of buttons
	 var m_Button1 : GUIAnim;
	 var m_Button2 : GUIAnim;
	 var m_Button3 : GUIAnim;
	 var m_Button4 : GUIAnim;

	// GUIAnim objects of top, left, right and bottom bars
	 var m_Bar1 : GUIAnim;
	 var m_Bar2 : GUIAnim;
	 var m_Bar3 : GUIAnim;
	 var m_Bar4 : GUIAnim;
	
	// Toggle state of top, left, right and bottom bars
	 protected var m_Bar1_IsOn : boolean= false;
	 protected var m_Bar2_IsOn : boolean= false;
	 protected var m_Bar3_IsOn : boolean= false;
	 protected var m_Bar4_IsOn : boolean= false;
	
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
		
		// MoveIn all primary buttons
		StartCoroutine(MoveInPrimaryButtons());
	}
	
	// MoveIn all primary buttons
	function MoveInPrimaryButtons () : IEnumerator {
		yield  WaitForSeconds(1.0f);
		
		// MoveIn all primary buttons
		m_CenterButtons.MoveIn(eGUIMove.SelfAndChildren);
		
		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}
	
	// MoveOut all primary buttons
	function HideAllGUIs () : void {
		// MoveOut all primary buttons
		m_CenterButtons.MoveOut(eGUIMove.SelfAndChildren);
		
		// MoveOut all side bars
		if(m_Bar1_IsOn==true)
			m_Bar1.MoveOut(eGUIMove.SelfAndChildren);
		if(m_Bar2_IsOn==true)
			m_Bar2.MoveOut(eGUIMove.SelfAndChildren);
		if(m_Bar3_IsOn==true)
			m_Bar3.MoveOut(eGUIMove.SelfAndChildren);
		if(m_Bar4_IsOn==true)
			m_Bar4.MoveOut(eGUIMove.SelfAndChildren);
		
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
		// Toggle m_Bar1
		ToggleBar1();
		
		// Toggle other bars
		if(m_Bar2_IsOn==true)
		{
			ToggleBar2();
		}
		if(m_Bar3_IsOn==true)
		{
			ToggleBar3();
		}
		if(m_Bar4_IsOn==true)
		{
			ToggleBar4();
		}
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 0.75f));
	}
	
	function OnButton_2 () : void {
		// Toggle m_Bar2
		ToggleBar2();
		
		// Toggle other bars
		if(m_Bar1_IsOn==true)
		{
			ToggleBar1();
		}
		if(m_Bar3_IsOn==true)
		{
			ToggleBar3();
		}
		if(m_Bar4_IsOn==true)
		{
			ToggleBar4();
		}
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 0.75f));
	}
	
	function OnButton_3 () : void {
		// Toggle m_Bar3
		ToggleBar3();
		
		// Toggle other bars
		if(m_Bar1_IsOn==true)
		{
			ToggleBar1();
		}
		if(m_Bar2_IsOn==true)
		{
			ToggleBar2();
		}
		if(m_Bar4_IsOn==true)
		{
			ToggleBar4();
		}
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 0.75f));
	}
	
	function OnButton_4 () : void {
		// Toggle m_Bar4
		ToggleBar4();
		
		// Toggle other bars
		if(m_Bar1_IsOn==true)
		{
			ToggleBar1();
		}
		if(m_Bar2_IsOn==true)
		{
			ToggleBar2();
		}
		if(m_Bar3_IsOn==true)
		{
			ToggleBar3();
		}
		
		// Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
		StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 0.75f));
		StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 0.75f));
	}
	
	// ######################################################################
	// Toggle button functions
	// ######################################################################
	
	// Toggle m_Bar1
	function ToggleBar1 () : void {
		m_Bar1_IsOn = !m_Bar1_IsOn;
		if(m_Bar1_IsOn==true)
		{
			// m_Bar1 moves in
			m_Bar1.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_Bar1 moves out
			m_Bar1.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle m_Bar2
	function ToggleBar2 () : void {
		m_Bar2_IsOn = !m_Bar2_IsOn;
		if(m_Bar2_IsOn==true)
		{
			// m_Bar2 moves in
			m_Bar2.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_Bar2 moves out
			m_Bar2.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle m_Bar3
	function ToggleBar3 () : void {
		m_Bar3_IsOn = !m_Bar3_IsOn;
		if(m_Bar3_IsOn==true)
		{
			// m_Bar3 moves in
			m_Bar3.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_Bar3 moves out
			m_Bar3.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle m_Bar4
	function ToggleBar4 () : void {
		m_Bar4_IsOn = !m_Bar4_IsOn;
		if(m_Bar4_IsOn==true)
		{
			// m_Bar4 moves in
			m_Bar4.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// m_Bar4 moves out
			m_Bar4.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
}
