using UnityEngine;

namespace Editor
{
    using UnityEditor;

    /**
     * https://catlikecoding.com/unity/tutorials/curves-and-splines/
     */
    [CustomEditor(typeof(BezierCurve))]
    public class BezierCurveInspector : Editor
    {
        static int smoothness = 100;

        [DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
        static void DrawHandles(BezierCurve curve, GizmoType gizmoType)
        {
            // convert points from local to world space
            var trans = curve.transform;
            var p0 = trans.TransformPoint(curve.p0);
            var p1 = trans.TransformPoint(curve.p1);
            var p2 = trans.TransformPoint(curve.p2);
            var p3 = trans.TransformPoint(curve.p3);

            // if selected, add handles to the points and use GREEN color
            if ((gizmoType & GizmoType.Selected) != 0)
            {
                var handleRotation = Tools.pivotRotation == PivotRotation.Local ? trans.rotation : Quaternion.identity;
                EditorGUI.BeginChangeCheck();
                p0 = Handles.DoPositionHandle(p0, handleRotation);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(curve, "Move Point");
                    EditorUtility.SetDirty(curve);
                    p0 = curve.p0 = trans.InverseTransformPoint(p0);
                }

                EditorGUI.BeginChangeCheck();
                p1 = Handles.DoPositionHandle(p1, handleRotation);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(curve, "Move Point");
                    EditorUtility.SetDirty(curve);
                    p1 = curve.p1 = trans.InverseTransformPoint(p1);
                }

                EditorGUI.BeginChangeCheck();
                p2 = Handles.DoPositionHandle(p2, handleRotation);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(curve, "Move Point");
                    EditorUtility.SetDirty(curve);
                    p2 = curve.p2 = trans.InverseTransformPoint(p2);
                }

                EditorGUI.BeginChangeCheck();
                p3 = Handles.DoPositionHandle(p3, handleRotation);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(curve, "Move Point");
                    EditorUtility.SetDirty(curve);
                    p3 = curve.p3 = trans.InverseTransformPoint(p3);
                }

                Handles.color = Color.green;
            }
            else
            {
                // other wise use WHITE
                Handles.color = Color.white;
            }

            // draw the curve in green
            var curvePoints = Handles.MakeBezierPoints(p0, p3, p1, p2, smoothness);
            for (var i = 1; i < curvePoints.Length - 1; ++i)
            {
                Handles.DrawLine(curvePoints[i], curvePoints[i + 1]);
            }
        }
    }
}