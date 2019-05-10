class DemoPlaySound_JS extends MonoBehaviour {
	
	 var m_AudioSourceCount : int= 2;
	
	 protected var m_AudioSource : AudioSource[]= null;
	
	 var m_Audio_Button1 : AudioClip= null;
	 var m_Audio_Button2 : AudioClip= null;
	
	// Use this for initialization
	function Start () : void {

		// Create AudioSource list
		if(m_AudioSource==null)
		{
			m_AudioSource = new AudioSource[m_AudioSourceCount];
			
			for( var i : int=0;i<m_AudioSource.Length;i++)
			{
				 var pAudioSource : AudioSource=  this.gameObject.AddComponent(AudioSource);
				pAudioSource.rolloffMode = AudioRolloffMode.Linear;
				m_AudioSource[i] = pAudioSource;
			}
		}
	}
	
	// Update is called once per frame
	function Update () : void {
		
	}
	
	// Play AudioClip
	function PlayOneShot ( pAudioClip : AudioClip  ) : void {

		for( var i : int=0;i<m_AudioSource.Length;i++)
		{
			if(m_AudioSource[i].isPlaying == false)
			{
				m_AudioSource[i].PlayOneShot(pAudioClip);
				break;
			}
		}
	}

	// Play m_Audio_Button1 audio clip
	function PlaySoundButton1 () : void {
		PlayOneShot(m_Audio_Button1);
	}
	
	// Play m_Audio_Button2 audio clip
	function PlaySoundButton2 () : void {
		PlayOneShot(m_Audio_Button2);
	}
}

