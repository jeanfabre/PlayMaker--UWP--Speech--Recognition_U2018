// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Speech Recognition")]
	[Tooltip("Set keywords for Speech Recognition")]
	public class SpeechRecognitionSetKeywords : ComponentAction<PlayMakerSpeechRecognitionProxy>
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayMakerSpeechRecognitionProxy))]
		[Tooltip("The target. A PlayMakerSpeechRecognitionProxy component is required")]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("The keywords")]
		[ArrayEditor(VariableType.String)]
		public FsmArray keywords;

				
		public override void Reset()
		{
			gameObject = null;
			keywords = null;
		}
		
		public override void OnEnter()
		{
			if (UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
			{
				keywords.SaveChanges();
				this.cachedComponent.SetKeyword(keywords.stringValues); 
			}

			Finish();
			
		}
		
	}
}