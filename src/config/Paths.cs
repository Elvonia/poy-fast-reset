using System.IO;

namespace FastReset.Config {
    public class Paths {
        // The directory where configs besides the main one will be located
        public static string configDirName { get; } = "com.github.Kaden5480.poy-fast-reset";

        // The name of the current scene
        public static string sceneName {
            get => Plugin.instance.cache.scene.name;
        }

        // The directory containing all configs
        public static string configDir {
            get => Path.Combine(
                BepInEx.Paths.ConfigPath, configDirName
            );
        }

        // The directory for the currently selected profile
        public static string profileDir {
            get => Path.Combine(
                configDir,
                Plugin.instance.config.profile.Value
            );
        }

        // Path to the file containing the
        // player state configuration
        public static string playerPath {
            get => Path.Combine(
                profileDir, sceneName, "player.cfg"
            );
        }

        // Path to the file containing animation states
        public static string animationsPath {
            get => Path.Combine(
                profileDir, sceneName, "animations.cfg"
            );
        }

        // The path to the file containing brittle ice states
        public static string brittleIcePath {
            get => Path.Combine(
                profileDir, sceneName, "brittle-ice.cfg"
            );
        }

        // The path to the file containing crumbling hold states
        public static string crumblingHoldsPath {
            get => Path.Combine(
                profileDir, sceneName, "crumbling-holds.cfg"
            );
        }

        // The path to the file containing joint states
        public static string jointsPath {
            get => Path.Combine(
                profileDir, sceneName, "joints.cfg"
            );
        }
    }
}
