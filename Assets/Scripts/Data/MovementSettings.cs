using UnityEngine;

// Made so that all playable characters use the same settings
// Of course you can still use multiple movement settings and create confusion 
// but it is less likely than in the settings of each movement script.
/// <summary>
/// Contains global movement settings
/// </summary>
[CreateAssetMenu(fileName = "MovementSettings", 
    menuName = "ScriptableObjects/MovementSettings")]
public class MovementSettings : ScriptableObject
{
    [Header("Rotation relative to (1; 0)")]
    [SerializeField][Range(0f, 89f)]
    private float _xCoordinateRotation;

    [Header("Rotation relative to (0; 1)")]
    [SerializeField][Range(0f, 89f)]
    private float _yCoordinateRotation
        = 30f;

    public Vector2 GetAdditionalMovement(Vector2 deltaMovement)
    {
        return new Vector2(
            deltaMovement.y * Mathf.Tan(_yCoordinateRotation * Mathf.Deg2Rad),
            deltaMovement.x * Mathf.Tan(_xCoordinateRotation * Mathf.Deg2Rad));
    }
}

