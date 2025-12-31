using CounterStrikeSharp.API.Core;

namespace CS2_RadioSounds;

public class RadioSoundsConfig : BasePluginConfig
{
    public bool DebugRadioSlotsToChat { get; set; } = false;
    public List<RadioSlotConfig> RadioSlots { get; set; } =
    [
        new RadioSlotConfig
        {
            Slot = 2,
            Sounds = ["sounds/xnet/replace/radio/go.vsnd"],
            CooldownSeconds = 30,
            ChatAllKey = "lang.chatall.go"
        },
        new RadioSlotConfig
        {
            Slot = 3,
            Sounds = ["sounds/xnet/replace/radio/fallback.vsnd"],
            CooldownSeconds = 60,
            ChatAllKey = "lang.chatall.fallback"
        },
        new RadioSlotConfig
        {
            Slot = 6,
            Sounds = ["sounds/xnet/replace/radio/followme.vsnd"],
            CooldownSeconds = 60,
            ChatAllKey = "lang.chatall.followme"
        },
        new RadioSlotConfig
        {
            Slot = 8,
            Sounds =
            [
                "sounds/xnet/replace/radio/roger1.vsnd",
                "sounds/xnet/replace/radio/roger2.vsnd"
            ],
            CooldownSeconds = 60,
            ChatAllKey = "lang.chatall.roger"
        },
        new RadioSlotConfig
        {
            Slot = 9,
            Sounds =
            [
                "sounds/xnet/replace/radio/negative1.vsnd",
                "sounds/xnet/replace/radio/negative2.vsnd",
                "sounds/xnet/replace/radio/negative3.vsnd",
                "sounds/xnet/replace/radio/back.vsnd"
            ],
            CooldownSeconds = 60,
            ChatAllKey = "lang.chatall.negative"
        },
        new RadioSlotConfig
        {
            Slot = 10,
            Sounds =
            [
                "sounds/xnet/cheer/cheer_1.vsnd",
                "sounds/xnet/cheer/cheer_10.vsnd",
                "sounds/xnet/cheer/cheer_11.vsnd",
                "sounds/xnet/cheer/cheer_12.vsnd",
                "sounds/xnet/cheer/cheer_13.vsnd",
                "sounds/xnet/cheer/cheer_14.vsnd",
                "sounds/xnet/cheer/cheer_15.vsnd",
                "sounds/xnet/cheer/cheer_2.vsnd",
                "sounds/xnet/cheer/cheer_3.vsnd",
                "sounds/xnet/cheer/cheer_4.vsnd",
                "sounds/xnet/cheer/cheer_5.vsnd",
                "sounds/xnet/cheer/cheer_6.vsnd",
                "sounds/xnet/cheer/cheer_7.vsnd",
                "sounds/xnet/cheer/cheer_8.vsnd",
                "sounds/xnet/cheer/cheer_9.vsnd",
                "sounds/xnet/cheer/red1.vsnd",
                "sounds/xnet/cheer/red10.vsnd",
                "sounds/xnet/cheer/red11.vsnd",
                "sounds/xnet/cheer/red2.vsnd",
                "sounds/xnet/cheer/red3.vsnd",
                "sounds/xnet/cheer/red4.vsnd",
                "sounds/xnet/cheer/red5.vsnd",
                "sounds/xnet/cheer/red6.vsnd",
                "sounds/xnet/cheer/red7.vsnd",
                "sounds/xnet/cheer/red8.vsnd",
                "sounds/xnet/cheer/red9.vsnd",
                "sounds/xnet/replace/radio/cheer1.vsnd",
                "sounds/xnet/replace/radio/cheer2.vsnd"
            ],
            CooldownSeconds = 75,
            ChatAllKey = "lang.chatall.cheer"
        },
        new RadioSlotConfig
        {
            Slot = 12,
            Sounds = ["sounds/xnet/replace/radio/thanks.vsnd"],
            CooldownSeconds = 60,
            ChatAllKey = "lang.chatall.thanks"
        },
        new RadioSlotConfig
        {
            Slot = 15,
            Sounds =
            [
                "sounds/xnet/replace/radio/needbackup.vsnd",
                "sounds/xnet/replace/radio/coverme1.vsnd",
                "sounds/xnet/replace/radio/coverme2.vsnd"
            ],
            CooldownSeconds = 60,
            ChatAllKey = "lang.chatall.needbackup"
        }
    ];

    public List<CustomCommandConfig> CustomCommands { get; set; } =
    [
        new CustomCommandConfig
        {
            Commands = ["affirmative", "rogerthat", "yes"],
            Sounds =
            [
                "sounds/xnet/replace/radio/roger1.vsnd",
                "sounds/xnet/replace/radio/roger2.vsnd"
            ],
            CooldownSeconds = 60,
            ChatAllKey = "lang.chatall.roger"
        },
        new CustomCommandConfig
        {
            Commands = ["thanks"],
            Sounds = ["sounds/xnet/replace/radio/thanks.vsnd"],
            CooldownSeconds = 60,
            ChatAllKey = "lang.chatall.thanks"
        },
        new CustomCommandConfig
        {
            Commands = ["cheer", "lol"],
            Sounds =
            [
                "sounds/xnet/cheer/cheer_1.vsnd",
                "sounds/xnet/cheer/cheer_10.vsnd",
                "sounds/xnet/cheer/cheer_11.vsnd",
                "sounds/xnet/cheer/cheer_12.vsnd",
                "sounds/xnet/cheer/cheer_13.vsnd",
                "sounds/xnet/cheer/cheer_14.vsnd",
                "sounds/xnet/cheer/cheer_15.vsnd",
                "sounds/xnet/cheer/cheer_2.vsnd",
                "sounds/xnet/cheer/cheer_3.vsnd",
                "sounds/xnet/cheer/cheer_4.vsnd",
                "sounds/xnet/cheer/cheer_5.vsnd",
                "sounds/xnet/cheer/cheer_6.vsnd",
                "sounds/xnet/cheer/cheer_7.vsnd",
                "sounds/xnet/cheer/cheer_8.vsnd",
                "sounds/xnet/cheer/cheer_9.vsnd",
                "sounds/xnet/cheer/red1.vsnd",
                "sounds/xnet/cheer/red10.vsnd",
                "sounds/xnet/cheer/red11.vsnd",
                "sounds/xnet/cheer/red2.vsnd",
                "sounds/xnet/cheer/red3.vsnd",
                "sounds/xnet/cheer/red4.vsnd",
                "sounds/xnet/cheer/red5.vsnd",
                "sounds/xnet/cheer/red6.vsnd",
                "sounds/xnet/cheer/red7.vsnd",
                "sounds/xnet/cheer/red8.vsnd",
                "sounds/xnet/cheer/red9.vsnd",
                "sounds/xnet/replace/radio/cheer1.vsnd",
                "sounds/xnet/replace/radio/cheer2.vsnd"
            ],
            CooldownSeconds = 75,
            ChatAllKey = "lang.chatall.cheer"
        },
        new CustomCommandConfig
        {
            Commands = ["sry"],
            Sounds =
            [
                "sounds/xnet/replace/radio/sorry1.vsnd",
                "sounds/xnet/replace/radio/sorry2.vsnd"
            ],
            CooldownSeconds = 60,
            ChatAllKey = "lang.chatall.sorry"
        },
        new CustomCommandConfig
        {
            Commands = ["fuk", "fuku"],
            Sounds = ["sounds/xnet/cheer/fkyou.vsnd"],
            CooldownSeconds = 30,
            ChatAllKey = "lang.chatall.fuku"
        },
        new CustomCommandConfig
        {
            Commands = ["baka"],
            Sounds = ["sounds/hlym/baka.vsnd"],
            CooldownSeconds = 30,
            ChatAllKey = "lang.chatall.baka"
        }
    ];
}

public class RadioSlotConfig
{
    public int Slot { get; set; }
    public List<string> Sounds { get; set; } = [];
    public int CooldownSeconds { get; set; } = 5;
    public string? ChatAllKey { get; set; }
}

public class CustomCommandConfig
{
    public List<string> Commands { get; set; } = [];
    public List<string> Sounds { get; set; } = [];
    public int CooldownSeconds { get; set; } = 5;
    public string? ChatAllKey { get; set; }
}
