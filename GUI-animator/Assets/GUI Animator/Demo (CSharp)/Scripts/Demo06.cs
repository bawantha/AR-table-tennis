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
* Demo06 class
* This class handles "Demo06 (960x600px)" scene.
* It does animate all GameObjects when scene starts and ends.
* It also responds to user mouse click or tap on buttons.
**************/

public class Demo06 : MonoBehaviour
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
	
	// GEAnim objects of primary buttons
	public GEAnim m_PrimaryButton1;
	public GEAnim m_PrimaryButton2;
	public GEAnim m_PrimaryButton3;
	public GEAnim m_PrimaryButton4;
	public GEAnim m_PrimaryButton5;

	// GEAnim objects of secondary buttons
	public GEAnim m_SecondaryButton1;
	public GEAnim m_SecondaryButton2;
	public GEAnim m_SecondaryButton3;
	public GEAnim m_SecondaryButton4;
	public GEAnim m_SecondaryButton5;
	
	// Toggle state of buttons
	bool m_Button1_IsOn = false;
	bool m_Button2_IsOn = false;
	bool m_Button3_IsOn = false;
	bool m_Button4_IsOn = false;
	bool m_Button5_IsOn = false;
	
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
		
		// MoveIn m_Title1 m_Title2
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
	
	// Move In m_Title1 and m_Title2
	IEnumerator MoveInTitleGameObjects()
	{
		yield return new WaitForSeconds(1.0f);
		
		// Move In m_Title1 and m_Title2
		m_Title1.MoveIn(eGUIMove.Self);
		m_Title2.MoveIn(eGUIMove.Self);
		
		// MoveIn dialogs
		StartCoroutine(MoveInPrimaryButtons());
		
		// Enable all scene switch buttons
		GEAnimSystem.Instance.SetGraphicRaycasterEnable(m_Canvas, true);
	}
	
	// MoveIn all primary buttons
	IEnumerator MoveInPrimaryButtons()
	{
		yield return new WaitForSeconds(1.0f);
		
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
	public void HideAllGUIs()
	{
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
	IEnumerator DisableAllButtonsForSeconds(float DisableTime)
	{
		// Disable all buttons
		GEAnimSystem.Instance.EnableAllButtons(false);
		
		yield return new WaitForSeconds(DisableTime);
		
		// Enable all buttons
		GEAnimSystem.Instance.EnableAllButtons(true);
	}
	
	#endregion
	
	// ######################################################################
	// Button handler functions
	// ######################################################################
	
	#region Button Handler
	
	public void OnButton_1()
	{
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
	
	public void OnButton_2()
	{
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
	
	public void OnButton_3()
	{
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
	
	public void OnButton_4()
	{
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
	
	public void OnButton_5()
	{
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
	
	#endregion
	
	// ######################################################################
	// Toggle button functions
	// ######################################################################
	
	#region Toggle Button
	
	// Toggle m_Button1
	void ToggleButton_1()
	{
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
	void ToggleButton_2()
	{
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
	void ToggleButton_3()
	{
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
	void ToggleButton_4()
	{
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
	void ToggleButton_5()
	{
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
	
	#endregion
}
