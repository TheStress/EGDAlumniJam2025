using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace MicroGameSystem {

    public class HouseSmearJuice : MyJuice {
        HouseSmearIndex houseSmear;
        [SerializeField] AnimationCurve curve;
        float initalIndex;
        private void Start() {
            houseSmear = GetComponent<HouseSmearIndex>();
            OnStartEvent.AddListener(SetInitalIndex);
        }
        public void SetInitalIndex() {
            initalIndex = houseSmear.houseIndex;
        }
        protected override float EaseFunction(float t) {
            return curve.Evaluate(t);
        }

        protected override void EffectUpdate(float val, float valScale) {
            houseSmear.houseIndex = initalIndex + val;
        }
        protected override void ResetValue() {
            houseSmear.houseIndex = initalIndex + 1;
        }
    }

}