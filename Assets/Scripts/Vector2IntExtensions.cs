using UnityEngine;

public static class Vector2IntExtensions {
    public static Vector2Int upleft { 
        get { return new Vector2Int(-1, 1); }
    }

    public static Vector2Int upright { 
        get { return new Vector2Int(1, 1); }
    }

    public static Vector2Int downleft { 
        get { return new Vector2Int(-1, -1); }
    }

    public static Vector2Int downright { 
        get { return new Vector2Int(1, -1); }
    }
}
