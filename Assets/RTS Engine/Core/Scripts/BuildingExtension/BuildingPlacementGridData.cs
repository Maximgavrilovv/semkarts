using RTSEngine.Utilities;
using UnityEngine;

namespace RTSEngine.BuildingExtension
{
    public enum GridAreaPivotPoint
    {
        center = 0,

        topLeft = 1,
        bottomLeft = 2,
        topRight = 3,
        bottomRight = 4
    }

    [System.Serializable]
    public struct BuildingPlacementGridData
    {
        [Tooltip("Size of the grid to be occupied by the building.")]
        public Int2D area;
        [Tooltip("Segment position pivot point in the grid.")]
        public GridAreaPivotPoint pivotPoint;

        public Vector3 ApplyPivotPoint(Vector3 position) => ApplyPivotPoint(position, pivotPoint);
        public Vector3 ApplyPivotPoint(Vector3 position, GridAreaPivotPoint pivotPoint)
        {
            switch(pivotPoint)
            {
                case GridAreaPivotPoint.bottomLeft:
                    return new Vector3(
                        position.x + area.x / 2.0f,
                        position.y,
                        position.z + area.y / 2.0f);
                case GridAreaPivotPoint.topLeft:
                    return new Vector3(
                        position.x + area.x / 2.0f,
                        position.y,
                        position.z - area.y / 2.0f);

                case GridAreaPivotPoint.bottomRight:
                    return new Vector3(
                        position.x - area.x / 2.0f,
                        position.y,
                        position.z + area.y / 2.0f);
                case GridAreaPivotPoint.topRight:
                    return new Vector3(
                        position.x - area.x / 2.0f,
                        position.y,
                        position.z - area.y / 2.0f);

                default:
                    return position;

            }
        }

        public Vector3 ApplyPivotPointReverse(Vector3 position) => ApplyPivotPointReverse(position, pivotPoint);
        public Vector3 ApplyPivotPointReverse(Vector3 position, GridAreaPivotPoint pivotPoint)
        {
            switch(pivotPoint)
            {
                case GridAreaPivotPoint.bottomLeft:
                    return new Vector3(
                        position.x - area.x / 2.0f,
                        position.y,
                        position.z - area.y / 2.0f);
                case GridAreaPivotPoint.topLeft:
                    return new Vector3(
                        position.x - area.x / 2.0f,
                        position.y,
                        position.z + area.y / 2.0f);

                case GridAreaPivotPoint.bottomRight:
                    return new Vector3(
                        position.x + area.x / 2.0f,
                        position.y,
                        position.z - area.y / 2.0f);
                case GridAreaPivotPoint.topRight:
                    return new Vector3(
                        position.x + area.x / 2.0f,
                        position.y,
                        position.z + area.y / 2.0f);

                default:
                    return position;
            }
        }

    }
}