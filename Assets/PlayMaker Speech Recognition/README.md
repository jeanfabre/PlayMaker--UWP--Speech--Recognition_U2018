PlayMaker--Speech--Recognition
==============================

## Licensing
This package is released under MIT license: [https://opensource.org/licenses/MIT](https://opensource.org/licenses/MIT)


## Description
This is a PlayMaker port for https://docs.unity3d.com/ScriptReference/Windows.Speech.PhraseRecognitionSystem.html


## Implementation
Drop the PlayMakerSpeechRecognitionProxy component on a GameObject in your scene, set it up with the keywords you want to detect and what PlayMaker event target and event you want to send when these keywords are recognized
Use GetEventInfo string variable when you receive that event to know what word was detected by the system

