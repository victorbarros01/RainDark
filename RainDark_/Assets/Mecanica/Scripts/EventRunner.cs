using UnityEngine;
using UnityEngine.Events;

namespace AvoidingDisaster.Utilities {
    public class EventRunner : MonoBehaviour {
        public UnityEvent events;

        public int runAmount = -1;
        int currentRunAmount = 0;

        public bool runOnAwake;
        public bool runOnEnable;
        public bool runOnStart;
        public bool runOnUpdate;
        public bool runOnFixedUpdate;
        public bool runOnCollisionEnter;
        public bool runOnCollisionStay;
        public bool runOnCollisionExit;
        public bool runOnTriggerEnter;
        public bool runOnTriggerStay;
        public bool runOnTriggerExit;
        public bool runOnDisable;
        public bool runOnDestroy;

        void Awake() {
            if(runOnAwake) {
                RunEvents();
            }
        }

        void OnEnable() {
            if(runOnEnable) {
                RunEvents();
            }
        }

        void Start() {
            if(runOnStart) {
                RunEvents();
            }
        }

        void Update() {
            if(runOnUpdate) {
                RunEvents();
            }
        }

        void FixedUpdate() {
            if(runOnFixedUpdate) {
                RunEvents();
            }
        }

        void OnCollisionEnter(Collision collision) {
            if(runOnCollisionEnter) {
                RunEvents();
            }
        }

        void OnCollisionStay(Collision collision) {
            if(runOnCollisionStay) {
                RunEvents();
            }
        }

        void OnCollisionExit(Collision collision) {
            if(runOnCollisionExit) {
                RunEvents();
            }
        }

        void OnTriggerEnter(Collider collider) {
            if(runOnTriggerEnter) {
                RunEvents();
            }
        }

        void OnTriggerStay(Collider collider) {
            if(runOnTriggerStay) {
                RunEvents();
            }
        }

        void OnTriggerExit(Collider collider) {
            if(runOnTriggerExit) {
                RunEvents();
            }
        }

        void OnDisable() {
            if(runOnDisable) {
                RunEvents();
            }
        }

        void OnDestroy() {
            if(runOnDestroy) {
                RunEvents();
            }
        }


        void RunEvents() {
            if(runAmount > -1) {
                if(currentRunAmount < runAmount) {
                    currentRunAmount ++;
                    events.Invoke();
                }
            } else {
                events.Invoke();
            }

        }
    }
}
