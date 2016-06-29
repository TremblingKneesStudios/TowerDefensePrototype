FOLDER/HEIRARCHY CONVENTIONS:

ENV = environment
TWR = tower
CHR = character (player/enemy/NPC)
SND = sound and music
MCH = mechanic (scripts for mechanics go on these)
UI = ui (duh)
AMB = ambient assets (SND/ENV not included)
TEX = texture
MAT = material
SHD = shader
SPT = sprite
TER = terrain

XXX_CLD = child is main object (parent is used for positioning)

========

EXPORT PACKAGE CONVENTIONS:

object:
component1
component2
	variable [value] (description)

component3
	variable [value] 
		sub-variable [value]

==----==

example:
mesh filter
mesh renderer
rigidbody
	mass [1]

playerManager (script)
	players [10] (manages position of each player)
		playerPosition [transform]

==----==
//do not edit varaibles not mentioned in README