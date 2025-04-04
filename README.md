# BadgetsController - Achievement System for Unity

## 🏆 Overview

The `BadgetsController` is a flexible achievement/badge system that automatically awards players based on their performance metrics. It works seamlessly with Unity's UI system and supports multiple badge types.

## ✨ Features

- **Automatic Badge Assignment** - Awards badges based on player stats
- **Multiple Badge Types** - Supports different achievement categories
- **Easy Integration** - Works with existing player data models
- **UI-Ready** - Includes badge images and metadata

## 🛠️ Configuration

### 1. Set Up Badge Types

```csharp
public enum BadgetType 
{
    BestScore,
    MoreEnemysDeleted,
    // Add your custom badge types here
}
```

### 2. Create Badge Assets

Create a `BadgetsModel` ScriptableObject and configure your badges:

```csharp
[CreateAssetMenu(fileName = "BadgesConfig", menuName = "Game/Badges Configuration")]
public class BadgetsModel : ScriptableObject
{
    public List<Badget> BadgetList;
}
```

For each badge, specify:
- Name
- Type
- Display image

## 💻 Usage

### Basic Implementation

```csharp
public class GameManager : MonoBehaviour
{
    [SerializeField] private BadgetsController badgeController;
    [SerializeField] private ResultsModel results;

    void EndGame()
    {
        // Initialize with game results
        badgeController.Initialize(results);
        
        // Award badges
        badgeController.AssignBadges();
        
        // Display results
        DisplayBadges();
    }
}
```

### Custom Badge Types

1. Extend the `BadgetType` enum:
```csharp
public enum BadgetType 
{
    BestScore,
    MoreEnemysDeleted,
    FastestTime,
    MostCoinsCollected,
    SurvivalExpert
}
```

2. Update the stat calculation:
```csharp
private int GetStatValue(BadgetType badgetType, PlayerEntity player)
{
    switch (badgetType)
    {
        case BadgetType.FastestTime:
            return player.FinishTime;
        case BadgetType.MostCoinsCollected:
            return player.CoinsCollected;
        // Add your custom cases
        default:
            return base.GetStatValue(badgetType, player);
    }
}
```

## 🎨 UI Integration

The package includes a sample UI view (`TestUIView`) that demonstrates how to display badges:

## 📊 Example Workflow

1. **Game Setup**:
   ```csharp
   ResultsModel results = new ResultsModel();
   results.AddResult(new PlayerResult(player1Data));
   results.AddResult(new PlayerResult(player2Data));
   ```

2. **Award Badges**:
   ```csharp
   BadgetsController controller = GetComponent<BadgetsController>();
   controller.Initialize(results);
   controller.AssignBadges();
   ```

3. **Display Results**:
   ```csharp
   foreach (var result in results.GetResults())
   {
       var badgeDisplay = Instantiate(badgeUIPrefab, parentTransform);
       badgeDisplay.ShowBadges(result.Badgets);
   }
   ```

## 📝 Dependencies

- Unity 2022.3 or later
- TextMeshPro (for UI text components)

## 📜 License

MIT License - Free for commercial and personal use

---

**Celebrate player achievements in style!** 🎉  
For support or feature requests, please open an issue on GitHub.