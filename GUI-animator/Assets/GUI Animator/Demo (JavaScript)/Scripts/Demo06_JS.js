// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

/**************
* Demo06_JS class
* This class handles "Demo06_JS (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

class Demo06_JS extends MonoBehaviour {

	// Canvas
	 var m_Canvas : Canvas;
	
	// GUIAnim objects of title text
	 var m_Title1 : GUIAnim;
	 var m_Title2 : GUIAnim;
	
	// GUIAnim objects of top and bottom bars
	 var m_TopBar : GUIAnim;
	 var m_BottomBar : GUIAnim;
	
	// GUIAnim objects of primary buttons
	 var m_PrimaryButton1 : GUIAnim;
	 var m_PrimaryButton2 : GUIAnim;
	 var m_PrimaryButton3 : GUIAnim;
	 var m_PrimaryButton4 : GUIAnim;
	 var m_PrimaryButton5 : GUIAnim;

	// GUIAnim objects of secondary buttons
	 var m_SecondaryButton1 : GUIAnim;
	 var m_SecondaryButton2 : GUIAnim;
	 var m_SecondaryButton3 : GUIAnim;
	 var m_SecondaryButton4 : GUIAnim;
	 var m_SecondaryButton5 : GUIAnim;
	
	// Toggle state of buttons
	 protected var m_Button1_IsOn : boolean= false;
	 protected var m_Button2_IsOn : boolean= false;
	 protected var m_Button3_IsOn : boolean= false;
	 protected var m_Button4_IsOn : boolean= false;
	 protected var m_Button5_IsOn : boolean= false;
	
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
		
		// Enable all scene switch buttons
		GUIAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, true);
	}
	
	// MoveIn all primary buttons
	function MoveInPrimaryButtons () : IEnumerator {
		yield  WaitForSeconds(1.0f);
		
		// MoveIn all primary buttons
		m_PrimaryButton1.MoveIn(eGUIMove.Self);	
		m_PrimaryButton2.MoveIn(eGUIMove.Self);	
		m_PrimaryButton3.MoveIn(eGUIMove.Self);	
		m_PrimaryButton4.MoveIn(eGUIMove.Self);

		m_PrimaryButton5.MoveIn(eGUIMove.Self);
		
		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}
	
	// MoveOut all primary buttons
	function HideAllGUIs () : void {
		// MoveOut all primary buttons
		m_PrimaryButton1.MoveOut(eGUIMove.SelfAndChildren);
		m_PrimaryButton2.MoveOut(eGUIMove.SelfAndChildren);
		m_PrimaryButton3.MoveOut(eGUIMove.SelfAndChildren);
		m_PrimaryButton4.MoveOut(eGUIMove.SelfAndChildren);
		m_PrimaryButton5.MoveOut(eGUIMove.SelfAndChildren);
		
		// MoveOut all secondary buttons
		if(m_Button1_IsOn == true)
			m_SecondaryButton1.MoveOut(eGUIMove.SelfAndChildren);
		if(m_Button2_IsOn == true)
			m_SecondaryButton2.MoveOut(eGUIMove.SelfAndChildren);
		if(m_Button3_IsOn == true)
			m_SecondaryButton3.MoveOut(eGUIMove.SelfAndChildren);
		if(m_Button4_IsOn == true)
			m_SecondaryButton4.MoveOut(eGUIMove.SelfAndChildren);
		if(m_Button5_IsOn == true)
			m_SecondaryButton5.MoveOut(eGUIMove.SelfAndChildren);
		
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
	
	function OnButton_1 () : void {
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(0.6f));

		// Toggle m_Button1
		ToggleButton_1();
		
		// Toggle other buttons
		if(m_Button2_IsOn==true)
		{
			ToggleButton_2();
		}
		if(m_Button3_IsOn==true)
		{
			ToggleButton_3();
		}
		if(m_Button4_IsOn==true)
		{
			ToggleButton_4();
		}
		if(m_Button5_IsOn==true)
		{
			ToggleButton_5();
		}
	}
	
	function OnButton_2 () : void {
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(0.6f));

		// Toggle m_Button2
		ToggleButton_2();
		
		// Toggle other buttons
		if(m_Button1_IsOn==true)
		{
			ToggleButton_1();
		}
		if(m_Button3_IsOn==true)
		{
			ToggleButton_3();
		}
		if(m_Button4_IsOn==true)
		{
			ToggleButton_4();
		}
		if(m_Button5_IsOn==true)
		{
			ToggleButton_5();
		}
	}
	
	function OnButton_3 () : void {
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(0.6f));

		// Toggle m_Button3
		ToggleButton_3();
		
		// Toggle other buttons
		if(m_Button1_IsOn==true)
		{
			ToggleButton_1();
		}
		if(m_Button2_IsOn==true)
		{
			ToggleButton_2();
		}
		if(m_Button4_IsOn==true)
		{
			ToggleButton_4();
		}
		if(m_Button5_IsOn==true)
		{
			ToggleButton_5();
		}
	}
	
	function OnButton_4 () : void {
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(0.6f));

		// Toggle m_Button4
		ToggleButton_4();
		
		// Toggle other buttons
		if(m_Button1_IsOn==true)
		{
			ToggleButton_1();
		}
		if(m_Button2_IsOn==true)
		{
			ToggleButton_2();
		}
		if(m_Button3_IsOn==true)
		{
			ToggleButton_3();
		}
		if(m_Button5_IsOn==true)
		{
			ToggleButton_5();
		}
	}
	
	function OnButton_5 () : void {
		// Disable all buttons for a few seconds
		StartCoroutine(DisableAllButtonsForSeconds(0.6f));

		// Toggle m_Button5
		ToggleButton_5();
		
		// Toggle other buttons
		if(m_Button1_IsOn==true)
		{
			ToggleButton_1();
		}
		if(m_Button2_IsOn==true)
		{
			ToggleButton_2();
		}
		if(m_Button3_IsOn==true)
		{
			ToggleButton_3();
		}
		if(m_Button4_IsOn==true)
		{
			ToggleButton_4();
		}
	}
	
	// ######################################################################
	// Toggle button functions
	// ######################################################################
	
	// Toggle m_Button1
	function ToggleButton_1 () : void {
		m_Button1_IsOn = !m_Button1_IsOn;
		if(m_Button1_IsOn==true)
		{
			// MoveIn m_SecondaryButton1
			m_SecondaryButton1.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// MoveOut m_SecondaryButton1
			m_SecondaryButton1.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle m_Button2
	function ToggleButton_2 () : void {
		m_Button2_IsOn = !m_Button2_IsOn;
		if(m_Button2_IsOn==true)
		{
			// MoveIn m_SecondaryButton2
			m_SecondaryButton2.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// MoveOut m_SecondaryButton2
			m_SecondaryButton2.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle m_Button3
	function ToggleButton_3 () : void {
		m_Button3_IsOn = !m_Button3_IsOn;
		if(m_Button3_IsOn==true)
		{
			// MoveIn m_SecondaryButton3
			m_SecondaryButton3.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// MoveOut m_SecondaryButton3
			m_SecondaryButton3.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle m_Button4
	function ToggleButton_4 () : void {
		m_Button4_IsOn = !m_Button4_IsOn;
		if(m_Button4_IsOn==true)
		{
			// MoveIn m_SecondaryButton4
			m_SecondaryButton4.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// MoveOut m_SecondaryButton4
			m_SecondaryButton4.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
	
	// Toggle m_Button5
	function ToggleButton_5 () : void {
		m_Button5_IsOn = !m_Button5_IsOn;
		if(m_Button5_IsOn==true)
		{
			// MoveIn m_SecondaryButton5
			m_SecondaryButton5.MoveIn(eGUIMove.SelfAndChildren);
		}
		else
		{
			// MoveOut m_SecondaryButton5
			m_SecondaryButton5.MoveOut(eGUIMove.SelfAndChildren);
		}
	}
}
