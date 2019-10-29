// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __PROXY__ ---*/


using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Ecosystem.Utils;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayMakerSpeechRecognitionProxy : MonoBehaviour
{
    public string[] keywords = new string[] { "up", "down", "left", "right" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;

    public PlayMakerEventTarget eventTarget = new PlayMakerEventTarget(false);

    [EventTargetVariable("eventTarget")]
    public PlayMakerEvent OnPhraserecognizesEvent;

    public string LastSpokenWord = "";

    public bool debug;

    PhraseRecognizer recognizer;

    void Start(){}

    
    private void OnEnable()
    {
       Mount();
    }
    
    private void OnDisable()
    {
       UnMount();
    }

    void Mount()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }
    void UnMount()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
            recognizer = null;
        }
    }
    


    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        LastSpokenWord = args.text;
        if (debug)
        {
            Debug.Log("<color=blue>PlayMaker Speech recognition:</color> You said: <b>" + LastSpokenWord + "</b>");
        }

        Fsm.EventData.StringData = LastSpokenWord;

        OnPhraserecognizesEvent.SendEvent(null, eventTarget);
    }

    public void SetKeyword(string[] newKeywords )
    {
        this.keywords = newKeywords;
        UnMount();
        Mount();
    }
    

}
