using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Events;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Localization;

namespace CS2_RadioSounds;

[MinimumApiVersion(80)]
public class RadioSoundsPlugin : BasePlugin, IPluginConfig<RadioSoundsConfig>
{
    public override string ModuleName => "CS2-RadioSounds";
    public override string ModuleVersion => "1.0.0";
    public override string ModuleAuthor => "DearCrazyLeaf";
    public override string ModuleDescription => "Unified radio sound replacement plugin.";
    public required RadioSoundsConfig Config { get; set; }

    private readonly Dictionary<string, Dictionary<CCSPlayerController, DateTimeOffset>> _lastPlayed = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, int> _lastIndex = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<int, RadioSlotConfig> _radioSlots = new();
    private readonly HashSet<string> _registeredCommands = new(StringComparer.OrdinalIgnoreCase);
    private readonly IStringLocalizer<RadioSoundsPlugin> _localizer;

    public RadioSoundsPlugin(IStringLocalizer<RadioSoundsPlugin> localizer)
    {
        _localizer = localizer;
    }

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventPlayerRadio>(OnPlayerRadio, HookMode.Post);
        RegisterCustomCommands();
    }

    public void OnConfigParsed(RadioSoundsConfig config)
    {
        Config = config;
        RebuildRadioSlots();
        RegisterCustomCommands();

        Server.PrintToConsole($"Loaded {Config.RadioSlots.Count} radio slot configs.");
        Server.PrintToConsole($"Loaded {Config.CustomCommands.Count} custom command configs.");
    }

    private void RegisterCustomCommands()
    {
        if (Config == null)
        {
            return;
        }

        foreach (var commandConfig in Config.CustomCommands)
        {
            var commands = commandConfig.Commands ?? [];

            foreach (var command in commands)
            {
                var trimmedCommand = command?.Trim();
                if (string.IsNullOrEmpty(trimmedCommand) || _registeredCommands.Contains(trimmedCommand))
                {
                    continue;
                }

                var groupId = $"custom:{trimmedCommand}";
                AddCommand(trimmedCommand, "Custom sound command.", (commandPlayer, info) =>
                    HandleSoundGroup(groupId, commandConfig.Sounds, commandConfig.CooldownSeconds, commandPlayer, info, commandConfig.ChatAllKey));

                _registeredCommands.Add(trimmedCommand);
            }
        }
    }

    private void RebuildRadioSlots()
    {
        _radioSlots.Clear();

        foreach (var radio in Config.RadioSlots)
        {
            if (radio.Slot < 0)
            {
                continue;
            }

            _radioSlots[radio.Slot] = radio;
        }
    }

    private HookResult OnPlayerRadio(EventPlayerRadio @event, GameEventInfo info)
    {
        if (Config.DebugRadioSlotsToChat && @event.Userid != null)
        {
            @event.Userid.PrintToChat($"[RadioSlot] slot={@event.Slot}");
        }

        if (!_radioSlots.TryGetValue(@event.Slot, out var radio))
        {
            return HookResult.Continue;
        }

        var groupId = $"radio:{@event.Slot}";
        HandleSoundGroup(groupId, radio.Sounds, radio.CooldownSeconds, @event.Userid, null, radio.ChatAllKey);
        return HookResult.Continue;
    }

    private void HandleSoundGroup(string groupId, List<string> sounds, int cooldownSeconds, CCSPlayerController? player, CommandInfo? info, string? chatAllKey)
    {
        if (sounds.Count == 0)
        {
            var didNotLoadMessage = _localizer["lang.plugin.didnotload"];
            if (player != null)
            {
                player.PrintToChat(didNotLoadMessage);
            }

            info?.ReplyToCommand(didNotLoadMessage);

            return;
        }

        if (player != null)
        {
            if (!_lastPlayed.TryGetValue(groupId, out var lastByPlayer))
            {
                lastByPlayer = new Dictionary<CCSPlayerController, DateTimeOffset>();
                _lastPlayed[groupId] = lastByPlayer;
            }

            if (lastByPlayer.TryGetValue(player, out var lastPlayed) &&
                DateTimeOffset.UtcNow - lastPlayed < TimeSpan.FromSeconds(cooldownSeconds))
            {
                var cooldownMessage = $"{_localizer["lang.chat.cooldown", cooldownSeconds]}";
                player.PrintToChat(cooldownMessage);
                info?.ReplyToCommand(cooldownMessage);
                player.PrintToCenter(_localizer["lang.center.cooldown"]);
                return;
            }

            lastByPlayer[player] = DateTimeOffset.UtcNow;
        }

        var song = PickSound(groupId, sounds);
        foreach (var target in Utilities.GetPlayers())
        {
            target.ExecuteClientCommand($"play \"{song}\"");
        }

        if (!string.IsNullOrWhiteSpace(chatAllKey))
        {
            var teamColor = player?.Team switch
            {
                CsTeam.CounterTerrorist => ChatColors.Blue,
                CsTeam.Terrorist => ChatColors.Red,
                _ => ChatColors.White
            };

            Server.PrintToChatAll($"{_localizer[chatAllKey, (player?.PlayerName ?? "Console"), teamColor]}");
        }
    }

    private string PickSound(string groupId, List<string> sounds)
    {
        if (sounds.Count <= 1)
        {
            return sounds[0];
        }

        var lastIndex = _lastIndex.TryGetValue(groupId, out var previous) ? previous : -1;
        int nextIndex;
        do
        {
            nextIndex = Random.Shared.Next(0, sounds.Count);
        }
        while (nextIndex == lastIndex);

        _lastIndex[groupId] = nextIndex;
        return sounds[nextIndex];
    }
}
