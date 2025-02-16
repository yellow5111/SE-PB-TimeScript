public Program()
{
    Runtime.UpdateFrequency = UpdateFrequency.None;
}

public void Main(string argument, UpdateType updateSource)
{
    List<IMyTextPanel> lcdPanels = new List<IMyTextPanel>();
    GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(lcdPanels, panel => panel.CustomName == "IAmDumb");

    var inGameTime = DateTime.Now;

    string timeMessage;

    if (argument.Contains("-murica"))
    {
        timeMessage = $"This dumb script\n says it's:\n{inGameTime:hh:mm:ss tt}\n\n'Murican Time!";
    }
    else
    {
        timeMessage = $"This dumb script\n says it's:\n{inGameTime:HH:mm:ss}";
    }

    if (lcdPanels.Count > 0)
    {
        foreach (var lcd in lcdPanels)
        {
            lcd.WriteText(timeMessage);
        }
    }
    else
    {
        Echo("No LCDs with the name 'IAmDumb' found!");
    }

    List<IMyTextPanel> yellowLcdPanels = new List<IMyTextPanel>();
    GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(yellowLcdPanels, panel => panel.CustomName == "yellow");

    if (yellowLcdPanels.Count > 0)
    {
        foreach (var lcd in yellowLcdPanels)
        {
            lcd.WriteText("yellow51 was here");
        }
    }
}
