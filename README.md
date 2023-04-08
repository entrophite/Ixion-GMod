# Customize your own IXION journey

This IXION mod was forked from [Synthlight/Ixion-GMod](https://github.com/Synthlight/Ixion-GMod) with major updates,
including some new tweak features and configuration.

## Tweaks by category:

Game:

- Allow VOHLE jump despite the storyline progress (skipping chapters)

Tiqqun and sectors:

- Force adding crews as workers before hitting a total number of workers (early-game friendly)
- Force adding crews as workers after hitting a total number of non-worker (late-game friendly)
- Capacity of Crew Quarters (increase or decrease)
- Crew recovery speed from injury (faster or slower)
- Boost sector specialization to maximum after surpassing a specified threshold
- Hull degradation speed (faster or slower)
- Lock hull integrity
- Lock trust
- Disable all accidents despite working conditions
- Remove policy cooldown
- Lock stability at a minimum level when dropping below it
- Remove negative stability impact from certain policies

Production:

- Capacity of Stockpiles (increase or decrease)
- Capacity of Docking Bays (increase or decrease)
- Workshop building and repair speed (faster or slower)
- EVA Airlock building and repair speed (faster or slower)
- Probe Launcher and Docking Bay building speed (faster or slower)
- Factory production speed
- Unlimited number of in-sector transporters
- Unlimited number of inter-sector transporters
- Transporter movement speed (faster or slower)
- Drops hydrogen requirement of Nuclear Power Plant 
- No resource refund when destroying buildings

Research:

- Research speed (faster or slower)
- Remove all prerequisites from researching technologies and upgrades

Space and resources:

- Space weather immunity (including probes, space ships and Tiqqun itself)
- Resource mining/science extracting speed (faster or slower)
- Science accural from Tech Lab's passive (faster or slower)
- Science curated from POI exploration (increase or decrease)
- Infinite ship autonomy, ships needs no maintenance at Docking Bay
- Space ship movement speed (faster or slower)
- Tiqqun top movement speed (faster or slower)
- Space ship exp gaining speed (faster or slower)
- Probe scan range (larger or smaller)


Tweaks can be disabled individually by configuration.
Some tweaks can be used to make gameplay either easier or more challenging
depending on the values are manipulated which way.


## Requirements:

- BepInEx: tested with bleeding edge build #668.
- (optional) Visual Studio with C# IDE: if you want to compile the source from scratch.


## Installation:

1. [Download BepInEx](https://builds.bepinex.dev/projects/bepinex_be) of x64 architecture and with IL2CPP support (not Mono ones!)
2. [Install BepInEx](https://docs.bepinex.dev/master/articles/user_guide/installation/index.html)
3. Download (or compile) the GMod.dll, put it into `BepInEx\plugins`.
4. Run the game, the config file will be generated as `BepInEx\config\ixion-gmod.cfg` for customization. You need to restart the game to make cutomized tweaks take place.


## How to compile (optional):

1. [Install BepInEx](https://docs.bepinex.dev/master/articles/user_guide/installation/index.html).
2. Run the game once, waiting for BepInEx to generate dummy assemblies under `BepInEx\interop`.
3. Open GMod.csproj in Visual Studio.
4. Add necessary assemblies as project references, can either be found under `BepInEx\core` or `BepInEx\interop`.
5. <kbd><kbd>CTRL</kbd>+<kbd>B</kbd></kbd> to build, the result assembly will be found at `Ixion-GMod\bin\x64\Debug\GMod.dll`.
6. (optional) To develop more tweaks, you may also need dnSpy, and possibly ghidra for further reverse engineering.


## Todo list/more tweaks to try out:

These are tweaks/improvements desired, not guaranteed to be possible to add.

- Disable Piranesi activity, including its chasing, Mess Hall hack, swarm attach and missle launch
- Prevent crew from injury/death
