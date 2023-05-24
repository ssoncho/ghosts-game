using GhostsGame.Controller;
using Microsoft.Xna.Framework;
namespace Tests;

[TestFixture]
public class ScreenController_should
{
    [Test]
    public void LoadFromText_CorrectObjectsPositions()
    {
        var screenController = new ScreenController(5, 4, 20);
        var levelDescription = @"
#####
#   #
# P #
#####".Replace("\r\n", string.Empty);
        var level = screenController.LoadLevelFromText(levelDescription);
        Assert.That(level.IdsObjects[level.PlayerId].Position, Is.EqualTo(20 * new Vector2(2, 2)));
        Assert.That(level.IdsObjects[1].Position, Is.EqualTo(20 * new Vector2(0, 0)));
        Assert.That(level.IdsObjects[5].Position, Is.EqualTo(20 * new Vector2(4, 0)));
        Assert.That(level.IdsObjects[11].Position, Is.EqualTo(20 * new Vector2(0, 3)));
        Assert.That(level.IdsObjects[15].Position, Is.EqualTo(20 * new Vector2(4, 3)));
    }
}