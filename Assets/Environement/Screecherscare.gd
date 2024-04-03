extends CanvasLayer

onready var camera = $Camera2D
onready var audio = $AudioStreamPlayer
onready var animation = $AnimationPlayer

var demigod

func init(demigod):
	self.demigod = demigod

func _ready():
	camera.current = true
	audio.play(0.2)
	animation.play("Scare")

func _on_AudioStreamPlayer_finished():
	demigod.game_over()
	queue_free()
