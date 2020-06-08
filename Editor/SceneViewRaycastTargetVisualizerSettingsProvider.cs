using UnityEditor;

namespace Kogane.Internal
{
	/// <summary>
	/// Preferences における設定画面を管理するクラス
	/// </summary>
	internal sealed class SceneViewRaycastTargetVisualizerSettingsProvider : SettingsProvider
	{
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SceneViewRaycastTargetVisualizerSettingsProvider( string path, SettingsScope scope )
			: base( path, scope )
		{
		}

		/// <summary>
		/// GUI を描画する時に呼び出されます
		/// </summary>
		public override void OnGUI( string searchContext )
		{
			var settings = SceneViewRaycastTargetVisualizerSettings.Instance;

			using ( var checkScope = new EditorGUI.ChangeCheckScope() )
			{
				settings.IsEnable = EditorGUILayout.Toggle( "Enabled", settings.IsEnable );

				if ( checkScope.changed )
				{
					settings.SaveToEditorPrefs();
				}
			}
		}

		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// Preferences にメニューを追加します
		/// </summary>
		[SettingsProvider]
		private static SettingsProvider Create()
		{
			var path     = "Preferences/UniSceneViewRaycastTargetVisualizer";
			var provider = new SceneViewRaycastTargetVisualizerSettingsProvider( path, SettingsScope.User );

			return provider;
		}
	}
}