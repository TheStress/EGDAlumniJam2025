using JetBrains.Annotations;
using UnityEngine;

public class ScaleShrinkJuice : MyJuice {
    public AnimationCurve curve;
    protected override float EaseFunction(float t) {
        return curve.Evaluate(t);
    }

    protected override void EffectUpdate(float val, float valScale) {
        transform.localScale = new Vector3(1, 1, 1) * (1-val);
    }

    protected override void ResetValue() {
        transform.localScale = new Vector3(0, 0, 0);
    }
}
