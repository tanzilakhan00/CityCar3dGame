using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmos(Waypoint waypoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.blue;  // Blue color when selected
        }
        else
        {
            Gizmos.color = Color.blue * 0.5f;  // Semi-transparent blue when not selected
        }

        // Draw the sphere at the waypoint's position with a fixed radius of 1f
        Gizmos.DrawSphere(waypoint.transform.position, 1f);

        Gizmos.color = Color.white;

        // Draw a line based on the current waypoint's width
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.waypointWidth / 2f),
                        waypoint.transform.position - (waypoint.transform.right * waypoint.waypointWidth / 2f));

        // If the current waypoint has a previous waypoint, draw a line connecting them
        if (waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.red;  // Use red color for the line to the previous waypoint
            Vector3 offset = waypoint.transform.right * waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.previousWaypoint.transform.right * waypoint.previousWaypoint.waypointWidth / 2f;
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWaypoint.transform.position + offsetTo);
        }

         if (waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.green;  // Use red color for the line to the previous waypoint
            Vector3 offset = waypoint.transform.right * -waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.previousWaypoint.transform.right * -waypoint.previousWaypoint.waypointWidth / 2f;
            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWaypoint.transform.position + offsetTo);
        }
    }
}
