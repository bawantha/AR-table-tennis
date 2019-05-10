// GUI Animator for Unity UI version: 0.9.92c (Product page: http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/)
//
// Author:			Gold Experience Team (http://www.ge-team.com/pages/)
// Products:		http://ge-team.com/pages/unity-3d/
// Support:			geteamdev@gmail.com
// Documentation:	http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/gui-animator-for-unity-ui-documentation/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

#region Namespaces

using UnityEngine;
using System.Collections;

#endregion

/**************
* Demo08 class
* This class handles "Demo08 (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

public class Demo08 : MonoBehaviour
{
	
	#region Variables

	// Canvas
	public Canvas m_Canvas;
	
	// GEAnim objects of title text
	public GEAnim m_Title1;
	public GEAnim m_Title2;
	
	// GEAnim objects of top and bottom bars
	public GEAnim m_TopBar;
	public GEAnim m_BottomBar;
	
	// GEAnim objects of 4 primary buttons
	public GEAnim m_CenterButtons;
	
	// GEAnim objects of buttons
	public GEAnim m_Button1;
	public GEAnim m_Button2;
	public GEAnim m_Button3;
	public GEAnim m_Button4;

	// GEAnim objects of top, left, right and bottom bars
	public GEAnim m_Bar1;
	public GEAnim m_Bar2;
	public GEAnim m_Bar3;
	public GEAnim m_Bar4;
	
	// Toggle state of top, left, right and bottom bars
	bool m_Bar1_IsOn = false;
	bool m_Bar2_IsOn = false;
	bool m_Bar3_IsOn = false;
	bool m_Bar4_IsOn = false;
	
	#endregion
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################
	
	#region MonoBehaviour
	
	// Use this for initialization
	void Awake ()
	{
		//////////////////////////////////////////////////////////////////////
		// If you want to control all GEAnim elements in the scene via scripts, you have to call these line in Awake function.
		// Otherwise, GEAnimSystem will run all GEAnim elements automatically.
		//
		// If you disable this component by uncheck it from the GameObject that it is attached,
		// the GEAnimSystem will control all animations in the scene according to selected animations in Auto Animation of GEAnimSystem.
		//////////////////////////////////////////////////////////////////////
		if(enabled)
		{
			// Use this script to control all animations in the scene instead of GEAnimSystem auto test.
			GEAnimSystem.Instance.m_AutoAnimation = false;
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		// MoveIn m_TopBar and m_BottomBar
		m_TopBar.MoveIn(eGUIMove.SelfAndChildren);
		m_BottomBar.MoveIn(eGUIMove.SelfAndChildren);
		
		// MoveIn m_Title1 and m_Title2
		StartCoroutine(MoveInTitleGameObjects());
		
		// Disable all scene switch buttons
		GEAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	#endregion
	
	// ######################################################################
	// MoveIn/MoveOut functions
	// ######################################################################
	
	#region MoveIn/MoveOut
	
	// MoveIn m_Title1 and m_Title2
	IEnumerator MoveInTitleGameObjects()
	{
		yield return new WaitForSeconds(1.0f);
		
		// MoveIn m_Title1 and m_Title2
		m_Title1.MoveIn(eGUIMove.Self);
		m_Title2.MoveIn(eGUIMove.Self);
		
		// MoveIn all primary buttons
		StartCoroutine(MoveInPrimaryButtons());
	}
	
	// MoveIn all primary buttons
	IEnumerator MoveInPrimaryButtons()
	{
		yield return new WaitForSeconds(1.0f);
		
		// MoveIn all primary buttons
		m_CenterButtons.MoveIn(eGUIMove.SelfAndChildren);
		
		// Enable all scene switch buttons
		StartCoroutine(EnableAllDemoButtons());
	}
	
	// MoveOut all primary buttons
	public void HideAllGUIs()
	{
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
	IEnumerator HideTitleTextMeshes()
	{
		yield return new WaitForSeconds(1.0f);
		
		// MoveOut m_Title1 and m_Title2
		m_Title1.MoveOut(eGUIMove.Self);
		m_Title2.MoveOut(eGUIMove.Self);
		
		// MoveOut m_TopBar and m_BottomBar
		m_TopBar.MoveOut(eGUIMove.SelfAndChildren);
		m_BottomBar.MoveOut(eGUIMove.SelfAndChildren);
	}
	
	#endregion
	
	// ######################################################################
	// Enable/Disable button functions
	// ######################################################################
	
	#region Enable/Disable buttons
	
	// Enable/Disable all scene switch Coroutine
	IEnumerator EnableAllDemoButtons()
	{
		yield return new WaitForSeconds(1.0f);
		
		// Enable all scene switch buttons
		GEAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, true);
	}
	
	// Disable all buttons for a few seconds
	IEnumerator DisableButtonForSeconds(GameObject GO, float DisableTime)
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableButton(GO.transform, false);
		
		yield return new WaitForSeconds(DisableTime);
		
		// Enable all buttons
		GEAnimSystem.Instance.EnableButton(GO.transform, true);
	}
	
	#endregion
	
	// ######################################################################
	// Button handler functions
	// ######################################################################
	
	#region Button handlers
	
	public void OnButton_1()
	{
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
	
	public void OnButton_2()
	{
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
	
	public void OnButton_3()
	{
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
	
	public void OnButton_4()
	{
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
	
	#endregion
	
	// ######################################################################
	// Toggle button functions
	// ######################################################################
	
	#region Toggle Button
	
	// Toggle m_Bar1
	void ToggleBar1()
	{
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
	void ToggleBar2()
	{
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
	void ToggleBar3()
	{
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
	void ToggleBar4()
	{
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
	
	#endregion
}
