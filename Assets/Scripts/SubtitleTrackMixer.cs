using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleTrackMixer : PlayableBehaviour
{
    // Start is called before the first frame update
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        float currentAlpha = 0f;

        if (!text) { return; }

        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            if (inputWeight > 0f) {
                ScriptPlayable<SubtitleBehavior> inputPlayable = (ScriptPlayable<SubtitleBehavior>)playable.GetInput(i);

                SubtitleBehavior input = inputPlayable.GetBehaviour();

                Debug.Log(inputWeight);

                currentAlpha = inputWeight;
                currentText = input.subtitleText;
            }
        }

        text.text = currentText;
        text.color = new Color(0, 0, 0, currentAlpha);
    }
}
