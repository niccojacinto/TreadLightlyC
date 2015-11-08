using UnityEngine;
using UnityEngine.UI;
using System.Collections;

internal class TLUI {

    Text textSubtitles;
    Text textHint;
    Animator blackScreen;
    // Use this for initialization
    public TLUI (Text hintUI, Text textUI, Animator blackScreenAnimator ) {
        textHint = hintUI;
        textSubtitles = textUI;
        blackScreen = blackScreenAnimator;
    }

    public void FadeInBlack() { blackScreen.Play("FadeInB"); }

    public void FadeOutBlack() { blackScreen.Play("FadeOutB"); }

    public void Subtitles(string text) {
        textSubtitles.text = text;
    }

    public void Hint(string text) {
        textHint.text = text;
    }
}

