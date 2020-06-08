using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane.Internal
{
	/// <summary>
	/// Scene ビューに Raycast Target の範囲を表示するエディタ拡張
	/// </summary>
	internal static class SceneViewRaycastTargetVisualizer
	{
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// Scene ビューに Raycast Target の範囲を表示します
		/// </summary>
		[DrawGizmo( GizmoType.Selected | GizmoType.NonSelected )]
		private static void DrawGizmo( Graphic graphic, GizmoType type )
		{
			var settings = SceneViewRaycastTargetVisualizerSettings.Instance;

			if ( settings == null || !settings.IsEnable ) return;
			if ( !graphic.raycastTarget ) return;

			var rectTransform = graphic.GetComponent<RectTransform>();
			var size          = rectTransform.rect.size;
			var lossyScale    = rectTransform.lossyScale;

			size.x *= lossyScale.x;
			size.y *= lossyScale.y;

			var position = ( Vector2 ) rectTransform.position;
			var pivot    = rectTransform.pivot;
			var offset   = new Vector2( pivot.x * size.x, pivot.y * size.y );
			var center   = position - offset;

			var rect = new Rect
			{
				center = center,
				size   = size,
			};

			var oldColor = Gizmos.color;
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube( rect.center, rect.size );
			Gizmos.color = oldColor;
		}
	}
}