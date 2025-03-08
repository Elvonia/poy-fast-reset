using BepInEx.Configuration;

namespace FastReset.State {
    public class SavedAnimation : BaseAnimation {
        private string configFile {
            get => SceneState.animationFile;
        }

        private List<ConfigEntry<float>> stateTimers;

        public SavedAnimation(Animation animation) : base(animation) {
            stateTimers = new List<ConfigEntry<float>>();

            int i = 0;
            foreach (AnimationState state in animation) {
                stateTimers.Add(configFile.Bind(
                    "Animation", $"state_{i}", state.normalizedTime
                ));
                i++;
            }
        }

        public override void Save() {
            int i = 0;
            foreach (AnimationState state in animation) {
                if (i < stateTimers.Count) {
                    stateTimers[i].Value = state.normalizedTime;
                }
                else {
                    stateTimers.Add(configFile.Bind(
                        "Animation", $"state_{i}", state.normalizedTime
                    ));
                }
                i++;
            }
        }

        public override void Restore() {
            int i = 0;
            foreach (AnimationState state in animation) {
                state.normalizedTime = stateTimers[i].Value;
                i++;
            }
        }
    }
}
