# CS2-RadioSounds

[![中文版介绍](https://img.shields.io/badge/跳转到中文版-中文版介绍-red)](#中文版介绍)
[![Release](https://img.shields.io/github/v/release/DearCrazyLeaf/CS2-RadioSounds?include_prereleases&color=blueviolet)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/releases/latest)
[![License](https://img.shields.io/badge/License-GPL%203.0-orange)](https://www.gnu.org/licenses/gpl-3.0.txt)
[![Issues](https://img.shields.io/github/issues/DearCrazyLeaf/CS2-RadioSounds?color=darkgreen)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/issues)
[![Pull Requests](https://img.shields.io/github/issues-pr/DearCrazyLeaf/CS2-RadioSounds?color=blue)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/pulls)
[![Downloads](https://img.shields.io/github/downloads/DearCrazyLeaf/CS2-RadioSounds/total?color=brightgreen)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/releases)
[![GitHub Stars](https://img.shields.io/github/stars/DearCrazyLeaf/CS2-RadioSounds?color=yellow)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/stargazers)

**A unified CS2 radio sound replacement plugin with slot-based radio events and configurable custom commands.**

## Features

- **Radio Slot Mapping**: Replace radio sounds by `player_radio` slot
- **Custom Commands**: Define your own commands and sounds (e.g. fuku/baka)
- **Per-Group Cooldowns**: Different cooldowns for each radio or command
- **Random Playback**: Multiple sounds per group play randomly (no immediate repeats)
- **Localization Ready**: JSON-based language files

## Requirements

- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)
- [MetaMod:Source (CS2 branch)](https://www.metamodsource.net/downloads.php?branch=dev)

## Installation

1. Download the latest release
2. Extract to `game/csgo/addons/counterstrikesharp/plugins`
3. Start the server once to generate config
4. Edit config and restart the server

> [!IMPORTANT]
> This plugin does not include any sound resources. Please upload your own sounds.

## Configuration

Config path:
`addons/counterstrikesharp/configs/plugins/CS2-RadioSounds/CS2-RadioSounds.json`

```json
{
  "DebugRadioSlotsToChat": false,
  "RadioSlots": [
    {
      "Slot": 2,
      "Sounds": ["sounds/xnet/replace/radio/go.vsnd"],
      "CooldownSeconds": 30,
      "ChatAllKey": "lang.chatall.go"
    }
  ],
  "CustomCommands": [
    {
      "Commands": ["fuk", "fuku"],
      "Sounds": ["sounds/xnet/cheer/fkyou.vsnd"],
      "CooldownSeconds": 30,
      "ChatAllKey": "lang.chatall.fuku"
    }
  ],
  "ConfigVersion": 1
}
```

> [!NOTE]
> Radio slots are triggered by the `player_radio` event.
> Use `DebugRadioSlotsToChat` to print slot IDs in chat while mapping.

## Commands

Custom commands are fully configurable in `CustomCommands`.

## License

<a href="https://www.gnu.org/licenses/gpl-3.0.txt" target="_blank" style="margin-left: 10px; text-decoration: none;">
    <img src="https://img.shields.io/badge/License-GPL%203.0-orange?style=for-the-badge&logo=gnu" alt="GPL v3 License">
</a>

---

# 中文版介绍

[![English](https://img.shields.io/badge/Back%20to%20English-English-red)](#cs2-radiosounds)
[![Release](https://img.shields.io/github/v/release/DearCrazyLeaf/CS2-RadioSounds?include_prereleases&color=blueviolet)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/releases/latest)
[![License](https://img.shields.io/badge/License-GPL%203.0-orange)](https://www.gnu.org/licenses/gpl-3.0.txt)
[![Issues](https://img.shields.io/github/issues/DearCrazyLeaf/CS2-RadioSounds?color=darkgreen)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/issues)
[![Pull Requests](https://img.shields.io/github/issues-pr/DearCrazyLeaf/CS2-RadioSounds?color=blue)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/pulls)
[![Downloads](https://img.shields.io/github/downloads/DearCrazyLeaf/CS2-RadioSounds/total?color=brightgreen)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/releases)
[![GitHub Stars](https://img.shields.io/github/stars/DearCrazyLeaf/CS2-RadioSounds?color=yellow)](https://github.com/DearCrazyLeaf/CS2-RadioSounds/stargazers)

**一个统一的 CS2 电台音效替换插件，支持 slot 监听与自定义指令触发。**

## 功能

- **电台 Slot 映射**：通过 `player_radio` 事件替换电台音效
- **自定义指令**：任意命令触发自定义音效（如 fuku/baka）
- **独立冷却**：每组音效都可单独配置冷却
- **随机播放**：多条音效随机播放，避免连续重复
- **本地化支持**：JSON 语言文件

## 需求

- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)
- [MetaMod:Source (CS2 branch)](https://www.metamodsource.net/downloads.php?branch=dev)

## 安装

1. 下载最新 Release
2. 解压至 `game/csgo/addons/counterstrikesharp/plugins`
3. 启动服务器生成配置
4. 修改配置并重启服务器

> [!IMPORTANT]
> 本插件不包含任何音效资源，请自行上传。

## 配置

配置路径：
`addons/counterstrikesharp/configs/plugins/CS2-RadioSounds/CS2-RadioSounds.json`

```json
{
  "DebugRadioSlotsToChat": false,
  "RadioSlots": [
    {
      "Slot": 2,
      "Sounds": ["sounds/xnet/replace/radio/go.vsnd"],
      "CooldownSeconds": 30,
      "ChatAllKey": "lang.chatall.go"
    }
  ],
  "CustomCommands": [
    {
      "Commands": ["fuk", "fuku"],
      "Sounds": ["sounds/xnet/cheer/fkyou.vsnd"],
      "CooldownSeconds": 30,
      "ChatAllKey": "lang.chatall.fuku"
    }
  ],
  "ConfigVersion": 1
}
```

> [!NOTE]
> 电台触发来自 `player_radio` 事件。
> 开启 `DebugRadioSlotsToChat` 可在聊天框打印 slot，便于映射。

## 命令

命令由 `CustomCommands` 配置决定，可自由增删。

## 许可证

<a href="https://www.gnu.org/licenses/gpl-3.0.txt" target="_blank" style="margin-left: 10px; text-decoration: none;">
    <img src="https://img.shields.io/badge/License-GPL%203.0-orange?style=for-the-badge&logo=gnu" alt="GPL v3 License">
</a>
