using UnityEditor;
namespace GameTest
{
    public partial class SceneLoader
    {
#if UNITY_EDITOR
        [MenuItem("Scenes/car_map")]
        public static void Loadcar_map() { OpenScene("Assets/scenes/car_map.unity"); }
        [MenuItem("Scenes/Died")]
        public static void LoadDied() { OpenScene("Assets/scenes/Died.unity"); }
        [MenuItem("Scenes/Main Game")]
        public static void LoadMainGame() { OpenScene("Assets/scenes/Main Game.unity"); }
        [MenuItem("Scenes/map")]
        public static void Loadmap() { OpenScene("Assets/scenes/map.unity"); }
        [MenuItem("Scenes/map_Collision")]
        public static void Loadmap_Collision() { OpenScene("Assets/scenes/map_Collision.unity"); }
        [MenuItem("Scenes/map_Collision_Dup")]
        public static void Loadmap_Collision_Dup() { OpenScene("Assets/scenes/map_Collision_Dup.unity"); }
        [MenuItem("Scenes/SampleScene")]
        public static void LoadSampleScene() { OpenScene("Assets/scenes/SampleScene.unity"); }
        [MenuItem("Scenes/UI")]
        public static void LoadUI() { OpenScene("Assets/scenes/UI.unity"); }
#endif
    }
}